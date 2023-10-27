using AutoMapper;
using BussniessLayer.Abstract;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.ViewComponents.RecentPosts
{
    public class RecentPostsViewComponent : ViewComponent
    {
        IBlogServirce _blogService;
        IMapper _mapper;

        public RecentPostsViewComponent(IBlogServirce blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Blog> blogs = _blogService.GetListAll().TakeLast(3).Reverse();  //son 3 postu gösterir
          
            return View(_mapper.Map<IEnumerable<RecentPostBlogsViewModel>>(blogs));
        }
    }
}
 