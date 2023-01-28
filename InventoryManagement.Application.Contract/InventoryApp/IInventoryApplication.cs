using _0_Framework.Application;
using System.Collections.Generic;

namespace InventoryManagement.Application.Contract.InventoryApp
{
    public interface IInventoryApplication
    {
        OperationResult Create(CreateInventory command);
        OperationResult Edit(EditInventory command);
        EditInventory GetEdit(long id);
        List<ViewModelInventory> Search(SearchModelInventory searchModel);
        OperationResult Increase(OperationInventoryModel command);
        OperationResult Reduce(OperationInventoryModel command);
        OperationResult Reduce(List<OperationInventoryModel> command);
    }
}
