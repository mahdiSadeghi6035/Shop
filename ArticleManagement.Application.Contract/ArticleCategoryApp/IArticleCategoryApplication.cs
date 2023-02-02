using _0_Framework.Application;
using System.Collections.Generic;

namespace ArticleManagement.Application.Contract.ArticleCategoryApp
{
    public interface IArticleCategoryApplication
    {
        OperationResult Create(CreateArticleCategory command);
        OperationResult Edit(EditArticleCategory command);
        EditArticleCategory GetEdit(long id);
        List<ViewModelArticleCategory> Search(SearchModelArtilceCategory searchModel);
    }
}
