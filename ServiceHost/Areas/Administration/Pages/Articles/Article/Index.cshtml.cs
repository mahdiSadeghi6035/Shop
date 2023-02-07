using ArticleManagement.Application.Contract.ArticleApp;
using ArticleManagement.Application.Contract.ArticleCategoryApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Articles.Article
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _articleApplication;
        public List<ViewModelArticle> Articles { get; set; }
        public SearchModelArticle SearchModel { get; set; }
        public SelectList SelectLists { get; set; }
        public IndexModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet(SearchModelArticle searchModel)
        {
            Articles = _articleApplication.Search(searchModel);
            SelectLists = new SelectList(_articleCategoryApplication.GetArticleCategory(), "Id", "Name");
        }
    }
}
