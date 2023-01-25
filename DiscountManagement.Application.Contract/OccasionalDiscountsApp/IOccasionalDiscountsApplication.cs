using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Contract.OccasionalDiscountsApp
{
    public interface IOccasionalDiscountsApplication
    {
        OperationResult Create(CreateOccasionalDiscounts command);
        OperationResult Edit(EditOccasionalDiscounts command);
        EditOccasionalDiscounts GetEdit(long id);
        List<ViewModelOccasionalDiscounts> Search(SearchModelOccasionalDiscounts searchModel);
    }
}
