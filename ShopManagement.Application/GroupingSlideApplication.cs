using _0_Framework.Application;
using ShopManagement.Application.Contract.GroupingSlideAgg;
using ShopManagement.Domain.GroupingAgg;
using ShopManagement.Domain.GroupingSlideAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class GroupingSlideApplication : IGroupingSlideApplication
    {
        private readonly IGroupingSlideRepository _groupingSlideRepository;
        private readonly IGroupingRepository _groupingRepository;
        private readonly IFileUploader _fileUploader;
        public GroupingSlideApplication(IGroupingSlideRepository groupingSlideRepository, IFileUploader fileUploader, IGroupingRepository groupingRepository)
        {
            _groupingSlideRepository = groupingSlideRepository;
            _fileUploader = fileUploader;
            _groupingRepository = groupingRepository;
        }

        public OperationResult Create(CreateGroupingSlide command)
        {
            var operation = new OperationResult();
            var groupingPath = _groupingRepository.GetSlug(command.GroupingId);
            string file = _fileUploader.Upload(command.Picture, groupingPath);
            var grouping = new GroupingSlide(file, command.PictureAlt, command.PictureTitle, command.Link, command.GroupingId);
            _groupingSlideRepository.Create(grouping);
            _groupingSlideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditGroupingSlide command)
        {
            var operation = new OperationResult();
            var groupingSlide = _groupingSlideRepository.Get(command.Id);
            if (groupingSlide == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            var file = _fileUploader.Upload(command.Picture, groupingSlide.Groupings.Slug);
            groupingSlide.Edit(file, command.PictureAlt, command.PictureTitle, command.Link, command.GroupingId);
            _groupingRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditGroupingSlide GetEdit(long id)
        {
            return _groupingSlideRepository.GetEdit(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var groupingSlide = _groupingSlideRepository.GetBy(id);
            if (groupingSlide == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            groupingSlide.Remove();
            _groupingSlideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var groupingSlide = _groupingSlideRepository.GetBy(id);
            if (groupingSlide == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            groupingSlide.Restore();
            _groupingSlideRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ViewModelGroupingSlide> Search(SearchModelGroupingSlide searchModel)
        {
            return _groupingSlideRepository.Search(searchModel);
        }
    }
}
