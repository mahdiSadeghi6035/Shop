using _0_Framework.Application;
using _0_Framework.Infrastructure;
using InventoryManagement.Application.Contract.InventoryApp;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrastructure.EfCore;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Infrastructure.EfCore.Repository
{
    public class InventoryRepository : RepositoryBase<long, Inventory>, IInventoryRepository
    {
        private readonly InventoryContext _context;
        private readonly ShopContext _shopContext;

        public InventoryRepository(InventoryContext context, ShopContext shopContext) : base(context)
        {
            _context = context;
            _shopContext = shopContext;
        }

        public EditInventory GetEdit(long id)
        {
            return _context.Inventory.Select(x => new EditInventory
            {
                Id = x.Id,
                Color = x.Color,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                PurchasePrice = x.PurchasePrice,
                Status = x.Status
            }).FirstOrDefault(x => x.Id == id);
        }

        public List<InventoryOpereation> Log(long id)
        {
            var inventory = _context.Inventory.FirstOrDefault(x => x.Id == id);
            if (inventory == null)
                return null;
            return inventory.InventoryOperation.Select(x => new InventoryOpereation
            {
                Id = x.Id,
                InventoryId = x.InventoryId,
                Count = x.Count,
                CurrentCount = x.CurrentCount,
                Description = x.Description,
                Operation = x.Operation,
                OperationDate = x.OperationDate.ToFarsi(),
                OperatorId = 0,
            }).OrderByDescending(x => x.Id).ToList();
        }

        public List<ViewModelInventory> Search(SearchModelInventory searchModel)
        {
            var query = _context.Inventory.Select(x => new ViewModelInventory
            {
                Id = x.Id,
                Color = x.Color,
                CreationDate = x.CreationDate.ToFarsi(),
                InStock = x.InStock,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice,
                CurrentCount = x.CalculateCurrentCount(),
                Status = x.Status
            });
            var product = _shopContext.Products.Select(x => new { x.Id, x.Name }).ToList();

            query = query.Where(x => x.Status == searchModel.Status);
            if (searchModel.InStock)
                query = query.Where(x => !x.InStock);
            if (searchModel.ProductId > 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            var inventory = query.OrderByDescending(x => x.Id).ToList();

            inventory.ForEach(i => i.Product = product.FirstOrDefault(x => x.Id == i.ProductId)?.Name);

            return inventory;
        }
    }
}
