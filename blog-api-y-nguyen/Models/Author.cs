namespace blog_api_y_nguyen.Models
{
    public class Blog
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual List<Post>? Posts { get; set; }
    }
}
