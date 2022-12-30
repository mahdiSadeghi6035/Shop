using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.GroupingApp;
using ShopManagement.Domain.GroupingAgg;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class GroupingRepository : RepositoryBase<long, Grouping>, IGroupingRepository
    {
        private readonly ShopContext _context;

        public GroupingRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditGrouping Exists(long id)
        {
            return _context.Groupings.Select(x => new EditGrouping
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelGrouping> GetGroupings()
        {
            return _context.Groupings.Select(x => new ViewModelGrouping
            {
                Id = x.Id,
                Name = x.Name
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ViewModelGrouping> Search(SearchModelGrouping searchModel)
        {
            var query = _context.Groupings.Select(x => new ViewModelGrouping
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Description = x.Description.Substring(0, Math.Min(x.Description.Length, 50)) + "...",
                CreationDate = x.CreationDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
