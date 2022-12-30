using _0_Framework.Application;
using ShopManagement.Application.Contract.ProductApp;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;

        public ProductApplication(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        public OperationResult Create(CreateProduct command)
        {
            var operation = new OperationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.Specifications, command.BrandId, command.CategoryId, slug, command.MetaDescription, command.Keywords);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditProduct command)
        {
            var operation = new OperationResult();
            var product = _productRepository.GetBy(command.Id);
            if (product == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.Specifications, command.BrandId, command.CategoryId, slug, command.MetaDescription, command.Keywords);
            _productRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditProduct GetEdit(long id)
        {
            return _productRepository.GetEdit(id);
        }

        public List<ViewModelProduct> GetModelProducts()
        {
            return _productRepository.GetModelProducts();
        }

        public List<ViewModelProduct> Search(SearchModelProduct searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}
