using AutoMapper;
using BussniessLayer.Abstract;

using EntityLayer.Concrete;

using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using System.Xml.Linq;

namespace MehmetBlog.Controllers
{
    public class CommentController : Controller
    {

        private readonly IReplyCommentService _replyCommentService;
        private readonly ICommentService _commentService;  //yorum ekleme işlemi için
        private readonly IMapper _mapper;

        public CommentController(IReplyCommentService replyCommentService, ICommentService commentService, IMapper mapper)
        {
            _replyCommentService = replyCommentService;
            _commentService = commentService;
            _mapper = mapper;

        }

        //[HttpPost]
        //public IActionResult Addcomment(CommentsViewModel commnet)  //Yorum ekleme
        //{
        //    ModelState.Clear();


        //    if (ModelState.IsValid)
        //    {
        //        commnet.CommentStatus = true;  //status false olarak değiştirilecek
        //        commnet.CommentDate = DateTime.Now;
        //        Random say = new Random();
        //        int resim = say.Next(1, 16);
        //        commnet.CommentImg = "/images/Profil/" + resim + ".jpg";
        //        _commentService.Insert(_mapper.Map<Comment>(commnet));   //commentsVİewModel->Comment
        //        return RedirectToAction("PostDetails", "Blog", new { id = commnet.BlogID });  //aynı blog sayfasını açar

        //    }

        //           // ModelState.AddModelError(item.PropertyName, item.ErrorMessage); //tüm hata mesajları modelerrora eklenir ve modelstate otamatik view span larına gider

        //    return View();

        //}
        [HttpPost]
        public void Addcomment(Comment comment)  //Yorum ekleme
        {
            ModelState.Clear();

            if (ModelState.IsValid)
            {

                comment.CommentStatus = false;  //status false olarak değiştirilecek
                comment.CommentDate = DateTime.Now;
                Random say = new Random();
                int resim = say.Next(1, 16);
                comment.CommentImg = "/images/Profil/" + resim + ".jpg";
                _commentService.Insert(comment);
            }
     

           
        }


        [HttpPost]
        public IActionResult AddReplayComment(ReplyCommentViewModel comment)  //Yorum ekleme
        {
            comment.CommentStatus = false;  //status false olarak değiştirilecek
            comment.CommentDate = DateTime.Now;
            Random say = new Random();
            int resim = say.Next(1, 16);
            comment.CommentImg = "/images/Profil/" + resim + ".jpg";
            _replyCommentService.Insert(_mapper.Map<ReplyComment>(comment));   //commentsVİewModel->Comment
            return RedirectToAction("PostDetails", "Blog", new { id = comment.BlogReplayCommentID });  //aynı blog sayfasını açar
        }

    }
}
