using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussniessLayer.Abstract
{
    public interface ICommentService : IGenericService<Comment>
    {
        public List<Comment> GetAllCommentsById(int id);  //id ye göre blog için 
        public List<Comment> TrueAllCommentsById(int id);  //statusu true olanlar
    }
}
