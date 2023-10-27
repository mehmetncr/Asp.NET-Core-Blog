using EntityLayer.Concrete;

namespace MehmetBlog.ViewModels
{
    public class BlogViewModel
    {
        public int BlogID { get; set; }

        public string BlogTitle { get; set; }
   
        public string BlogContent { get; set; }
        public string BlogTags { get; set; }
        public string BlogImage { get; set; }
        public string BlogThumbnailImage { get; set; }
        public DateTime BlogCreateDate { get; set; }

        public bool BlogStatus { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }



        public List<Comment> Comments { get; set; }
    }
}
