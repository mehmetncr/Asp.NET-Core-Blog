using BussniessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BussniessLayer.Contrete
{
    public class BlogManager : GenericManager<Blog>, IBlogServirce
    {
        //Dependency Injection(DI) Constructor Injection yöntemiyle yapılır
        private readonly IBlogDal _blogDal;
        public BlogManager(IGenericDal<Blog> genericDal, IBlogDal blogDal) : base(genericDal)
        {
            _blogDal = blogDal;  //blog dal bağlanıtsı için Constructor
        }

        public List<Blog> AllBlogWithCategory()    //kategorilerdahil tüm bloglar
        {
            return _blogDal.GetAllBlogWithCategory();
        }

        public Blog BlogWithCategoryById(int id)  //kategoriler dahil id ye göre bloglar
        {
            return _blogDal.GetBlogWithCategoryById(id);
        }

        public Blog TrueGetById(int id)   //statusu true olan id ye blog
        {
            if (_blogDal.GetBlogWithCategoryById(id).BlogStatus == true)
            {
                return _blogDal.GetBlogWithCategoryById(id);
            }
            else
            {
                return null; //idsi eşleşen blog statusu false ise null dönüyor
            }

        }

        public List<Blog> TrueGetListAll()  //statusu true olan tüm bloglar
        {
            List<Blog> trueBlogs = new List<Blog>();    //yeni boş bir blog listesi
            List<Blog> blogs = _blogDal.GetAllBlogWithCategory();   //tüm bloglar çekilir
            foreach (var item in blogs)
            {
                if (item.BlogStatus == true)  //statusu true olanları yeni listeye ekler
                {
                    trueBlogs.Add(item);
                }
            }
            if (trueBlogs.Count() > 0)   //eğer statusu true olan blog bulunursa döndürülür 
            {
                return trueBlogs;
            }
            else
            {
                return null;   //bulunamazsa null döner
            }
        }
        public List<Blog> GetListAllWithCategoryByCategory(int? id)     //kategoriye göre blogları listelemek için kategori id'sine göre bloglar
        {
            return _blogDal.GetAllBlogWithCategory().Where(x => x.CategoryID == id).ToList();  //kategori dahil kategorisine göre bloglar
        }
        public List<Blog> GetListSeachBlog(string name)
        {
            return TrueGetListAll().Where(x => x.BlogContent.ToLower().Contains(name.ToLower())).ToList();
        }
    }
}
