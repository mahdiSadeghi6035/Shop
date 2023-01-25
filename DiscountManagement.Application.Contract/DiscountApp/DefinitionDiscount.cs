using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductApp;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contract.DiscountApp
{
    public class DefinitionDiscount
    {
        [Range(1, long.MaxValue, ErrorMessage = ValidationMessage.RequiredMessage)]
        public long ProductId { get; set; }
        [Range(1, 100, ErrorMessage = ValidationMessage.RequiredMessage)]
        public double Rate { get; set; }
        [Range(0, 2, ErrorMessage = ValidationMessage.RequiredMessage)]
        public int DiscountType { get; set; }
        public List<ViewModelProduct> ModelProducts { get; set; }
        public List<DiscountType> DiscountsTypeModel { get; set; }
    }
}
