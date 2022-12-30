using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.ProductApp;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;

        public ProductRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditProduct GetEdit(long id)
        {
            return _context.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                BrandId = x.BrandId,
                CategoryId = x.CategoryId,
                Description = x.Description,
                Keywords = x.Keywords,
                Slug = x.Slug,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Specifications = x.Specifications
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelProduct> GetModelProducts()
        {
            return _context.Products.Select(x => new ViewModelProduct
            {
                Id = x.Id,
                Name = x.Name
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ViewModelProduct> Search(SearchModelProduct searchModel)
        {
            var qeury = _context.Products
                .Include(x => x.Brands)
                .Include(x => x.Categorys)
                .Select(x => new ViewModelProduct
                {
                    Id = x.Id,
                    Name = x.Name,
                    BrandeName = x.Brands.Name,
                    BrandId = x.BrandId,
                    CategoryId = x.CategoryId,
                    CategoryName =x.Categorys.Name,
                    CreationDate =x.CreationDate.ToFarsi(),
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle
                });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                qeury = qeury.Where(x => x.Name.Contains(searchModel.Name));
            if (searchModel.CategoryId > 0)
                qeury = qeury.Where(x => x.CategoryId == searchModel.CategoryId);
            if (searchModel.BrandId > 0)
                qeury = qeury.Where(x => x.BrandId == searchModel.BrandId);

            return qeury.OrderByDescending(x => x.Id).ToList();
        }
    }
}
