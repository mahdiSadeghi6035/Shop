using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ShopManagement.Application.Contract.SlideApp;
using ShopManagement.Domain.SlideAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EfCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public EditSlide GetEdit(long id)
        {
            return _context.Slides.Select(x => new EditSlide
            {
                Id = x.Id,
                Link = x.Link,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelSlide> GetSlides()
        {
            return _context.Slides.Select(x => new ViewModelSlide
            {
                Id = x.Id,
                CreateionDate = x.CreationDate.ToFarsi(),
                IsRemoved =x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
