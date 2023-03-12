using _0_Framework.Application;
using CommentManagement.Application.Contract.CommentApp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace ServiceHost.Areas.Administration.Pages.Comments.Comment
{
    public class IndexModel : PageModel
    {
        private readonly ICommentApplication _commentApplication;

        public List<ViewModelComment> Comment { get; set; }
        public SearchModelComment SearchModel { get; set; }
        public IndexModel(ICommentApplication commentApplication)
        {
            _commentApplication = commentApplication;
        }

        public void OnGet(SearchModelComment searchModel)
        {
            Comment = _commentApplication.Search(searchModel);
            
        }
        public IActionResult OnGetShowReply(long id)
        {
            var comment = new CreateComment()
            {
                ParentId = id
            };
            return Partial("./GetReply", comment);
        }
        public JsonResult OnPostReply(CreateComment command)
        {
            var result = _commentApplication.Create(command.ParentId,command);
            return new JsonResult(result);
        }
        public IActionResult OnGetCancled(long id)
        {
            _commentApplication.Cancled(id);
            return RedirectToPage("./Index");
        }
        
        public IActionResult OnGetShowComment(long id)
        {
            var comment = _commentApplication.GetReplyComment(id);
            return Partial("./ShowComment", comment);
        }
    }
}
