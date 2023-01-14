using _0_Framework.Domain;

namespace DiscountManagement.Domain.DiscountAgg
{
    public class Discount : DomainBase<long>
    {
        public long ProductId { get; private set; }
        public double Rate { get; private set; }
        public int DiscountType { get; private set; }
        public bool IsRemoved { get; private set; }

        public Discount(long productId, double rate, int discountType)
        {
            ProductId = productId;
            Rate = rate;
            DiscountType = discountType;
            IsRemoved = false;
        }
        public void Edit(long productId, double rate, int discountType)
        {
            ProductId = productId;
            Rate = rate;
            DiscountType = discountType;
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
