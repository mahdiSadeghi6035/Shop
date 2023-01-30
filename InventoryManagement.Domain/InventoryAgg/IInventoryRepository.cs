using _0_Framework.Domain;
using InventoryManagement.Application.Contract.InventoryApp;
using System.Collections.Generic;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository : IRepository<long, Inventory>
    {
        EditInventory GetEdit(long id);
        List<ViewModelInventory> Search(SearchModelInventory searchModel);
        List<InventoryOpereation> Log(long id);
    }
}
