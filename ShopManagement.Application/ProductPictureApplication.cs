using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductPictureApp;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository _productRepository;
        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IFileUploader fileUploader, IProductRepository productRepository)
        {
            _productPictureRepository = productPictureRepository;
            _fileUploader = fileUploader;
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateProductPicture command)
        {
            var operation = new OperationResult();
            var product = _productRepository.Get(command.ProductId);
            string path = $"{product.Categorys.Groupings.Slug}//{product.Categorys.Slug}//{product.Slug}";
            var file = _fileUploader.Upload(command.Picture, path);
            var productPicture = new ProductPicture(file, command.PictureAlt, command.PictureTitle, command.ProductId);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProductPicture command)
        {
            var operation = new OperationResult();
            var productPicture = _productPictureRepository.Get(command.Id);
            if (productPicture == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            string path = $"{productPicture.Products.Categorys.Groupings.Slug}//{productPicture.Products.Categorys.Slug}//{productPicture.Products.Slug}";
            var file = _fileUploader.Upload(command.Picture, path);
            productPicture.Edit(file, command.PictureAlt, command.PictureTitle, command.ProductId);
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
