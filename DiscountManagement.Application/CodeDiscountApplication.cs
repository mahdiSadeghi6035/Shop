using _0_Framework.Application;
using DiscountManagement.Application.Contract.CodeDiscountApp;
using DiscountManagement.Domain.CodeDiscountAgg;
using System.Collections.Generic;

namespace DiscountManagement.Application
{
    public class CodeDiscountApplication : ICodeDiscountApplication
    {
        private readonly ICodeDiscountRepository _codeDiscountRepository;

        public CodeDiscountApplication(ICodeDiscountRepository codeDiscountRepository)
        {
            _codeDiscountRepository = codeDiscountRepository;
        }

        public OperationResult Create(CreateCodelDiscount command)
        {
            var operation = new OperationResult();
            if (_codeDiscountRepository.Exists(x => x.Code == command.Code))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            var codeDiscount = new CodeDiscount(command.Code,command.ProductId, command.DiscountRate, command.Description, command.AccountId);
            _codeDiscountRepository.Create(codeDiscount);
            _codeDiscountRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditCodeDiscount command)
        {
            var operation = new OperationResult();
            var codeDiscount = _codeDiscountRepository.GetBy(command.Id);
            if (codeDiscount == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (_codeDiscountRepository.Exists(x => x.Code == command.Code || x.Id != command.Id))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            codeDiscount.Edit(command.Code, command.ProductId, command.DiscountRate, command.Description, command.AccountId);
            _codeDiscountRepository.SaveChanges();
            return operation.Succedded();

        }

        public EditCodeDiscount GetEdit(long id)
        {
            return _codeDiscountRepository.GetEdit(id);
        }

        public void Remove(long id)
        {
            var codeDiscount = _codeDiscountRepository.GetBy(id);
            codeDiscount.Remove();
            _codeDiscountRepository.SaveChanges();
        }

        public void Restore(long id)
        {
            var codeDiscount = _codeDiscountRepository.GetBy(id);
            codeDiscount.Restore();
            _codeDiscountRepository.SaveChanges();
        }

        public List<ViewModelCodeDiscount> Search(SearchModelDiscount searchModel)
        {
            return _codeDiscountRepository.Search(searchModel);
        }
    }
}
