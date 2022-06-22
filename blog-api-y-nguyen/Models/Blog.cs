namespace blog_api_y_nguyen.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual List<Post>? Posts { get; set; }
    }
}
