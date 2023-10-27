using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class BlogEFramework : GenericRepository<Blog>, IBlogDal
    {
        //Dependency Injection(DI) Constructor Injection yöntemiyle yapılır
        private readonly Context _context;
        public BlogEFramework(Context context) : base(context)
        {
            _context = context;
        }

        public List<Blog> GetAllBlogWithCategory()
        {
            return _context.Blogs.Include(b => b.Category).ToList();
        }

        public Blog GetBlogWithCategoryById(int id)
        {
            return _context.Blogs.Include(b => b.Category).Where(x => x.BlogID == id).FirstOrDefault();
        }
    }
}
