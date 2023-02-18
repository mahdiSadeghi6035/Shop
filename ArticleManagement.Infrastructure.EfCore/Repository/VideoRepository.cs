using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ArticleManagement.Application.Contract.VideoApp;
using ArticleManagement.Domain.VideoAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ArticleManagement.Infrastructure.EfCore.Repository
{
    public class VideoRepository : RepositoryBase<long, Video>, IVideoRepository
    {
        private readonly ArticleContext _context;

        public VideoRepository(ArticleContext context) : base(context)
        {
            _context = context;
        }

        public EditVideo GetEdit(long id)
        {
            return _context.Video.Select(x => new EditVideo
            {
                Id = x.Id,
                Description = x.Description,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                Slug = x.Slug,
                PictureAlt = x.PictureAlt,
                VideoCategoryId = x.VideoCategoryId,
                Type = x.Type,
                PictureTitle = x.PictureTitle
            }).FirstOrDefault(x => x.Id == id);
        }

        public VideoModel GetVideo(long id)
        {
            return _context.Video.Select(x => new VideoModel
            {
                Id = x.Id,
                Video = x.Videos,
                Type = x.Type
            }).FirstOrDefault(x => x.Id == id);
        }

        public Video GetVideoBy(long id)
        {
            return _context.Video.Include(x => x.VideoCategory).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelVideo> Search(SearchModelVideo searchModel)
        {
            var query = _context.Video.Include(x => x.VideoCategory).Select(x => new ViewModelVideo
            {
                Id = x.Id,
                Name = x.Name,
                Picture = x.Picture,
                CreateionDate = x.CreationDate.ToFarsi(),
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                VideoCategory = x.VideoCategory.Name,
                VideoCategoryId = x.VideoCategoryId
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            if (searchModel.VideoCategoryId > 0)
                query = query.Where(x => x.VideoCategoryId == searchModel.VideoCategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
