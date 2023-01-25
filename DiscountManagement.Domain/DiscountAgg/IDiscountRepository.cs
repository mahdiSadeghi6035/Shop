using _0_Framework.Domain;
using DiscountManagement.Application.Contract.DiscountApp;
using System.Collections.Generic;

namespace DiscountManagement.Domain.DiscountAgg
{
    public interface IDiscountRepository : IRepository<long, Discount>
    {
        List<ViewModelDiscount> Search(SearchModelDiscount searchModel);
        EditDiscount GetEdit(long id);
    }
}
