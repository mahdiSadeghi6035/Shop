using InventoryManagement.Application.Contract.WarrantyApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Warranty
{
    public class IndexModel : PageModel
    {
        private readonly IWarrantyApplication _warrantyApplication;
        public List<ViewModelWarranty> Warranty { get; set; }
        public IndexModel(IWarrantyApplication warrantyApplication)
        {
            _warrantyApplication = warrantyApplication;
        }
        public void OnGet()
        {
            Warranty = _warrantyApplication.GetWarranty();
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
        public JsonResult OnPostCreate(CreateWarranty command)
        {
            var result = _warrantyApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var warranty = _warrantyApplication.GetEdit(id);
            return Partial("./Edit", warranty);
        }
        public JsonResult OnPostEdit(EditWarranty command)
        {
            var result = _warrantyApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
