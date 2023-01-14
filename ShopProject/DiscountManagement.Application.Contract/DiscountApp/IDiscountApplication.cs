using _0_Framework.Application;
using System.Collections.Generic;

namespace DiscountManagement.Application.Contract.DiscountApp
{
    public interface IDiscountApplication
    {
        OperationResult Definition(DefinitionDiscount command);
        OperationResult Edit(EditDiscount command);
        OperationResult Remove(long id);
        OperationResult Restore(long id);
        List<ViewModelDiscount> Search(SearchModelDiscount searchModel);
        EditDiscount GetEdit(long id);
    }
}
