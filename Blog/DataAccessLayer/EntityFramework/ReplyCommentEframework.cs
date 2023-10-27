using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class ReplyCommentEframework : GenericRepository<ReplyComment>, IReplyCommentDal
    {
        private readonly Context _context;
        public ReplyCommentEframework(Context context) : base(context)
        {
            _context = context;
        }    
        public List<ReplyComment> GetReplyCommentsById(int id)
        {
            return _context.ReplyComments.Where(x=>x.ParentCommentID==id).ToList();
        }

    }
}
