namespace InventoryManagementApplication.Conteact.InventoryApp
{
    public class ViewModelInvneotry
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Product { get; set; }
        public string Color { get; set; }
        public bool InStock { get; set; }
        public double UnitPrice { get; set; }
        public string CreationDate { get; set; }
    }
}
