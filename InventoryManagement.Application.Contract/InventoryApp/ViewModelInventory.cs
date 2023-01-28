namespace InventoryManagement.Application.Contract.InventoryApp
{
    public class ViewModelInventory
    {
        public long Id { get; set; }
        public string Product { get; set; }
        public long ProductId { get; set; }
        public string Color { get; set; }
        public double UnitPrice { get; set; }
        public bool InStock { get; set; }
        public string CreationDate { get; set; }
        public long CurrentCount { get; set; }
    }
}
