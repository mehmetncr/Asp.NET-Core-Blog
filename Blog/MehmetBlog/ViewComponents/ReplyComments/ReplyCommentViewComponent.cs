using AutoMapper;
using BussniessLayer.Abstract;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MehmetBlog.ViewComponents.ReplyComments
{
    public class ReplyCommentViewComponent :  ViewComponent
    {
        IReplyCommentService _replyCommentService;
        IMapper _mapper;

        public ReplyCommentViewComponent(IReplyCommentService replyCommentService, IMapper mapper)
        {
            _replyCommentService = replyCommentService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int id)
        {

            List<ReplyComment> comments = _replyCommentService.TrueReplyCommentsByID(id);
           

            if (comments==null)
            {
                return Content("");
            }
            else
            {
                comments.Reverse();
                return View(_mapper.Map<List<ReplyCommentViewModel>>(comments));
            }
          
        }

    }
}
