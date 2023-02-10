using ArticleManagement.Application.Contract.VideoApp;
using ArticleManagement.Application.Contract.VideoCategoryApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Articles.Video
{
    public class EditModel : PageModel
    {
        private readonly IVideoCategoryApplication _videoCategoryApplication;
        private readonly IVideoApplication _videoApplication;
        public EditVideo Command { get; set; }
        public SelectList SelectLists { get; set; }
        public EditModel(IVideoCategoryApplication videoCategoryApplication, IVideoApplication videoApplication)
        {
            _videoCategoryApplication = videoCategoryApplication;
            _videoApplication = videoApplication;
        }

        public void OnGet(long id)
        {
            SelectLists = new SelectList(_videoCategoryApplication.GetVideoCategory(), "Id", "Name");
            Command = _videoApplication.GetEdit(id);
        }
        public IActionResult OnPost(EditVideo command)
        {
            var result = _videoApplication.Edit(command);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            return RedirectToPage("./Edit");
        }
    }
}
