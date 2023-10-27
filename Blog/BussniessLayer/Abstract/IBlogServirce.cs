using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussniessLayer.Abstract
{
    public interface IBlogServirce : IGenericService<Blog>
    {

        public List<Blog> AllBlogWithCategory();   //kategorilerle beraber bloglar
        public Blog BlogWithCategoryById(int id);
        List<Blog> TrueGetListAll();   //statusu true olan bloglar
        public List<Blog> GetListAllWithCategoryByCategory(int? id);
        Blog TrueGetById(int id);
        public List<Blog> GetListSeachBlog(string name);

    }
}
