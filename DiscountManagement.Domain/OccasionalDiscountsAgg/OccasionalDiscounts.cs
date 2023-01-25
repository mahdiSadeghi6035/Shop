using _0_Framework.Domain;
using System;
using System.Collections.Generic;

namespace DiscountManagement.Domain.OccasionalDiscountsAgg
{
    public class OccasionalDiscounts : DomainBase<long>
    {
        public double Rate { get; private set; }
        public string Title { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public List<OccasionalDiscountsProduct> DiscountsProducts { get; private set; }

        public OccasionalDiscounts()
        {
        }

        public OccasionalDiscounts(double rate, string title, DateTime startDate, DateTime endDate, List<OccasionalDiscountsProduct> discountsProducts)
        {
            Rate = rate;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            DiscountsProducts = discountsProducts;
        }
        public void Edit(double rate, string title, DateTime startDate, DateTime endDate, List<OccasionalDiscountsProduct> discountsProducts)
        {
            Rate = rate;
            Title = title;
            StartDate = startDate;
            EndDate = endDate;
            DiscountsProducts = discountsProducts;
        }
    }

}
