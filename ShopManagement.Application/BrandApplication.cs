using _0_Framework.Application;
using ShopManagement.Application.Contract.BrandApp;
using ShopManagement.Domain.BrandAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class BrandApplication : IBrandApplication
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IFileUploader _fileUploader;
        public BrandApplication(IBrandRepository brandRepository, IFileUploader fileUploader)
        {
            _brandRepository = brandRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateBrand command)
        {
            var operation = new OperationResult();
            if (_brandRepository.Exists(x => x.Name == command.Name))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            string path = $"Brand//{slug}";
            var file = _fileUploader.Upload(command.Picture, path);
            var brand = new Brand(command.Name, file, command.PictureAlt, command.PictureTitle, command.Description, slug, command.Keywords, command.MetaDescription);
            _brandRepository.Create(brand);
            _brandRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditBrand command)
        {
            var operation = new OperationResult();
            var brand = _brandRepository.GetBy(command.Id);
            if (brand == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (_brandRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            string path = $"Brand//{slug}";
            var file = _fileUploader.Upload(command.Picture, path);
            brand.Edit(command.Name, file, command.PictureAlt, command.PictureTitle, command.Description, slug, command.Keywords, command.MetaDescription);
            _brandRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditBrand GetEdit(long id)
        {
            return _brandRepository.GetEdit(id);
        }

        public List<ViewModelBrand> GetModelBrands()
        {
            return _brandRepository.GetModelBrands();
        }

        public List<ViewModelBrand> Search(SearchModelBrand searchModel)
        {
            return _brandRepository.Search(searchModel);
        }
    }
}
