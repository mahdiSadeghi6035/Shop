using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.GroupingApp;
using ShopManagement.Application.Contract.GroupingSlideAgg;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.GroupingSlide
{
    public class IndexModel : PageModel
    {
        private readonly IGroupingSlideApplication _groupingSlideApplication;
        private readonly IGroupingApplication _groupingApplication;
        public List<ViewModelGroupingSlide> GroupingSlide { get; set; }
        public SearchModelGroupingSlide SearchModel { get; set; }
        public SelectList SelectLists { get; set; }
        public IndexModel(IGroupingSlideApplication groupingSlideApplication, IGroupingApplication groupingApplication)
        {
            _groupingSlideApplication = groupingSlideApplication;
            _groupingApplication = groupingApplication;
        }

        public void OnGet(SearchModelGroupingSlide searchModel)
        {
            GroupingSlide = _groupingSlideApplication.Search(searchModel);
            SelectLists = new SelectList(_groupingApplication.GetGroupings(), "Id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var groupingSlide = new CreateGroupingSlide()
            {
                ModelGroupings = _groupingApplication.GetGroupings()
            };
            return Partial("./Create", groupingSlide);
        }
        public JsonResult OnPostCreate(CreateGroupingSlide command)
        {
            var result = _groupingSlideApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var groupinSlide = _groupingSlideApplication.GetEdit(id);
            groupinSlide.ModelGroupings = _groupingApplication.GetGroupings();
            return Partial("./Edit", groupinSlide);
        }
        public JsonResult OnPostEdit(EditGroupingSlide command)
        {
            var result = _groupingSlideApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemoved(long id)
        {
            _groupingSlideApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            var result = _groupingSlideApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
