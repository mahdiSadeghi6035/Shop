using _0_Framework.Application;
using InventoryManagement.Application.Contract.InventoryApp;
using InventoryManagement.Domain.InventoryAgg;
using System.Collections.Generic;

namespace InventoryManagmenet.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        private readonly IInventoryRepository _inventoryRepository;

        public InventoryApplication(IInventoryRepository inventoryRepository)
        {
            _inventoryRepository = inventoryRepository;
        }

        public OperationResult Create(CreateInventory command)
        {
            var operation = new OperationResult();
            if (_inventoryRepository.Exists(x => x.Color == command.Color))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            var inventory = new Inventory(command.ProductId, command.Color, command.UnitPrice);
            _inventoryRepository.Create(inventory);
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditInventory command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.GetBy(command.Id);
            if (inventory == null)
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            if (_inventoryRepository.Exists(x => x.Color == command.Color && x.Id != command.Id))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            inventory.Edit(command.ProductId, command.Color, command.UnitPrice);
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditInventory GetEdit(long id)
        {
            return _inventoryRepository.GetEdit(id);
        }

        public OperationResult Increase(OperationInventoryModel command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.GetBy(command.InvnetoryId);
            if (inventory == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            inventory.Increase(command.Count, command.Description, 0);
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Reduce(OperationInventoryModel command)
        {
            var operation = new OperationResult();
            var inventory = _inventoryRepository.GetBy(command.InvnetoryId);
            if (inventory == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            inventory.Reduce(command.Count, command.Description, 0);
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Reduce(List<OperationInventoryModel> command)
        {
            var operation = new OperationResult();
            foreach (var item in command)
            {
                var inventory = _inventoryRepository.GetBy(item.InvnetoryId);
                if (inventory == null)
                    return operation.Failde(ApplicationMessages.RecordNotFound);
                inventory.Reduce(item.Count, item.Description, 0);
            }
            _inventoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ViewModelInventory> Search(SearchModelInventory searchModel)
        {
            return _inventoryRepository.Search(searchModel);
        }
    }
}
