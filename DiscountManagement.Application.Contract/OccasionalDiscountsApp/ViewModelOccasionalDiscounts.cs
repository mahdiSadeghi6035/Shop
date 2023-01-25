using System;
using System.Collections.Generic;

namespace DiscountManagement.Application.Contract.OccasionalDiscountsApp
{
    public class ViewModelOccasionalDiscounts
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public double Rate { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public DateTime StartDateGr { get; set; }
        public DateTime EndDateGr { get; set; }

    }

}
