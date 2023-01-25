using System.Collections.Generic;

namespace DiscountManagement.Application.Contract.OccasionalDiscountsApp
{
    public class EditOccasionalDiscounts : CreateOccasionalDiscounts
    {
        public long Id { get; set; }
        public List<ProductDiscountModel>  ProductDiscount{ get; set; }
    }

}
