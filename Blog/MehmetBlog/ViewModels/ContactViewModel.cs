using System.ComponentModel.DataAnnotations;

namespace MehmetBlog.ViewModels
{
    public class ContactViewModel
    {
        public int ContactID { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı girmelisiniz.")]
        [StringLength(50, ErrorMessage = "En fazla 200 karakter giribilirsiniz."),
             MinLength(3, ErrorMessage = "En az 3 karakter giribilirsiniz.")]
        public string ContactUserName { get; set; }
        [Required(ErrorMessage = "Mail Adrsi girmelisiniz.")]
        [StringLength(20, ErrorMessage = "En fazla 20 karakter girebilirsiniz"),
             MinLength(5, ErrorMessage = "En az 5 karakter girelibilirsiniz.")]
        public string ContactMail { get; set; }
        [Required(ErrorMessage = "Başlık girmelisiniz.")]
        public string ContactSubject { get; set; }
        [Required(ErrorMessage = "Mesaj girmelisiniz.")]
        [StringLength(300, ErrorMessage = "En fazla 300 karakter girebilirsiniz."),
             MinLength(10, ErrorMessage = "En az 10 karakter girelibilirsiniz.")]
        public string ContactMessage { get; set; }
        public DateTime ContactDate { get; set; }
        public bool ContactStatus { get; set; }
    }
}
