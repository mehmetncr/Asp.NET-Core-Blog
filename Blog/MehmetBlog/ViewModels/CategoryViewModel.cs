using EntityLayer.Concrete;

namespace MehmetBlog.ViewModels
{
    public class CategoryViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        //blog sayfasının kategori sayfasona bağlanması için gerekenler
        //bir kategori birden fazla blog içrebilir
        public List<Blog> Blogs { get; set; }
    }
}
