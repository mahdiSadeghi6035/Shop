using _0_Framework.Domain;

namespace DiscountManagement.Domain.CodeDiscountAgg
{
    public class CodeDiscount : DomainBase<long>
    {
        public string Code { get; private set; }
        public long ProductId { get; private set; }
        public double DiscountRate { get; private set; }
        public string Description { get; private set; }
        public bool IsRemoved { get; private set; }
        public long AccountId { get; private set; }

        public CodeDiscount(string code, long productId, double discountRate, string description, long accountId)
        {
            Code = code;
            ProductId = productId;
            DiscountRate = discountRate;
            Description = description;
            AccountId = accountId;
            IsRemoved = false;
        }
        public void Edit(string code, long productId, double discountRate, string description, long accountId)
        {
            Code = code;
            ProductId = productId;
            DiscountRate = discountRate;
            Description = description;
            AccountId = accountId;
        }
        public void Remove()
        {
            IsRemoved = true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
