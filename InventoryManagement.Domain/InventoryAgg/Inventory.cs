using _0_Framework.Domain;
using InventoryManagement.Domain.WarrantyAgg;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory : DomainBase<long>
    {
        public long ProductId { get; private set; }
        public string Color { get; private set; }
        public bool InStock { get; private set; }
        public double UnitPrice { get; private set; }
        public double PurchasePrice { get; private set; }
        public bool Status { get; private set; }
        public long WarrantyId { get; private set; }
        public Warranty Warranty{ get; private set; }
        public List<OperationInventory> InventoryOperation { get; private set; }

        public Inventory(long productId, string color, double unitPrice, double purchasePrice, bool status, long warrantyId)
        {
            ProductId = productId;
            Color = color;
            UnitPrice = unitPrice;
            InventoryOperation = new List<OperationInventory>();
            PurchasePrice = purchasePrice;
            Status = status;
            WarrantyId = warrantyId;
        }
        public void Edit(long productId, string color, double unitPrice, double purchasePrice, bool status, long warrantyId)
        {
            ProductId = productId;
            Color = color;
            UnitPrice = unitPrice;
            PurchasePrice = purchasePrice;
            Status = status;
            WarrantyId = warrantyId;

        }
    public long CalculateCurrentCount()
        {
            var plus = InventoryOperation.Where(x => x.Operation).Sum(x => x.Count);
            var minus = InventoryOperation.Where(x => !x.Operation).Sum(x => x.Count);
            return plus - minus;
        }
        public void Increase(long count, string desciption, long operatorId)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new OperationInventory(operatorId, count, Id, currentCount, desciption, true);
            InventoryOperation.Add(operation);
            InStock = currentCount > 0;
        }
        public void Reduce(long count, string desciption, long operatorId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new OperationInventory(operatorId, count, Id, currentCount, desciption, false);
            InventoryOperation.Add(operation);
            InStock = currentCount > 0;
        }
    }
}
