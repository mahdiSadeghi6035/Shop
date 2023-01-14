namespace DiscountManagement.Application.Contract.DiscountApp
{
    public class ViewModelDiscount
    {
        public long Id { get; set; }
        public long ProductId { get; set; }
        public double Rate { get; set; }
        public int DiscountType { get; set; }
        public string DiscountTypeName { get; set; }
        public bool IsRemoved { get; set; }
        public string CreateionDate { get; set; }
        public string ProductName { get; set; }
    }
}
