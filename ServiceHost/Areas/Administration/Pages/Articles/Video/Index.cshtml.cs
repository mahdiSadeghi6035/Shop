using ArticleManagement.Application.Contract.VideoApp;
using ArticleManagement.Application.Contract.VideoCategoryApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Articles.Video
{
    public class IndexModel : PageModel
    {
        private readonly IVideoCategoryApplication _videoCategoryApplication;
        private readonly IVideoApplication _videoApplication;
        public List<ViewModelVideo> Video { get; set; }
        public SearchModelVideo SearchModel { get; set; }
        public SelectList SelectLists { get; set; }
        public IndexModel(IVideoCategoryApplication videoCategoryApplication, IVideoApplication videoApplication)
        {
            _videoCategoryApplication = videoCategoryApplication;
            _videoApplication = videoApplication;
        }

        public void OnGet(SearchModelVideo searchModel)
        {
            Video = _videoApplication.Search(searchModel);
            SelectLists = new SelectList(_videoCategoryApplication.GetVideoCategory(), "Id", "Name");
        }
        public IActionResult OnGetVideo(long id)
        {
            var video = _videoApplication.GetVideo(id);
            return Partial("./GetVideo", video);
        }
    }
}
