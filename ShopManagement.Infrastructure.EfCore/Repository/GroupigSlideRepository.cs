using _0_Framework.Application;
using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contract.GroupingSlideAgg;
using ShopManagement.Domain.GroupingSlideAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class GroupigSlideRepository : RepositoryBase<long, GroupingSlide>, IGroupingSlideRepository
    {
        private readonly ShopContext _context;

        public GroupigSlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public GroupingSlide Get(long id)
        {
            return _context.GroupingSlides.Include(x => x.Groupings).FirstOrDefault(x => x.Id == id);
        }

        public EditGroupingSlide GetEdit(long id)
        {
            return _context.GroupingSlides.Select(x => new EditGroupingSlide
            {
                Id = x.Id,
                GroupingId = x.GroupingId,
                Link = x.Link,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelGroupingSlide> Search(SearchModelGroupingSlide searchModel)
        {
            var query = _context.GroupingSlides.Include(x => x.Groupings).Select(x => new ViewModelGroupingSlide
            {
                Id = x.Id,
                PictureTitle = x.PictureTitle,
                CreateionDate = x.CreationDate.ToFarsi(),
                GroupingName = x.Groupings.Name,
                GroupinId =x.GroupingId,
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt
            });
            if (searchModel.GroupingId > 0)
                query = query.Where(x => x.GroupinId == searchModel.GroupingId);
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
