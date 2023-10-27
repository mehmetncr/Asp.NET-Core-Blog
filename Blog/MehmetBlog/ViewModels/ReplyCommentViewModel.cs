using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace MehmetBlog.ViewModels
{
    public class ReplyCommentViewModel
    {
        public int CommentID { get; set; }
        public int BlogReplayCommentID { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı girmelisiniz.")]
        [StringLength(50, ErrorMessage = "En fazla 200 karakter giribilirsiniz."),
            MinLength(3, ErrorMessage = "En az 3 karakter giribilirsiniz.")]

        public string CommentUserName { get; set; }
        public string CommentImg { get; set; }
        [Required(ErrorMessage = "Mail Adrsi girmelisiniz.")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter girebilirsiniz"),
            MinLength(5, ErrorMessage = "En az 5 karakter girelibilirsiniz.")]

        public string CommentMail { get; set; }
        [Required(ErrorMessage = "Yorum girmelisiniz.")]
        [StringLength(300, ErrorMessage = "En fazla 300 karakter girebilirsiniz."),
         MinLength(10, ErrorMessage = "En az 10 karakter girelibilirsiniz.")]
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public bool CommentStatus { get; set; }

        //her cevabın 1 ana yorumu olabilir
        public int ParentCommentID { get; set; }
        public Comment ParentComment { get; set; }
    }
}
