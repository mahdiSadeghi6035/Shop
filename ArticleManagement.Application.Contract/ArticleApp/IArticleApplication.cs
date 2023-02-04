using _0_Framework.Application;
using System.Collections.Generic;

namespace ArticleManagement.Application.Contract.ArticleApp
{
    public interface IArticleApplication
    {
        OperationResult Create(CreateArticle command);
        OperationResult Edit(EditArticle command);
        EditArticle GetEdit(long id);
        List<ViewModelArticle> Search(SearchModelArticle searchModel);
    }
}
