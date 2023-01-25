using _0_Framework.Application;
using ShopManagement.Application.Contract.CategoryApp;
using ShopManagement.Domain.CategoryAgg;
using ShopManagement.Domain.GroupingAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IGroupingRepository _groupingRepository;
        public CategoryApplication(ICategoryRepository categoryRepository, IFileUploader fileUploader, IGroupingRepository groupingRepository)
        {
            _categoryRepository = categoryRepository;
            _fileUploader = fileUploader;
            _groupingRepository = groupingRepository;
        }

        public OperationResult Create(CreateCategory command)
        {
            var operation = new OperationResult();
            if (_categoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);

            string slug = command.Slug.Slugify();
            string slugGrouping = _groupingRepository.GetSlug(command.GroupingId);
            string filePath = $"{slugGrouping}//{slug}";
            var file = _fileUploader.Upload(command.Picture,filePath);

            var categry = new Category(command.Name, file, command.PictureAlt,command.PictureTitle,command.Description,slug,command.MetaDescription,command.Keywords,command.GroupingId);
            
            _categoryRepository.Create(categry);
            _categoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditCategory command)
        {
            var operation = new OperationResult();
            var category = _categoryRepository.Get(command.Id);

            if (category == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (category == null)
                return operation.Failde(ApplicationMessages.DuplicatedRecord);

            string slug = command.Slug.Slugify();
            string filePath = $"{category.Groupings.Slug}//{slug}";
            var file = _fileUploader.Upload(command.Picture, filePath);

            category.Edit(command.Name, file, command.PictureAlt, command.PictureTitle, command.Description, slug, command.MetaDescription, command.Keywords, command.GroupingId);
            _categoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditCategory Exists(long id)
        {
            return _categoryRepository.Exists(id);
        }

        public List<ViewModelCategory> GetCategory()
        {
            return _categoryRepository.GetCategory();
        }

        public List<ViewModelCategory> Search(SearchModelCategory searchModel)
        {
            return _categoryRepository.Search(searchModel);
        }
    }
}
