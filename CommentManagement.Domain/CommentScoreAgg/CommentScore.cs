using _0_Framework.Domain;
using System.Collections.Generic;

namespace CommentManagement.Domain.CommentScoreAgg
{
    public class CommentScore : DomainBase<long>
    {
        public long ProductId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public long AccountId { get; private set; }
        public bool IsRemove { get; private set; }
        public List<CommentScoreOption> CommentScoreOptions { get; private set; }

        public CommentScore()
        {
        }

        public CommentScore(long productId, string title, string description, long accountId, List<CommentScoreOption> commentScore)
        {
            ProductId = productId;
            Title = title;
            Description = description;
            AccountId = accountId;
            IsRemove = false;
            CommentScoreOptions = commentScore;
        }
        public void Remove()
        {
            IsRemove = true;
        }
        public void Restore()
        {
            IsRemove = false;
        }
    }

}
