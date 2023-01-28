using _0_Framework.Application;
using InventoryManagementApplication.Conteact.InventoryApp;
using System.Collections.Generic;

namespace InventoryManagementApplication.Conteact.InventoryApp
{
    public interface IInvneotryApplication
    {
        OperationResult Create(CreateInvneotory command);
        OperationResult Edit(EditInventory command);
        OperationResult Reuce(OperationModel command);
        OperationResult Reduce(List<OperationModel> command);
        OperationResult Increase(OperationResult command);
        EditInventory GetEdit(long id);
        List<ViewModelInvneotry> Search(SearchModelInventory searchModel);
    }
}
