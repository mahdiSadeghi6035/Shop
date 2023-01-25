using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Contract.OccasionalDiscountsApp
{
    public class CreateOccasionalDiscounts
    {
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public double Rate { get;  set; }
        [Required(ErrorMessage = ValidationMessage.RequiredMessage)]
        public string Title { get;  set; }
        public string StartDate { get;  set; }
        public string EndDate { get;  set; }
        public List<long> OccasionalId { get; set; }
    }

}
