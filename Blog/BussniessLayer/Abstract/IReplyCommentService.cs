using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussniessLayer.Abstract
{
    public interface IReplyCommentService : IGenericService<ReplyComment>
    {
        List<ReplyComment> GetReplyCommentsByID(int id);  //id ye göre yorum yanıtları
        List<ReplyComment> TrueReplyCommentsByID(int id);  //id ye göre statusu true olanlar
    }
}
