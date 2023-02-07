using ArticleManagement.Application.Contract.VideoCategoryApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Articles.VideoCategory
{
    public class IndexModel : PageModel
    {
        private readonly IVideoCategoryApplication _videoCategoryApplication;
        public SearchModelVideoCategory SearchModel { get; set; }
        public List<ViewModelVideoCategory> VideoCategory{ get; set; }
        public IndexModel(IVideoCategoryApplication videoCategoryApplication)
        {
            _videoCategoryApplication = videoCategoryApplication;
        }

        public void OnGet(SearchModelVideoCategory searchModel)
        {
            VideoCategory = _videoCategoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            return Partial("./Create");
        }
        public JsonResult OnPostCreate(CreateVideoCategory command)
        {
            var result = _videoCategoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var videoCategory = _videoCategoryApplication.GetEdit(id);
            return Partial("./Edit", videoCategory);
        }
        public JsonResult OnPostEdit(EditVideoCategory command)
        {
            var reuslt = _videoCategoryApplication.Edit(command);
            return new JsonResult(reuslt);
        }
    }
}
