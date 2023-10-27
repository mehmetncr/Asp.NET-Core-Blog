using AutoMapper;
using BussniessLayer.Abstract;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.ViewComponents.Admin
{
    public class AdminReplayCommentViewComponent : ViewComponent
    {
        IReplyCommentService _replyCommentService;
        IMapper _mapper;
        public AdminReplayCommentViewComponent(IReplyCommentService replyCommentService,IMapper mapper)
        {
            _replyCommentService = replyCommentService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int id)
        {
            List<ReplyComment> model =  _replyCommentService.GetReplyCommentsByID(id);

            return View(_mapper.Map<IEnumerable<ReplyCommentViewModel>>(model));
        }
    }
}
