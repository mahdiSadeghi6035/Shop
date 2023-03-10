using _0_Framework.Application;
using System.Collections.Generic;

namespace DiscountManagement.Application.Contract.CodeDiscountApp
{
    public interface ICodeDiscountApplication
    {
        OperationResult Create(CreateCodelDiscount command);
        OperationResult Edit(EditCodeDiscount command);
        void Remove(long id);
        void Restore(long id);
        EditCodeDiscount GetEdit(long id);
        List<ViewModelCodeDiscount> Search(SearchModelDiscount searchModel);
    }
}
