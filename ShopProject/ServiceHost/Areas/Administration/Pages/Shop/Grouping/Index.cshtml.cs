using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.GroupingApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Grouping
{
    public class IndexModel : PageModel
    {
        private readonly IGroupingApplication _groupingApplication;
        public List<ViewModelGrouping> Grouping{ get; set; }
        public SearchModelGrouping SearchModel { get; set; }
        public IndexModel(IGroupingApplication groupingApplication)
        {
            _groupingApplication = groupingApplication;
        }

        public void OnGet(SearchModelGrouping searchModel)
        {
            Grouping = _groupingApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
        public JsonResult OnPostCreate(CreateGrouping command)
        {
            var result = _groupingApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var grouping = _groupingApplication.Exists(id);
            return Partial("./Edit",grouping);
        }
        public JsonResult OnPostEdit(EditGrouping command)
        {
            var result = _groupingApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
