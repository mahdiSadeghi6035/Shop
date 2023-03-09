using _0_Framework.Domain;
using InventoryManagement.Application.Contract.WarrantyApp;
using System.Collections.Generic;

namespace InventoryManagement.Domain.WarrantyAgg
{
    public interface IWarrantyRepository : IRepository<long, Warranty>
    {
        EditWarranty GetEdit(long id);
        List<ViewModelWarranty> GetWarranty();
        List<ViewModelWarranty> GetAllWarranty();
    }
}
