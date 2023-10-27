using BussniessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussniessLayer.Contrete
{
    public class CommentManager : GenericManager<Comment>, ICommentService
    {
        //Dependency Injection(DI) Constructor Injection yöntemiyle yapılır
        private readonly ICommentDal _commentDal;
        public CommentManager(IGenericDal<Comment> genericDal, ICommentDal commentDal) : base(genericDal)
        {
            _commentDal = commentDal;
        }

        public List<Comment> GetAllCommentsById(int id)    // blog ID sine göre yorumlar
        {
            return _commentDal.GetCommentsById(id);
        }

        public List<Comment> TrueAllCommentsById(int id)    //blog Id'sine göre statusu true olan yayınlanmıiş yorumlar
        {
            List<Comment> trueComments = new List<Comment>();    //yeni liste oluşturulur
            List<Comment> comments = _commentDal.GetCommentsById(id);
            foreach (var item in comments)
            { 
                if (item.CommentStatus == true)   
                {
                    trueComments.Add(item);
                }
            }
            if (trueComments.Count() > 0)
            {
                return trueComments;   //en az bir tene bulunursa döner liste yoksa null gönderilir
            }
            else
            {
                return null;
            }
       
        }
    }
}
