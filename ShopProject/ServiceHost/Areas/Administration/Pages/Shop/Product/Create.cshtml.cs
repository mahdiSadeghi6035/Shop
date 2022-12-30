using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.BrandApp;
using ShopManagement.Application.Contract.CategoryApp;
using ShopManagement.Application.Contract.ProductApp;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class CreateModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly ICategoryApplication _categoryApplication;
        private readonly IBrandApplication _brandApplication;
        public CreateProduct Command { get; set; }
        public SelectList SelectListCategory { get; set; }
        public SelectList SelectListBrand { get; set; }
        public CreateModel(IProductApplication productApplication, ICategoryApplication categoryApplication, IBrandApplication brandApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
            _brandApplication = brandApplication;
        }
        public void OnGet()
        {
            SelectListCategory = new SelectList(_categoryApplication.GetCategory(), "Id", "Name");
            SelectListBrand = new SelectList(_brandApplication.GetModelBrands(), "Id", "Name");
        }
        public IActionResult OnPost(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Create");
        }
    }
}
