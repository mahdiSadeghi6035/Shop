using _0_Framework.Application;
using _0_Framework.Infrastructure;
using DiscountManagement.Application.Contract.CodeDiscountApp;
using DiscountManagement.Domain.CodeDiscountAgg;
using ShopManagement.Infrastructure.EfCore;
using System.Collections.Generic;
using System.Linq;

namespace DiscountManagement.Infrastructure.EfCore.Repository
{
    public class CodeDiscountRepository : RepositoryBase<long, CodeDiscount>, ICodeDiscountRepository
    {
        private readonly DiscountContext _context;
        private readonly ShopContext _shopContext;
        public CodeDiscountRepository(DiscountContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditCodeDiscount GetEdit(long id)
        {
            return _context.CodeDiscount.Select(x => new EditCodeDiscount
            {
                Id = x.Id,
                AccountId = x.AccountId,
                Code = x.Code,
                Description = x.Description,
                DiscountRate = x.DiscountRate,
                ProductId = x.ProductId,
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelCodeDiscount> Search(SearchModelDiscount searchModel)
        {
            var query = _context.CodeDiscount.Select(x => new ViewModelCodeDiscount
            {
                Id = x.Id,
                AccountId = x.AccountId,
                Account = "test",
                Code = x.Code,
                DiscountRate = x.DiscountRate,
                CreateionDate = x.CreationDate.ToFarsi(),
                IsRemove = x.IsRemoved,
                ProductId = x.ProductId
            });
            var product = _shopContext.Products.Select(x => new { x.Id, x.Name}).ToList();
            var codeDiscount = query.OrderByDescending(x => x.Id).ToList();
            codeDiscount.ForEach(c => c.ProductName = codeDiscount.FirstOrDefault(p => p.Id == c.ProductId)?.ProductName);
            return codeDiscount;
        }
    }
}
