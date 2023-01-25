using _0_Framework.Application;
using DiscountManagement.Application.Contract.DiscountApp;
using DiscountManagement.Domain.DiscountAgg;
using System.Collections.Generic;

namespace DiscountManagement.Application
{
    public class DiscountApplication : IDiscountApplication
    {
        private readonly IDiscountRepository _discountRepository;

        public DiscountApplication(IDiscountRepository discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public OperationResult Definition(DefinitionDiscount command)
        {
            var operation = new OperationResult();
            if (_discountRepository.Exists(x => x.ProductId == command.ProductId))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            var discount = new Discount(command.ProductId, command.Rate, command.DiscountType);
            _discountRepository.Create(discount);
            _discountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditDiscount command)
        {
            var operationResult = new OperationResult();
            var discount = _discountRepository.GetBy(command.Id);
            if (discount == null)
                return operationResult.Failde(ApplicationMessages.RecordNotFound);
            if (_discountRepository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return operationResult.Failde(ApplicationMessages.DuplicatedRecord);
            discount.Edit(command.ProductId, command.Rate, command.DiscountType);
            _discountRepository.SaveChanges();
            return operationResult.Succedded();
        }

        public EditDiscount GetEdit(long id)
        {
            return _discountRepository.GetEdit(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var discount = _discountRepository.GetBy(id);
            if (discount == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            discount.Remove();
            _discountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var discount = _discountRepository.GetBy(id);
            if (discount == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            discount.Restore();
            _discountRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ViewModelDiscount> Search(SearchModelDiscount searchModel)
        {
            return _discountRepository.Search(searchModel);
        }
    }
}
