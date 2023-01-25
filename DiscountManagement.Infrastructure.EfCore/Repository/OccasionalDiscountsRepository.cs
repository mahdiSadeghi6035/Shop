using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.OccasionalDiscountsApp;
using DiscountManagement.Domain.OccasionalDiscountsAgg;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EfCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DiscountManagement.Infrastructure.EfCore.Repository
{
    public class OccasionalDiscountsRepository : RepositoryBase<long, OccasionalDiscounts>, IOccasionalDiscountsRepository
    {
        private readonly DiscountContext _context;
        private static ShopContext _shopContext;
        public OccasionalDiscountsRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditOccasionalDiscounts GetEdit(long id)
        {

            return _context.OccasionalDiscounts.Select(x => new EditOccasionalDiscounts
            {
                Id = x.Id,
                EndDate = x.EndDate.ToFarsi(),
                Rate = x.Rate,
                StartDate = x.StartDate.ToFarsi(),
                Title = x.Title,
                ProductDiscount = MapProduct(x.DiscountsProducts)
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        private static List<ProductDiscountModel> MapProduct(List<OccasionalDiscountsProduct> discountsProducts)
        {
            var query = discountsProducts.Select(x => new ProductDiscountModel
            {
                Id = x.ProductId,
            }).ToList();
            var product = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();
            query.ForEach(x => x.Name = product.FirstOrDefault(p => p.Id == x.Id)?.Name);
            return query;
        }

        public List<ViewModelOccasionalDiscounts> Search(SearchModelOccasionalDiscounts searchModel)
        {
            var query = _context.OccasionalDiscounts.Select(x => new ViewModelOccasionalDiscounts
            {
                Id = x.Id,
                Rate = x.Rate,
                Title = x.Title,
                EndDate = x.EndDate.ToFarsi(),
                StartDate = x.StartDate.ToFarsi(),
                EndDateGr = x.EndDate,
                StartDateGr = x.StartDate
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));

            if (!string.IsNullOrWhiteSpace(searchModel.StartDate))
                query = query.Where(x => x.StartDateGr >= searchModel.EndDate.ToGeorgianDateTime());
            if (!string.IsNullOrWhiteSpace(searchModel.EndDate))
                query = query.Where(x => x.EndDateGr <= searchModel.EndDate.ToGeorgianDateTime());
            return query.OrderByDescending(x => x.Id).ToList();
        }

       
    }
}
