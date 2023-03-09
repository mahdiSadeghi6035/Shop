using _0_Framework.Application;
using InventoryManagement.Application.Contract.WarrantyApp;
using InventoryManagement.Domain.WarrantyAgg;
using System.Collections.Generic;

namespace InventoryManagmenet.Application
{
    public class WarrantyApplication : IWarrantyApplication
    {
        private readonly IWarrantyRepository _warrantyRepository;

        public WarrantyApplication(IWarrantyRepository warrantyRepository)
        {
            _warrantyRepository = warrantyRepository;
        }

        public OperationResult Create(CreateWarranty command)
        {
            var operation = new OperationResult();
            if (_warrantyRepository.Exists(x => x.WarrantyDescription == command.WarrantyDescription))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            var warranty = new Warranty(command.WarrantyDescription);
            _warrantyRepository.Create(warranty);
            _warrantyRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditWarranty command)
        {
            var operation = new OperationResult();
            var warranty = _warrantyRepository.GetBy(command.Id);
            if (warranty == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (_warrantyRepository.Exists(x => x.WarrantyDescription == command.WarrantyDescription || command.Id != warranty.Id))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            warranty.Edit(command.WarrantyDescription);
            _warrantyRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ViewModelWarranty> GetAllWarranty()
        {
            return _warrantyRepository.GetAllWarranty();
        }

        public EditWarranty GetEdit(long id)
        {
            return _warrantyRepository.GetEdit(id);
        }

        public List<ViewModelWarranty> GetWarranty()
        {
            return _warrantyRepository.GetWarranty();
        }
    }
}
