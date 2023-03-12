namespace CommentManagement.Application.Contract.CommentApp
{
    public class SearchModelComment
    {
        public long Type { get; set; }
        public string Name { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCancled { get; set; }
    }
}
