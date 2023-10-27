using AutoMapper;
using BussniessLayer.Abstract;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.ViewComponents.HomeBlogList
{
    public class HomeBlogListViewComponent : ViewComponent
    {

        IBlogServirce _blogService;
        IMapper _mapper;

        public HomeBlogListViewComponent(IBlogServirce blogService, IMapper mapper)
        {
            _blogService = blogService;
            _mapper = mapper;

        }

        public IViewComponentResult Invoke()
        {
            List<Blog> blogs = _blogService.TrueGetListAll();  //pnaylı bloglar
            blogs.Reverse();   //son blogların önce gelmesi için
            return View(_mapper.Map<IEnumerable<BlogViewModel>>(blogs));
        }
    }
}
