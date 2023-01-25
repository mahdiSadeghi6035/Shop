using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.CategoryApp;
using ShopManagement.Domain.CategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class CategoryRepository : RepositoryBase<long, Category>, ICategoryRepository
    {
        private readonly ShopContext _context;

        public CategoryRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditCategory Exists(long id)
        {
            return _context.Categorys.Select(x => new EditCategory
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Slug = x.Slug,
                GroupingId = x.GroupingId,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public Category Get(long id)
        {
            return _context.Categorys.Include(x => x.Groupings).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelCategory> GetCategory()
        {
            return _context.Categorys.Select(x => new ViewModelCategory
            {
                Id = x.Id,
                Name = x.Name
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ViewModelCategory> Search(SearchModelCategory searchModel)
        {
            var query = _context.Categorys.Include(x => x.Groupings).Select(x => new ViewModelCategory
            {
                Id = x.Id,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                CreateionDate = x.CreationDate.ToFarsi(),
                Description = x.Description.Substring(0, Math.Min(50, x.Description.Length)) + "...",
                Grouping = x.Groupings.Name,
                Name = x.Name,
                GroupingId = x.GroupingId
            });
            if (searchModel.Grouping > 0)
                query = query.Where(x => x.GroupingId == searchModel.Grouping);
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
