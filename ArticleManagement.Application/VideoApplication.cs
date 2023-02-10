using _0_Framework.Application;
using ArticleManagement.Application.Contract.VideoApp;
using ArticleManagement.Domain.VideoAgg;
using ArticleManagement.Domain.VideoCategoryAgg;
using System.Collections.Generic;

namespace ArticleManagement.Application
{
    public class VideoApplication : IVideoApplication
    {
        private readonly IVideoRepository _videoRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IVideoCategoryRepository _videoCategoryRepository;
        public VideoApplication(IVideoRepository videoRepository, IFileUploader fileUploader, IVideoCategoryRepository videoCategoryRepository)
        {
            _videoRepository = videoRepository;
            _fileUploader = fileUploader;
            _videoCategoryRepository = videoCategoryRepository;
        }

        public OperationResult Create(CreateVideo command)
        {
            var operation = new OperationResult();
            if (_videoRepository.Exists(x => x.Name == command.Name))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            string slugVideCategory = _videoCategoryRepository.GetSlug(command.VideoCategoryId);
            string path = $"{slugVideCategory}//{slug}";
            var pathVideo = _fileUploader.Upload(command.Videos, path);
            var pathPicture = _fileUploader.Upload(command.Picture, path);
            var video = new Video(command.Name, command.Description, pathPicture, command.PictureAlt, command.PictureTitle, pathVideo, command.Type, command.VideoCategoryId, slug, command.KeyWords, command.MetaDescription);
            _videoRepository.Create(video);
            _videoRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditVideo command)
        {
            var operation = new OperationResult();
            var video = _videoRepository.GetVideo(command.Id);
            if (video == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (_videoRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            string slug = command.Slug.Slugify();
            string slugVideCategory = video.VideoCategory.Slug;
            string path = $"{slugVideCategory}//{slug}";
            var pathVideo = _fileUploader.Upload(command.Videos, path);
            var pathPicture = _fileUploader.Upload(command.Picture, path);
            video.Edit(command.Name, command.Description, pathPicture, command.PictureAlt, command.PictureTitle, pathVideo, command.Type, command.VideoCategoryId, slug, command.KeyWords, command.MetaDescription);
            _videoRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditVideo GetEdit(long id)
        {
            return _videoRepository.GetEdit(id);
        }

        public List<ViewModelVideo> Search(SearchModelVideo searchModel)
        {
            return _videoRepository.Search(searchModel);
        }
    }
}
