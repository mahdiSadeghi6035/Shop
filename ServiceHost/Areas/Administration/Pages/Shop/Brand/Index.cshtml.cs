using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contract.BrandApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Shop.Brand
{
    public class IndexModel : PageModel
    {
        private readonly IBrandApplication _brandApplication;
        public List<ViewModelBrand> Brand { get; set; }
        public SearchModelBrand SearchModel { get; set; }
        public IndexModel(IBrandApplication brandApplication)
        {
            _brandApplication = brandApplication;
        }

        public void OnGet(SearchModelBrand searchModel)
        {
            Brand = _brandApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
        public JsonResult OnPostCreate(CreateBrand command)
        {
            var result = _brandApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var brand = _brandApplication.GetEdit(id);
            return Partial("./Edit", brand);
        }
        public JsonResult OnPostEdit(EditBrand command)
        {

            var result = _brandApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
