using _0_Framework.Application;
using ShopManagement.Application.Contract.CategoryApp;
using ShopManagement.Domain.CategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryApplication(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public OperationResult Create(CreateCategory command)
        {
            var operation = new OperationResult();
            if (_categoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            var categry = new Category(command.Name,command.Picture,command.PictureAlt,command.PictureTitle,command.Description,slug,command.MetaDescription,command.Keywords,command.GroupingId);
            _categoryRepository.Create(categry);
            _categoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditCategory command)
        {
            var operation = new OperationResult();
            var category = _categoryRepository.GetBy(command.Id);
            if (category == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (category == null)
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            category.Edit(command.Name, command.Picture, command.PictureAlt, command.PictureTitle, command.Description, slug, command.MetaDescription, command.Keywords, command.GroupingId);
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
