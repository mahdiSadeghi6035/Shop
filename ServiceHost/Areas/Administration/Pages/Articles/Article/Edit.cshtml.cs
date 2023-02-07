using ArticleManagement.Application.Contract.ArticleApp;
using ArticleManagement.Application.Contract.ArticleCategoryApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Articles.Article
{
    public class EditModel : PageModel
    {
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _articleApplication;
        public SelectList SelectLists{ get; set; }
        public EditArticle Command { get; set; }
        public EditModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleCategoryApplication = articleCategoryApplication;
            _articleApplication = articleApplication;
        }

        public void OnGet(long id)
        {
            Command = _articleApplication.GetEdit(id);
            SelectLists = new SelectList(_articleCategoryApplication.GetArticleCategory(),"Id","Name");
        }
        public IActionResult OnPost(EditArticle command)
        {
            var result = _articleApplication.Edit(command);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Edit");
        }
    }
}
