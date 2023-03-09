using _0_Framework.Domain;
using InventoryManagement.Domain.InventoryAgg;
using System.Collections.Generic;

namespace InventoryManagement.Domain.WarrantyAgg
{
    public class Warranty : DomainBase<long>
    {
        public string WarrantyDescription { get; private set; }
        public List<Inventory> Invetorys { get; private set; }
        public Warranty(string warrantyDescription)
        {
            WarrantyDescription = warrantyDescription;
            Invetorys = new List<Inventory>();
        }
        public void Edit(string warrantyDescription)
        {
            WarrantyDescription = warrantyDescription;
        }
    }
}
