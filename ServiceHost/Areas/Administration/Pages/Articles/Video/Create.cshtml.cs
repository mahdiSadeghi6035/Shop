using ArticleManagement.Application.Contract.VideoApp;
using ArticleManagement.Application.Contract.VideoCategoryApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Articles.Video
{
    public class CreateModel : PageModel
    {
        private readonly IVideoCategoryApplication _videoCategoryApplication;
        private readonly IVideoApplication _videoApplication;
        public CreateVideo Command { get; set; }
        public SelectList SelectLists { get; set; }
        public CreateModel(IVideoCategoryApplication videoCategoryApplication, IVideoApplication videoApplication)
        {
            _videoCategoryApplication = videoCategoryApplication;
            _videoApplication = videoApplication;
        }

        public void OnGet()
        {
            SelectLists = new SelectList(_videoCategoryApplication.GetVideoCategory(), "Id", "Name");
        }
        public IActionResult OnPost(CreateVideo command)
        {
            var result = _videoApplication.Create(command);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Edit");
        }
    }
}
