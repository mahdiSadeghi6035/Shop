using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ArticleManagement.Application.Contract.ArticleCategoryApp;
using ArticleManagement.Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace ArticleManagement.Infrastructure.EfCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly ArticleContext _context;

        public ArticleCategoryRepository(ArticleContext context) : base(context)
        {
            _context = context;
        }

        public EditArticleCategory GetEdit(long id)
        {
            return _context.ArticleCategory.Select(x => new EditArticleCategory
            {
                Id = x.Id,
                Name = x.Name,
                CanonicalAddress = x.CanonicalAddress,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelArticleCategory> Search(SearchModelArtilceCategory searchModel)
        {
            var articleCategory = _context.ArticleCategory.Select(x => new ViewModelArticleCategory
            {
                Id = x.Id,
                Name = x.Name,
                CreateionDate = x.CreationDate.ToFarsi(),
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                articleCategory = articleCategory.Where(x => x.Name.Contains(searchModel.Name));
            return articleCategory.OrderByDescending(x => x.Id).ToList();
        }
    }
}
