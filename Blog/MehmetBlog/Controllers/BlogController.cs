using AutoMapper;
using BussniessLayer.Abstract;
using BussniessLayer.Contrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.Controllers
{
    public class BlogController : Controller
    {
    
        private readonly IBlogServirce _blogServirce;       //Iblogservice->Blogmanager->GenericManager->IGenericDal<Blog>->GenericRepo
        private readonly IMapper _mapper;     //view modelleri mapleme işlemi için 

        public BlogController(IBlogServirce blogServirce, IMapper mapper)
        {
            _blogServirce = blogServirce;
            _mapper = mapper;

        }

        public IActionResult Index(int? id,string? name)
        {
            if (id == null && name==null)   //tüm bloglar gösterilir
            {
                List<Blog> blog = _blogServirce.TrueGetListAll().ToList();
                blog.Reverse();

                return View(_mapper.Map<List<BlogViewModel>>(blog));
            }
            else if (id!=null && name==null) //Categori seçilirse seçilen kategoriye ait bloglar listelenir
            {
                List<Blog> blog = _blogServirce.GetListAllWithCategoryByCategory(id).ToList();
                blog.Reverse();

                return View(_mapper.Map<List<BlogViewModel>>(blog));
            }
            else
            {
                List<Blog> blog = _blogServirce.GetListSeachBlog(name);
                return View(_mapper.Map<List<BlogViewModel>>(blog));
            }

        }


        public IActionResult PostDetails(int id)  //postun okunma sayafası 
        {
            Blog blog = _blogServirce.TrueGetById(id);
            return View(_mapper.Map<BlogViewModel>(blog));
        }



    }
}
