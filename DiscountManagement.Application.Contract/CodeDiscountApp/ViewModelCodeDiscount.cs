namespace DiscountManagement.Application.Contract.CodeDiscountApp
{
    public class ViewModelCodeDiscount
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string Account { get; set; }
        public long AccountId { get; set; }
        public double DiscountRate { get; set; }
        public string CreateionDate { get; set; }
        public bool IsRemove { get; set; }
    }
}
