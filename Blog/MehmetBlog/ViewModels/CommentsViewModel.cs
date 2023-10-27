using EntityLayer.Concrete;
using System.ComponentModel.DataAnnotations;

namespace MehmetBlog.ViewModels
{
    public class CommentsViewModel
    {
        public int CommentID { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı girmelisiniz.")]
        [StringLength(50, ErrorMessage = "En fazla 200 karakter giribilirsiniz."),
            MinLength(3,  ErrorMessage = "En az 3 karakter giribilirsiniz.")]
      
        public string CommentUserName { get; set; }


        [Required(ErrorMessage = "Mail Adrsi girmelisiniz.")]
        [StringLength(20, ErrorMessage ="En fazla 20 karakter girebilirsiniz"),
            MinLength(5,ErrorMessage ="En az 5 karakter girelibilirsiniz.")]
        public string CommentMail { get; set; }
        public string CommentImg { get; set; }
        [Required(ErrorMessage = "Yorum girmelisiniz.")]
        [StringLength(300, ErrorMessage = "En fazla 300 karakter girebilirsiniz."),
            MinLength(35, ErrorMessage = "En az 35 karakter girelibilirsiniz.")]
        public string CommentContent { get; set; }
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
