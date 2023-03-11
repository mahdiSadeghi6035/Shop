using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;

namespace DiscountManagement.Application.Contract.CodeDiscountApp
{
    public class CreateCodelDiscount
    {
        public string Code { get; set; }
        public long ProductId { get; set; }
        public double DiscountRate { get; set; }
        public string Description { get; set; }
        public long AccountId { get; set; }
        public List<ViewModelProduct> ModelProducts{ get; set; }
    }
}
