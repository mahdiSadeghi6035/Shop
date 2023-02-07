using _0_Framework.Application;
using ArticleManagement.Application.Contract.VideoCategoryApp;
using ArticleManagement.Domain.VideoCategoryAgg;
using System.Collections.Generic;

namespace ArticleManagement.Application
{
    public class VideoCategoryApplication : IVideoCategoryApplication
    {
        private readonly IVideoCategoryRepository _videoCategoryRepository;

        public VideoCategoryApplication(IVideoCategoryRepository videoCategoryRepository)
        {
            _videoCategoryRepository = videoCategoryRepository;
        }

        public OperationResult Create(CreateVideoCategory command)
        {
            var operation = new OperationResult();
            if (_videoCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            var videoCategory = new VideoCategory(command.Name, slug, command.KeyWords, command.MetaDescription);
            _videoCategoryRepository.Create(videoCategory);
            _videoCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditVideoCategory command)
        {
            var operation = new OperationResult();
            var videoCategory = _videoCategoryRepository.GetBy(command.Id);
            if (videoCategory == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (_videoCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            videoCategory.Edit(command.Name, slug, command.KeyWords, command.MetaDescription);
            _videoCategoryRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditVideoCategory GetEdit(long id)
        {
            return _videoCategoryRepository.GetEdit(id);
        }

        public List<ViewModelVideoCategory> GetVideoCategory()
        {
            return _videoCategoryRepository.GetVideoCategory();
        }

        public List<ViewModelVideoCategory> Search(SearchModelVideoCategory searchModel)
        {
            return _videoCategoryRepository.Search(searchModel);
        }
    }
}
