namespace CommentManagement.Domain.CommentScoreAgg
{
    public class CommentScoreOption
    {
        public long Id { get; private set; }
        public string Description { get; private set; }
        public bool Operation { get; private set; }
        public long CommentScoreId { get; private set; }
        public CommentScore CommentScores { get; private set; }
        public CommentScoreOption()
        {
        }
        public CommentScoreOption(string description, bool operation)
        {
            Description = description;
            Operation = operation;
        }

        
    }

}
