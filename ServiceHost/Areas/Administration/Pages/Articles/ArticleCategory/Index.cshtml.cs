using ArticleManagement.Application.Contract.ArticleCategoryApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Articles.ArticleCategory
{
    public class IndexModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        public SearchModelArtilceCategory SearchModel { get; set; }
        public List<ViewModelArticleCategory> ArticleCategory { get; set; }
        public IndexModel(IArticleCategoryApplication articleCategoryApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
        }

        public void OnGet(SearchModelArtilceCategory searchModel)
        {
            ArticleCategory = _articleCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
        public JsonResult OnPostCreate(CreateArticleCategory command)
        {
            var result = _articleCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var articleCategory = _articleCategoryApplication.GetEdit(id);
            return Partial("./Edit", articleCategory);
        }
        public JsonResult OnPostEdit(EditArticleCategory comnad)
        {
            var result = _articleCategoryApplication.Edit(comnad);
            return new JsonResult(result);
        }
    }
}
