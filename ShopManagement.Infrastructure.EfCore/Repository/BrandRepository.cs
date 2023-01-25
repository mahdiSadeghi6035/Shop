using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.BrandApp;
using ShopManagement.Domain.BrandAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class BrandRepository : RepositoryBase<long, Brand>, IBrandRepository
    {
        private readonly ShopContext _context;

        public BrandRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditBrand GetEdit(long id)
        {
            return _context.Brands.Select(x => new EditBrand
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelBrand> GetModelBrands()
        {
            return _context.Brands.Select(x => new ViewModelBrand
            {
                Id =x.Id,
                Name = x.Name
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ViewModelBrand> Search(SearchModelBrand searchModel)
        {
            var query = _context.Brands.Select(x => new ViewModelBrand
            {
                Id = x.Id,
                PictureTitle = x.PictureTitle,
                CreationDate = x.CreationDate.ToFarsi(),
                Description = x.Description.Substring(0,Math.Min(50,x.Description.Length)) + "...",
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
