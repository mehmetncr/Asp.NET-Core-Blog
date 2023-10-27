using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataAccessLayer.EntityFramework
{
    public class CommentEFramework : GenericRepository<Comment>, ICommentDal
    {
        //Dependency Injection(DI) Constructor Injection yöntemiyle yapılır
        private readonly Context _context;
        public CommentEFramework(Context context) : base(context)
        {
            _context = context;
        }

        public List<Comment> GetCommentsById(int id)
        {
            return _context.Comments.Where(x => x.BlogID == id).ToList();
        }
    }
}
