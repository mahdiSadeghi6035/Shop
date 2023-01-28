using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;

namespace InventoryManagementApplication.Conteact.InventoryApp
{
    public class CreateInvneotory
    {
        public long ProductId { get; set; }
        public string Color { get; set; }
        public bool InStock { get; set; }
        public double UnitPrice { get; set; }
        public List<ViewModelProduct> ModelProducts { get; set; }
    }
}
