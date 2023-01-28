using System;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class OperationInventory
    {
        public long Id { get; set; }
        public long OperatorId { get; private set; }
        public long Count { get; private set; }
        public DateTime OperationDate{ get; private set; }
        public long InventoryId { get; private set; }
        public Inventory Inventorys { get; private set; }
        public long CurrentCount { get; private set; }
        public string Description { get; private set; }
        public bool Operation { get; private set; }

        public OperationInventory(long operatorId, long count, long inventoryId, long currentCount, string description, bool operation)
        {
            OperatorId = operatorId;
            Count = count;
            InventoryId = inventoryId;
            CurrentCount = currentCount;
            Description = description;
            Operation = operation;
            OperationDate = DateTime.Now;
        }
    }
}
