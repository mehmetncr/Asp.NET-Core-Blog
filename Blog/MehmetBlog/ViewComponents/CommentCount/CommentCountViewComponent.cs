using BussniessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.ViewComponents.CommentCount
{
    public class CommentCountViewComponent : ViewComponent
    {
        ICommentService _commentService;

        public CommentCountViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        //anasayfada postların yorum sayılarını gösterir
        public IViewComponentResult Invoke(int id)
        {
            int commentcount = _commentService.GetAllCommentsById(id).Count();
            return View(commentcount);
        }
    }
}
