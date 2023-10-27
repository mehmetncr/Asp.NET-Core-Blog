using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class ReplyComment
    {
        [Key]
        public int CommentID { get; set; }
        public int BlogReplayCommentID { get; set; }
        public string CommentUserName { get; set; }
        public string CommentMail { get; set; }

        public string CommentImg { get; set; }

        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }
        
        //her cevabın 1 ana yorumu olabilir
        public int ParentCommentID { get; set; }
        public Comment ParentComment { get; set; }
    }
}
