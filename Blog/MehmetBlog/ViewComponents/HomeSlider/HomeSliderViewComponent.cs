using AutoMapper;
using BussniessLayer.Abstract;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.ViewComponents.HomeSlider
{
    public class HomeSliderViewComponent : ViewComponent
    {
        IBlogServirce _blogServirce;
        IMapper _mapper;

        public HomeSliderViewComponent(IBlogServirce blogServirce, IMapper mapper)
        {
            _blogServirce = blogServirce;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            IEnumerable<Blog> blogs = _blogServirce.TrueGetListAll().TakeLast(10);  //slider için onaylı bloglar
            blogs.Reverse();
            return View(_mapper.Map<IEnumerable<BlogViewModel>>(blogs));
        }
    }
}
