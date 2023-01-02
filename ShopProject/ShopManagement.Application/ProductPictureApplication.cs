using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductPictureApp;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;

        public ProductPictureApplication(IProductPictureRepository productPictureRepository)
        {
            _productPictureRepository = productPictureRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            var productPicture = new ProductPicture(command.Picture, command.PictureAlt, command.PictureTitle, command.ProductId);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.GetBy(command.Id);
            if (productPicture == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            productPicture.Edit(command.Picture, command.PictureAlt, command.PictureTitle, command.ProductId);
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProductPicture GetEdit(long id)
        {
            return _productPictureRepository.GetEdit(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var productPcutre = _productPictureRepository.GetBy(id);
            if (productPcutre == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            productPcutre.Remove();
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var productPcutre = _productPictureRepository.GetBy(id);
            if (productPcutre == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            productPcutre.Restore();
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ViewModelProductPicture> Searches(SearchModelProductPicture searchModel)
        {
            return _productPictureRepository.Searches(searchModel);
        }
    }
}
