using _0_Framework.Application;
using ShopManagement.Application.Contract.GroupingApp;
using ShopManagement.Domain.GroupingAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class GroupingApplication : IGroupingApplication
    {
        private readonly IGroupingRepository _groupingRepository;

        public GroupingApplication(IGroupingRepository groupingRepository)
        {
            _groupingRepository = groupingRepository;
        }

        public OperationResult Create(CreateGrouping command)
        {
            var operation = new OperationResult();
            if (_groupingRepository.Exists(x => x.Name == command.Name))
                return operation.Failde("امکان ثبت رکورد تکراری وجود ندارد.");

            string slug = command.Slug.Slugify();
            var grouping = new Grouping(command.Name, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, slug, command.Keywords, command.MetaDescription);
            _groupingRepository.Create(grouping);
            _groupingRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditGrouping command)
        {
            var operation = new OperationResult();
            var grouping = _groupingRepository.GetBy(command.Id);

            if (grouping == null)
                return operation.Failde("رکورد وارد شده پیدا نشده است.");

            if (_groupingRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failde("امکان ثبت رکورد تکراری وجود ندارد.");

            string slug = command.Slug.Slugify();
            grouping.Edit(command.Name, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, slug, command.Keywords, command.MetaDescription);
            
            _groupingRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditGrouping Exists(long id)
        {
            return _groupingRepository.Exists(id);
        }

        public List<ViewModelGrouping> Search(SearchModelGrouping searchModel)
        {
            return _groupingRepository.Search(searchModel);
        }
    }
}
