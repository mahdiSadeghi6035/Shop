using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.BrandApp;
using ShopManagement.Application.Contract.CategoryApp;
using ShopManagement.Application.Contract.ProductApp;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class EditModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly ICategoryApplication _categoryApplication;
        private readonly IBrandApplication _brandApplication;
        public EditProduct Command { get; set; }
        public SelectList SelectListCategory { get; set; }
        public SelectList SelectListBrand { get; set; }
        public EditModel(IProductApplication productApplication, ICategoryApplication categoryApplication, IBrandApplication brandApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
            _brandApplication = brandApplication;
        }
        public void OnGet(long id)
        {
            Command = _productApplication.GetEdit(id);
            SelectListCategory = new SelectList(_categoryApplication.GetCategory(), "Id", "Name");
            SelectListBrand = new SelectList(_brandApplication.GetModelBrands(), "Id", "Name");
        }
        public IActionResult OnPost(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            return RedirectToPage();
        }
    }
}
