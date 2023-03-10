using _0_Framework.Domain;
using DiscountManagement.Application.Contract.CodeDiscountApp;
using System.Collections.Generic;

namespace DiscountManagement.Domain.CodeDiscountAgg
{
    public interface ICodeDiscountRepository : IRepository<long, CodeDiscount>
    {
        EditCodeDiscount GetEdit(long id);
        List<ViewModelCodeDiscount> Search(SearchModelDiscount searchModel);
    }
}
