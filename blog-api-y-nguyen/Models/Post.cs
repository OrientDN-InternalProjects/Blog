namespace blog_api_y_nguyen.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public int AuthorId { get; set; }
        public virtual Blog? Blog { get; set; }
        public virtual Author? Author { get; set; }

    }
}
