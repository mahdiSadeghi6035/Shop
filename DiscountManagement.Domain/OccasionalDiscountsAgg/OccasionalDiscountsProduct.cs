namespace DiscountManagement.Domain.OccasionalDiscountsAgg
{
    public class OccasionalDiscountsProduct
    {
        public long Id { get; private set; }
        public long ProductId { get; private set; }
        public long OccasionalDiscountsId { get; private set; }
        public OccasionalDiscounts OccasionalDiscounts { get; private set; }

        public OccasionalDiscountsProduct()
        {
        }

        public OccasionalDiscountsProduct(long productId)
        {
            ProductId = productId;
        }
    }

}
