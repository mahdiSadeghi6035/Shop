using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.BrandApp;
using ShopManagement.Application.Contract.CategoryApp;
using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Product
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly ICategoryApplication _categoryApplication;
        private readonly IBrandApplication _brandApplication;
        public List<ViewModelProduct> Product { get; set; }
        public SearchModelProduct SearchModel { get; set; }
        public SelectList SelectListCategory { get; set; }
        public SelectList SelectListBrand { get; set; }

        public IndexModel(IProductApplication productApplication, ICategoryApplication categoryApplication, IBrandApplication brandApplication)
        {
            _productApplication = productApplication;
            _categoryApplication = categoryApplication;
            _brandApplication = brandApplication;
        }

        public void OnGet(SearchModelProduct searchModel)
        {
            Product = _productApplication.Search(searchModel);
            SelectListCategory = new SelectList(_categoryApplication.GetCategory(), "Id", "Name");
            SelectListBrand = new SelectList(_brandApplication.GetModelBrands(), "Id", "Name");
        }
    }
}
