using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement.Application.Contract.InventoryApp
{
    public class CreateInventory
    {
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public long ProductId { get; set; }
        public string Color { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public double UnitPrice { get; set; }
        [Range(1, double.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public double PurchasePrice { get; set; }
        public bool Status { get; set; }
        public List<ViewModelProduct> ModelProducts { get; set; }
    }
}
