using AutoMapper;
using BussniessLayer.Abstract;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.ViewComponents.Comments
{
    public class CommentsViewComponent : ViewComponent
    {
        ICommentService _commentServce;
        IMapper _mapper;

        public CommentsViewComponent(ICommentService commentServce, IMapper mapper)
        {
            _commentServce = commentServce;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke(int id)  
        {
            List<Comment> comment = _commentServce.TrueAllCommentsById(id);

            if (comment==null) 
            {
              
                ViewBag.Count = 0;  //hiç yorum yoksa hata vermemesi için
            }
            else
            {
                comment.Reverse(); 
                ViewBag.Count = comment.Count(); 
            }
           
            return View(_mapper.Map<List<CommentsViewModel>>(comment));   //oanaylı yorumlar
        }


    }
}
