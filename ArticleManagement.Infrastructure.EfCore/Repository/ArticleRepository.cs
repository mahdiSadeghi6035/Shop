using _0_Framework.Application;
using _0_Framework.Infrastructure;
using ArticleManagement.Application.Contract.ArticleApp;
using ArticleManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace ArticleManagement.Infrastructure.EfCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly ArticleContext _context;

        public ArticleRepository(ArticleContext context) : base(context)
        {
            _context = context;
        }

        public Article GetArticleBy(long id)
        {
            return _context.Article.Include(x => x.ArticleCategorys).FirstOrDefault(x => x.Id == id);
        }

        public EditArticle GetEdit(long id)
        {
            return _context.Article.Select(x => new EditArticle
            {
                Id = x.Id,
                Title = x.Title,
                ArticleCategoryId = x.ArticleCategoryId,
                CanonicalAddress = x.CanonicalAddress,
                Description = x.Description,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.Title,
                PublishDate = x.PublishDate.ToString(),
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelArticle> Search(SearchModelArticle searchModel)
        {
            var query = _context.Article.Select(x => new ViewModelArticle
            {
                Id = x.Id,
                ArticleCategory = x.ArticleCategorys.Name,
                ArticleCategoryId = x.ArticleCategoryId,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                PublishDate = x.PublishDate.ToFarsi(),
                Title = x.Title
            });
            if (searchModel.ArticleCategoryId > 0)
                query = query.Where(x => x.ArticleCategoryId == searchModel.ArticleCategoryId);
            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));
            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
