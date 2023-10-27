using AutoMapper;
using BussniessLayer.Abstract;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.ViewComponents.Categories
{
    public class CategoriesViewComponent : ViewComponent
    {
        ICategoryService _categoryService;
        IMapper _mapper;

        public CategoriesViewComponent(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public IViewComponentResult Invoke()
        {
            List<Category> category =_categoryService.GetListAll();  //tüm kategörileri kategori ViewModele Mappler ve gösterir
            return View(_mapper.Map<List<CategoryViewModel>>(category));  
        }
    }
}
