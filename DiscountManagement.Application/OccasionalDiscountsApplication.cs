using _0_Framework.Application;
using DiscountManagement.Application.Contract.OccasionalDiscountsApp;
using DiscountManagement.Domain.OccasionalDiscountsAgg;
using System.Collections.Generic;

namespace DiscountManagement.Application
{
    public class OccasionalDiscountsApplication : IOccasionalDiscountsApplication
    {
        private readonly IOccasionalDiscountsRepository _occasionalDiscountsRepository;

        public OccasionalDiscountsApplication(IOccasionalDiscountsRepository occasionalDiscountsRepository)
        {
            _occasionalDiscountsRepository = occasionalDiscountsRepository;
        }

        public OperationResult Create(CreateOccasionalDiscounts command)
        {
            var operation = new OperationResult();
            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();
            var discountProduct = new List<OccasionalDiscountsProduct>();
            if (_occasionalDiscountsRepository.Exists(x => x.Title == command.Title))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            if (command.OccasionalId != null)
                command.OccasionalId.ForEach(productId => discountProduct.Add(new OccasionalDiscountsProduct(productId)));

            var occasionalDiscounts = new OccasionalDiscounts(command.Rate, command.Title, startDate, endDate, discountProduct);
            _occasionalDiscountsRepository.Create(occasionalDiscounts);
            _occasionalDiscountsRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditOccasionalDiscounts command)
        {
            var operation = new OperationResult();
            var occasionalDiscounts = _occasionalDiscountsRepository.GetBy(command.Id);
            var startDate = command.StartDate.ToGeorgianDateTime();
            var endDate = command.EndDate.ToGeorgianDateTime();

            if (occasionalDiscounts == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (_occasionalDiscountsRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Succedded(ApplicationMessages.DuplicatedRecord);
            
            var discountProduct = new List<OccasionalDiscountsProduct>();
            if (command.OccasionalId != null)
                command.OccasionalId.ForEach(productId => discountProduct.Add(new OccasionalDiscountsProduct(productId)));

            occasionalDiscounts.Edit(command.Rate, command.Title, startDate, endDate, discountProduct);
            _occasionalDiscountsRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditOccasionalDiscounts GetEdit(long id)
        {
            return _occasionalDiscountsRepository.GetEdit(id);
        }
        public List<ViewModelOccasionalDiscounts> Search(SearchModelOccasionalDiscounts searchModel)
        {
            return _occasionalDiscountsRepository.Search(searchModel);
        }
    }
}
