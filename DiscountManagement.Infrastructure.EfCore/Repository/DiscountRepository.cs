using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.DiscountApp;
using DiscountManagement.Domain.DiscountAgg;
using ShopManagement.Infrastructure.EfCore;
using System.Collections.Generic;
using System.Linq;

namespace DiscountManagement.Infrastructure.EfCore.Repository
{
    public class DiscountRepository : RepositoryBase<long, Discount>, IDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;
        public DiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditDiscount GetEdit(long id)
        {
            return _context.Discounts.Select(x => new EditDiscount
            {
                Id = x.Id,
                DiscountType = x.DiscountType,
                ProductId = x.ProductId,
                Rate = x.Rate
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelDiscount> Search(SearchModelDiscount searchModel)
        {
            var query = _context.Discounts.Select(x => new ViewModelDiscount
            {
                Id = x.Id,
                Rate = x.Rate,
                ProductId = x.ProductId,
                DiscountType = x.DiscountType,
                CreateionDate = x.CreationDate.ToFarsi(),
                DiscountTypeName = DiscountType.GetType(x.DiscountType),
                IsRemoved = x.IsRemoved
            });
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            var product = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            var discount = query.OrderByDescending(x => x.Id).ToList();

            discount.ForEach(d => d.ProductName = product.FirstOrDefault(x => x.Id == d.ProductId)?.Name);

            return discount;
        }
    }
}
