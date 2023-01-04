using _0_Framework.Application;
using ShopManagement.Application.Contract.SlideApp;
using ShopManagement.Domain.SlideAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IFileUploader _fileUploader;
        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository = slideRepository;
            _fileUploader = fileUploader;
        }

        public OperationResult Create(CreateSlide command)
        {
            var operation = new OperationResult();
            string file = _fileUploader.Upload(command.Picture, "Slide");
            var slide = new Slide(file, command.PictureAlt, command.PictureTitle, command.Link);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Edit(EditSlide command)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(command.Id);
            if (slide == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            string file = _fileUploader.Upload(command.Picture, "Slide");
            slide.Edit(file, command.PictureAlt, command.PictureTitle, command.Link);
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public EditSlide GetEdit(long id)
        {
            return _slideRepository.GetEdit(id);
        }

        public List<ViewModelSlide> GetSlides()
        {
            return _slideRepository.GetSlides();
        }

        public OperationResult Remove(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(id);
            if (slide == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            slide.Remove();
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }

        public OperationResult Restore(long id)
        {
            var operation = new OperationResult();
            var slide = _slideRepository.GetBy(id);
            if (slide == null)
                return operation.Failde(ApplicationMessages.RecordNotFound);
            slide.Restore();
            _slideRepository.SaveChanges();
            return operation.Succedded();
        }
    }
}
