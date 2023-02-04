using _0_Framework.Application;
using ArticleManagement.Application.Contract.ArticleApp;
using ArticleManagement.Domain.ArticleAgg;
using ArticleManagement.Domain.ArticleCategoryAgg;
using System.Collections.Generic;

namespace ArticleManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;
        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader, IArticleCategoryRepository articleCategoryRepository)
        {
            _articleRepository = articleRepository;
            _fileUploader = fileUploader;
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticle command)
        {
            var operation = new OperationResult();
            if (_articleRepository.Exists(x => x.Title == command.Title))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            string articleCategorySlug = _articleCategoryRepository.GetSlug(command.ArticleCategoryId);
            string path = $"{articleCategorySlug}//{slug}";
            var file = _fileUploader.Upload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var article = new Article(command.Title, file, command.PictureAlt, command.PictureTitle, slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress, publishDate,command.ArticleCategoryId, command.Description);
            _articleRepository.Create(article);
            _articleRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditArticle command)
        {
            var operation = new OperationResult();
            var article = _articleRepository.GetArticleBy(command.Id);
            if (article == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (_articleRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            string articleCategorySlug = article.ArticleCategorys.Slug;
            string path = $"{articleCategorySlug}//{slug}";
            var file = _fileUploader.Upload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            article.Edit(command.Title, file, command.PictureAlt, command.PictureTitle, slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress, publishDate, command.ArticleCategoryId, command.Description);
            _articleRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditArticle GetEdit(long id)
        {
            return _articleRepository.GetEdit(id);
        }

        public List<ViewModelArticle> Search(SearchModelArticle searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}
