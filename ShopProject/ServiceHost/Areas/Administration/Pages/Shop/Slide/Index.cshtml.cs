using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.SlideApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slide
{
    public class IndexModel : PageModel
    {
        private readonly ISlideApplication _slideApplication;
        public List<ViewModelSlide> Slides{ get; set; }
        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
            Slides = _slideApplication.GetSlides();
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var slide = _slideApplication.GetEdit(id);
            return Partial("./Edit",slide);
        }
        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = _slideApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            _slideApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            _slideApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
