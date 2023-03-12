namespace CommentManagement.Application.Contract.CommentApp
{
    public class CreateComment
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public long Type { get; set; }
        public long ParentId { get; set; }
        public long OwnerId { get; set; }
    }
}
