using _0_Framework.Application;
using System.Collections.Generic;

namespace InventoryManagement.Application.Contract.WarrantyApp
{
    public interface IWarrantyApplication
    {
        OperationResult Create(CreateWarranty command);
        OperationResult Edit(EditWarranty command);
        EditWarranty GetEdit(long id);
        List<ViewModelWarranty> GetWarranty();
        List<ViewModelWarranty> GetAllWarranty();
    }
}
