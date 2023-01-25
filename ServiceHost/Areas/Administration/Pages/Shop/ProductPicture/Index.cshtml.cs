using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductApp;
using ShopManagement.Application.Contract.ProductPictureApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPicture
{
    public class IndexModel : PageModel
    {
        private readonly IProductPictureApplication _productPictureApplication;
        private readonly IProductApplication _productApplication;
        public List<ViewModelProductPicture> ProductPicture { get; set; }
        public SearchModelProductPicture SearchModel { get; set; }
        public SelectList SelectLists { get; set; }
        public IndexModel(IProductPictureApplication productPictureApplication, IProductApplication productApplication)
        {
            _productPictureApplication = productPictureApplication;
            _productApplication = productApplication;
        }

        public void OnGet(SearchModelProductPicture searchModel)
        {
            ProductPicture = _productPictureApplication.Searches(searchModel);
            SelectLists = new SelectList(_productApplication.GetModelProducts(), "Id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var productPicture = new CreateProductPicture()
            {
                ModelProducts = _productApplication.GetModelProducts()
            };
            return Partial("./Create", productPicture);
        }
        public JsonResult OnPostCreate(CreateProductPicture command)
        {
            var result = _productPictureApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var productPicture = _productPictureApplication.GetEdit(id);
            productPicture.ModelProducts = _productApplication.GetModelProducts();
            return Partial("./Edit", productPicture);
        }
        public JsonResult OnPostEdit(EditProductPicture command)
        {
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemoved(long id)
        {
            _productPictureApplication.Remove(id);
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetRestore(long id)
        {
            _productPictureApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
