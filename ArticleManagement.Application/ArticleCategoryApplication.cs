using _0_Framework.Application;
using ArticleManagement.Application.Contract.ArticleCategoryApp;
using ArticleManagement.Domain.ArticleCategoryAgg;
using System.Collections.Generic;

namespace ArticleManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository)
        {
            _articleCategoryRepository = articleCategoryRepository;
        }

        public OperationResult Create(CreateArticleCategory command)
        {
            var operation = new OperationResult();
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            var articleCategory = new ArticleCategory(command.Name, slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress);
            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChanges();
            return operation.Succedded();

        }

        public OperationResult Edit(EditArticleCategory command)
        {
            var operation = new OperationResult();
            var articleCategory = _articleCategoryRepository.GetBy(command.Id);
            if (articleCategory == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            articleCategory.Edit(command.Name, slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress);
            _articleCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditArticleCategory GetEdit(long id)
        {
            return _articleCategoryRepository.GetEdit(id);
        }

        public List<ViewModelArticleCategory> Search(SearchModelArtilceCategory searchModel)
        {
            return _articleCategoryRepository.Search(searchModel);
        }
    }
}
