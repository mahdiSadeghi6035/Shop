using _0_Framework.Application;
using ShopManagement.Application.Contract.VideoProductApp;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.VideoProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class VideoProductApplication : IVideoProductApplication
    {
        private readonly IVideoProductRepository _videoProductRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository _productRepository;
        public VideoProductApplication(IVideoProductRepository videoProductRepository, IFileUploader fileUploader, IProductRepository productRepository)
        {
            _videoProductRepository = videoProductRepository;
            _fileUploader = fileUploader;
            _productRepository = productRepository;
        }

        public OperationResult Create(CreateVideoProduct command)
        {
            var operation = new OperationResult();
            if (_videoProductRepository.Exists(x => x.ProductId == command.ProductId))
                return operation.Failde(ApplicationMessages.DuplicatedRecord);
            var getProduct = _productRepository.Get(command.ProductId);
            var path = $"{getProduct.Categorys.Groupings.Slug}//{getProduct.Categorys.Slug}//{getProduct.Slug}";
            var file = _fileUploader.Upload(command.Video,path);
            var videoProduct = new VideoProduct(file,command.Type,command.ProductId);
            _videoProductRepository.Create(videoProduct);
            _videoProductRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditVideoProduct command)
        {
            var operation = new OperationResult();
            var videoProduct = _videoProductRepository.Get(command.Id);
            if (videoProduct == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            if (_videoProductRepository.Exists(x => x.ProductId == command.ProductId && x.Id != command.Id))
                return operation.Failde(ApplicationMessages.RecordNotFound);
            var getProduct = _productRepository.Get(command.ProductId);
            var path = $"{getProduct.Categorys.Groupings.Slug}//{getProduct.Categorys.Slug}//{getProduct.Slug}";
            var file = _fileUploader.Upload(command.Video, path);
            videoProduct.Edit(file, command.Type, command.ProductId);
            _videoProductRepository.SaveChanges();
            return operation.Succedded();
            
        }

        public EditVideoProduct GetEdit(long id)
        {
            return _videoProductRepository.GetEdit(id);
        }

        public GetVideo GetVideo(long id)
        {
            return _videoProductRepository.GetVideo(id);
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var videoProduct = _videoProductRepository.GetBy(id);
            if (videoProduct == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            videoProduct.Remove();
            _videoProductRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var videoProduct = _videoProductRepository.GetBy(id);
            if (videoProduct == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            videoProduct.Restore();
            _videoProductRepository.SaveChanges();
            return operation.Succedded();
        }

        public List<ViewModelVideoProduct> Search(SearchModelVideoProduct searchModel)
        {
            return _videoProductRepository.Search(searchModel);
        }
    }
}
