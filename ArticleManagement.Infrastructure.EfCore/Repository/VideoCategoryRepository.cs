using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ArticleManagement.Application.Contract.VideoCategoryApp;
using ArticleManagement.Domain.VideoCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace ArticleManagement.Infrastructure.EfCore.Repository
{
    public class VideoCategoryRepository : RepositoryBase<long, VideoCategory>, IVideoCategoryRepository
    {
        private readonly ArticleContext _context;

        public VideoCategoryRepository(ArticleContext context) : base(context)
        {
            _context = context;
        }

        public EditVideoCategory GetEdit(long id)
        {
            return _context.VideoCategory.Select(x => new EditVideoCategory
            {
                Id = x.Id,
                Slug = x.Slug,
                Name = x.Name,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
            }).FirstOrDefault(x => x.Id == id);
        }

        public string GetSlug(long id)
        {
            return _context.VideoCategory.FirstOrDefault(x => x.Id == id)?.Slug;
        }

        public List<ViewModelVideoCategory> GetVideoCategory()
        {
            return _context.VideoCategory.Select(x => new ViewModelVideoCategory
            {
                Id = x.Id,
                Name = x.Name
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ViewModelVideoCategory> Search(SearchModelVideoCategory searchModel)
        {
            var query = _context.VideoCategory.Select(x => new ViewModelVideoCategory
            {
                Id = x.Id,
                Name = x.Name,
                CreateionDate = x.CreationDate.ToFarsi()
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
