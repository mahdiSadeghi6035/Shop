using _0_Framework.Domain;
using DiscountManagement.Application.Contract.OccasionalDiscountsApp;
using System.Collections.Generic;

namespace DiscountManagement.Domain.OccasionalDiscountsAgg
{
    public interface IOccasionalDiscountsRepository : IRepository<long, OccasionalDiscounts>
    {
        EditOccasionalDiscounts GetEdit(long id);
        List<ViewModelOccasionalDiscounts> Search(SearchModelOccasionalDiscounts searchModel);
    }
}
