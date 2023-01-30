namespace InventoryManagement.Application.Contract.InventoryApp
{
    public class InventoryOpereation
    {
        public long Id { get; set; }
        public long OperatorId { get;  set; }
        public long Count { get;  set; }
        public string OperationDate { get;  set; }
        public long InventoryId { get;  set; }
        public long CurrentCount { get;  set; }
        public string Description { get;  set; }
        public bool Operation { get;  set; }
    }
}
