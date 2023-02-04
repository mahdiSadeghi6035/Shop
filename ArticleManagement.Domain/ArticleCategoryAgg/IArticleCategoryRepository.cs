using _0_Framework.Domain;
using ArticleManagement.Application.Contract.ArticleCategoryApp;
using System.Collections.Generic;

namespace ArticleManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<long, ArticleCategory>
    {
        EditArticleCategory GetEdit(long id);
        List<ViewModelArticleCategory> Search(SearchModelArtilceCategory searchModel);
        string GetSlug(long id);
    }
}
