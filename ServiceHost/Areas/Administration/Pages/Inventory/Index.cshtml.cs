using InventoryManagement.Application.Contract.InventoryApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _inventoryApplication;
        public List<ViewModelInventory> Inventory { get; set; }
        public SelectList SelectLists { get; set; }
        public SearchModelInventory SearchModel { get; set; }
        public IndexModel(IProductApplication productApplication, IInventoryApplication inventoryApplication)
        {
            _productApplication = productApplication;
            _inventoryApplication = inventoryApplication;
        }

        public void OnGet(SearchModelInventory searchModel)
        {
            Inventory = _inventoryApplication.Search(searchModel);
            SelectLists = new SelectList(_productApplication.GetModelProducts(), "Id", "Name");
        }
        public IActionResult OnGetCreate()
        {
            var inventory = new CreateInventory()
            {
                ModelProducts = _productApplication.GetModelProducts()
            };
            return Partial("./Create",inventory);
        }
        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _inventoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var inventory = _inventoryApplication.GetEdit(id);
            inventory.ModelProducts = _productApplication.GetModelProducts();
            return Partial("./Edit",inventory);
        }
        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _inventoryApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetReduce(long id)
        {
            var inventory = new OperationInventoryModel()
            {
                InventoryId = id
            };
            return Partial("./Reduce", inventory);
        }
        public JsonResult OnPostReduce(OperationInventoryModel command)
        {
            var result = _inventoryApplication.Reduce(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetIncrease(long id)
        {
            var inventory = new OperationInventoryModel()
            {
                InventoryId = id
            };
            return Partial("./Increase",inventory);
        }
        public JsonResult OnPostIncrease(OperationInventoryModel command)
        {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetLog(long id)
        {
            var operation = _inventoryApplication.Log(id);
            return Partial("./OperationLog", operation);
        }
    }
}
