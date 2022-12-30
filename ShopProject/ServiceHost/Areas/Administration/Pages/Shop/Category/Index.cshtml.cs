using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.CategoryApp;
using ShopManagement.Application.Contract.GroupingApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Category
{
    public class IndexModel : PageModel
    {
        private readonly ICategoryApplication _categoryApplication;
        private readonly IGroupingApplication _groupingApplication;
        public SelectList SelectLists { get; set; }
        public List<ViewModelCategory> Category { get; set; }
        public SearchModelCategory SearchModel { get; set; }
        public IndexModel(ICategoryApplication categoryApplication, IGroupingApplication groupingApplication)
        {
            _categoryApplication = categoryApplication;
            _groupingApplication = groupingApplication;
        }

        public void OnGet(SearchModelCategory searchModel)
        {
            Category = _categoryApplication.Search(searchModel);
            SelectLists = new SelectList(_groupingApplication.GetGroupings(), "Id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var category = new CreateCategory()
            {
                modelGroupings = _groupingApplication.GetGroupings()
            };
            return Partial("./Create", category);
        }
        public JsonResult OnPostCreate(CreateCategory command)
        {
            var result = _categoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var category = _categoryApplication.Exists(id);
            category.modelGroupings = _groupingApplication.GetGroupings();
            return Partial("./Edit",category);
        }
        public JsonResult OnPostEdit(EditCategory command)
        {
            var result = _categoryApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
