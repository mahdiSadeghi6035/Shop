namespace DiscountManagement.Application.Contract.CodeDiscountApp
{
    public class SearchModelDiscount
    {
        public long AccountId { get; set; }
        public long ProductId { get; set; }
        public bool IsRemove { get; set; }
    }
}
