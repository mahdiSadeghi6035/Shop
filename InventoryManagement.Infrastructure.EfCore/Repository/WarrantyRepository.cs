using _0_Framework.Application;
using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contract.WarrantyApp;
using InventoryManagement.Domain.WarrantyAgg;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class WarrantyRepository : RepositoryBase<long, Warranty>, IWarrantyRepository
    {
        private readonly InventoryContext _inventoryContext;

        public WarrantyRepository(InventoryContext inventoryContext) : base(inventoryContext)
        {
            _inventoryContext = inventoryContext;
        }

        public List<ViewModelWarranty> GetAllWarranty()
        {
            return _inventoryContext.Warranty.Select(x => new ViewModelWarranty
            {
                Id = x.Id,
                WarrantyDescription = x.WarrantyDescription
            }).OrderByDescending(x => x.Id).ToList();
        }

        public EditWarranty GetEdit(long id)
        {
            return _inventoryContext.Warranty.Select(x => new EditWarranty
            {
                Id = x.Id,
                WarrantyDescription = x.WarrantyDescription
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<ViewModelWarranty> GetWarranty()
        {
            return _inventoryContext.Warranty.Select(x => new ViewModelWarranty
            {
                Id = x.Id,
                CreateionDate = x.CreationDate.ToFarsi(),
                WarrantyDescription = x.WarrantyDescription
            }).OrderByDescending(x => x.Id).ToList();
        }
    }
}
