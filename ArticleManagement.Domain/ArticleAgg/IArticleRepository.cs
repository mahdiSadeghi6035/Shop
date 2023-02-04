using _0_Framework.Domain;
using ArticleManagement.Application.Contract.ArticleApp;
using System.Collections.Generic;

namespace ArticleManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long, Article>
    {
        EditArticle GetEdit(long id);
        List<ViewModelArticle> Search(SearchModelArticle searchModel);
        Article GetArticleBy(long id);
    }
}
