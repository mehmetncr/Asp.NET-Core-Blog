using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }
        public string CommentUserName { get; set; }
        public string CommentMail { get; set; }

        public string CommentContent { get; set; }
        public string CommentImg { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }



        //blog sayfasına bağlanmak için gerekenler
        //bir yorum sadece bir blog'a ait olabilir
        public int BlogID { get; set; }
        public Blog Blog { get; set; }

        //bir yorumun birden fazla cevabı olabilir
        public List<ReplyComment> ReplayComments { get; set; }

    }
}
