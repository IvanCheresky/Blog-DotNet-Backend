namespace DotNet_Backend.Data.Contracts.Requests
{
    public class PostRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}