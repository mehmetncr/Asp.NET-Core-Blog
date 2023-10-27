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
    public class ReplyCommentManager : GenericManager<ReplyComment>, IReplyCommentService
    {
        private readonly IReplyCommentDal _replyComment;

        public ReplyCommentManager(IGenericDal<ReplyComment> genericDal , IReplyCommentDal replyComment) : base(genericDal)
        {
            _replyComment = replyComment;
        }

        public List<ReplyComment> GetReplyCommentsByID(int id)   //tüm yorumlar
        {
            return _replyComment.GetReplyCommentsById(id);
        }

        public List<ReplyComment> TrueReplyCommentsByID(int id)  //onaylı tüm yorumlar
        {
            List<ReplyComment> trueReplyComments = new List<ReplyComment>();
            List<ReplyComment> replComments = _replyComment.GetReplyCommentsById(id);
            foreach (var item in replComments)
            {
                if (item.CommentStatus == true)
                {
                    trueReplyComments.Add(item);
                }
            }
            if (trueReplyComments.Count() > 0)
            {
                return trueReplyComments;
            }
            else
            {
                return null;
            }
        }
    }
}
