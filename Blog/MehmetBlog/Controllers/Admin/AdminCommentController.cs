using AutoMapper;
using BussniessLayer.Abstract;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.Controllers.Admin
{
    public class AdminCommentController : Controller
    {
        IReplyCommentService _replyCommentService;
        ICommentService _commentService;
        IMapper _mapper;

        public AdminCommentController(ICommentService commentService, IMapper mapper, IReplyCommentService replyCommentService)
        {
            _commentService = commentService;
            _mapper = mapper;
            _replyCommentService = replyCommentService;
        }

        public IActionResult Pswrd()
        {
            List<Comment> values = _commentService.GetListAll();
            values.Reverse();
            return View(_mapper.Map<IEnumerable<CommentsViewModel>>(values));
        }
        [HttpGet]
        public IActionResult PswrdEditComment(int id)
        {
           ViewBag.replay=_replyCommentService.GetReplyCommentsByID(id);
            return View(_mapper.Map<CommentsViewModel>(_commentService.GetById(id)));
        }
        [HttpPost]
        public IActionResult PswrdEditComment(CommentsViewModel model)
        {
            _commentService.Update(_mapper.Map<Comment>(model));
            return RedirectToAction("Pswrd");

        }
        public IActionResult PswrdChangeStatusComment(int id)
        {
            Comment comment = _commentService.GetById(id);
            if ( comment.CommentStatus== true)
            {
                comment.CommentStatus = false;
            }
            else
            {
                comment.CommentStatus = true;
            }
            _commentService.Update(comment);

           
            return RedirectToAction("Pswrd");
        }
        [HttpPost]
        public IActionResult PswrdEditReplayComment(IEnumerable<CommentsViewModel> model)
        {
            _commentService.Update(_mapper.Map<Comment>(model));
            return RedirectToAction("Pswrd");

        }


        [HttpGet]
        public IActionResult PswrdReplayEditComment(int id)
        {
           
            return View(_mapper.Map<ReplyCommentViewModel>(_replyCommentService.GetById(id)));
        }
        [HttpPost]
        public IActionResult PswrdReplayEditComment(ReplyCommentViewModel model)
        {
            _replyCommentService.Update(_mapper.Map<ReplyComment>(model));
            return RedirectToAction("Pswrd");

        }
        public IActionResult PswrdReplayChangeStatusComment(int id)
        {
            ReplyComment comment = _replyCommentService.GetById(id);
            if (comment.CommentStatus == true)
            {
                comment.CommentStatus = false;
            }
            else
            {
                comment.CommentStatus = true;
            }
            _replyCommentService.Update(comment);


            return RedirectToAction("PswrdEditComment" , new {id=comment.ParentCommentID});
        }
    }

}
