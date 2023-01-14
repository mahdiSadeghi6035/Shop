using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductApp;
using ShopManagement.Application.Contract.VideoProductApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.VideoProduct
{
    public class IndexModel : PageModel
    {
        private readonly IVideoProductApplication _videoProductApplication;
        private readonly IProductApplication _productApplication;
        public List<ViewModelVideoProduct> VideoProduct{ get; set; }
        public SearchModelVideoProduct SearchModel { get; set; }
        public SelectList SelectLists{ get; set; }
        public IndexModel(IVideoProductApplication videoProductApplication, IProductApplication productApplication)
        {
            _videoProductApplication = videoProductApplication;
            _productApplication = productApplication;
        }

        public void OnGet(SearchModelVideoProduct searchModel)
        {
            VideoProduct = _videoProductApplication.Search(searchModel);
            SelectLists = new SelectList(_productApplication.GetModelProducts(),"Id","Name");
        }
        public IActionResult OnGetCreate()
        {
            var videoProduct = new CreateVideoProduct()
            {
                ModelProducts = _productApplication.GetModelProducts()
            };
            return Partial("./Create",videoProduct);
        }
        public JsonResult OnPostCreate(CreateVideoProduct command)
        {
            var result = _videoProductApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var videoProduct = _videoProductApplication.GetEdit(id);
            videoProduct.ModelProducts = _productApplication.GetModelProducts();
            return Partial("./Edit",videoProduct);
        }
        public JsonResult OnPostEdit(EditVideoProduct command)
        {
            var result = _videoProductApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemoved(long id)
        {
            _videoProductApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            _videoProductApplication.Restore(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetGetVideo(long id)
        {
            var videoProduct = _videoProductApplication.GetVideo(id);
            return Partial("./GetVideo",videoProduct);
        }
    }
}
