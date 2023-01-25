namespace ShopManagement.Application.Contract.VideoProductApp
{
    public class ViewModelVideoProduct
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public string Video { get; set; }
        public string Type { get; set; }
        public string CreationDate { get; set; }
        public bool IsRemoved { get; set; }
        public string ProductName { get; set; }
    }
}
