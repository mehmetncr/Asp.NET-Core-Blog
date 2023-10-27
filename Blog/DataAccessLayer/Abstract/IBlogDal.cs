using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> GetAllBlogWithCategory();  //kategori include edilmiş bloglar
        Blog GetBlogWithCategoryById(int id);  //kategori include edilmiş blog
    }
}
