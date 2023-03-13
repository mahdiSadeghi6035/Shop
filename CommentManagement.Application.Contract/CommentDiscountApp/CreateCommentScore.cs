using System.Collections.Generic;

namespace CommentManagement.Application.Contract.CommentDiscountApp
{
    public class CreateCommentScore
    {
        public long ProductId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public long AccountId { get; set; }
        public List<CreateCommentScoreOption> Positive { get; set; }
        public List<CreateCommentScoreOption> Minus { get; set; }
    }

}
