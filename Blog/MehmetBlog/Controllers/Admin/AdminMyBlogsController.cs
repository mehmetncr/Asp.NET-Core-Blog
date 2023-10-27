using AutoMapper;
using BussniessLayer.Abstract;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.Execution;
using System.Collections.Generic;

namespace MehmetBlog.Controllers.Admin
{
    public class AdminMyBlogsController : Controller
    {
        ICategoryService _categoryService;
        IBlogServirce _blogServirce;
        IMapper _mapper;

        public AdminMyBlogsController(ICategoryService categoryService, IBlogServirce blogServirce, IMapper mapper)
        {
            _categoryService = categoryService;
            _blogServirce = blogServirce;
            _mapper = mapper;
        }


        public IActionResult Pswrd()  //blog listesi
        {

            return View(_mapper.Map<IEnumerable<BlogViewModel>>(_blogServirce.AllBlogWithCategory()));
        }
        [HttpGet]
        public IActionResult PswrdNewBlog()  //yeni blog oluşturma
        {
            ViewBag.categoryList = new SelectList(_categoryService.GetListAll(), "CategoryID", "CategoryName");
            return View();
        }
        [HttpPost]
        public IActionResult PswrdNewBlog(BlogViewModel model, IFormFile formFile, IFormFile formFileimage)  //yeni blog oluşturma ve fotoğraf kayıt işlemleri
        {
            if (model != null && formFile != null && formFileimage != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFile.FileName); //proje yolu bulunur ve dizin + dosya adı path yapılır
                var stream = new FileStream(path, FileMode.Create);  //copyalanacağı yol ile beraber belirtilir
                formFile.CopyTo(stream); //dosya kopyalanır

                var pathimage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFileimage.FileName);
                var streamimage = new FileStream(pathimage, FileMode.Create);
                formFileimage.CopyTo(streamimage);

                model.BlogThumbnailImage = "/images/" + formFile.FileName; //veritabanına yol olarak kaydedilir

                model.BlogImage = "/images/" + formFileimage.FileName;



                model.BlogCreateDate = DateTime.Now;


                _blogServirce.Insert(_mapper.Map<Blog>(model));
            }
            return RedirectToAction("Pswrd");
        }
        [HttpGet]
        public IActionResult PswrdEditBlog(int id)  //blog listesinden gönderilen id ye göre blog bilgileri ekrana getirilir
        {

            ViewBag.categoryList = new SelectList(_categoryService.GetListAll(), "CategoryID", "CategoryName");   //kategori seçimi dropdown menu için kategori adları çekilir
            var blog = _blogServirce.GetById(id);    //gelen blog     

            TempData["img"] = blog.BlogImage;  
            //resim yolları post metoduna gönderilmek için alınır
            TempData["thumpimg"] = blog.BlogThumbnailImage;
  
            return View(_mapper.Map<BlogViewModel>(blog));
        }
        [HttpPost]
        public IActionResult PswrdEditBlog(BlogViewModel model, IFormFile formFile, IFormFile formFileimage)
        {

            if (model != null && formFile == null && formFileimage == null)   //eğer resim değiştirilmemişse sadece diğer bilgiler değişir
            {
                model.BlogThumbnailImage = TempData["thumpimg"].ToString();
                model.BlogImage = TempData["img"].ToString();



                _blogServirce.Update(_mapper.Map<Blog>(model));
            }
            else if(model != null && formFile != null && formFileimage == null)  //thubnail image değişmiş ancak diğeri değişmemişse
            {               
                model.BlogImage = TempData["img"].ToString();
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                formFile.CopyTo(stream);
                model.BlogThumbnailImage = "/images/" + formFile.FileName;

                _blogServirce.Update(_mapper.Map<Blog>(model));
                return RedirectToAction("Pswrd");


            }
            else if (model != null && formFile == null && formFileimage != null) // büyük resim değişmiş ama thumpnail değişmemişse
            {
                model.BlogThumbnailImage = TempData["thumpimg"].ToString();
                var pathimage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFileimage.FileName);
                var streamimage = new FileStream(pathimage, FileMode.Create);
                formFileimage.CopyTo(streamimage);

                model.BlogImage = "/images/" + formFileimage.FileName;
                _blogServirce.Update(_mapper.Map<Blog>(model));
                return RedirectToAction("Pswrd");


            }
            else if(model != null && formFile != null && formFileimage != null)  //iki resim birden değişmişse
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFile.FileName);
                var stream = new FileStream(path, FileMode.Create);
                formFile.CopyTo(stream);
                model.BlogThumbnailImage = "/images/" + formFile.FileName;
              
                var pathimage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\", formFileimage.FileName);
                var streamimage = new FileStream(pathimage, FileMode.Create);
                formFileimage.CopyTo(streamimage);

                model.BlogImage = "/images/" + formFileimage.FileName;
                _blogServirce.Update(_mapper.Map<Blog>(model));
                return RedirectToAction("Pswrd");

            }
            return View(model);


            

   




        }

        [HttpGet]
        public IActionResult PswrdChangeStatus(int id)
        {
            Blog blog =_blogServirce.GetById(id);
           if (blog.BlogStatus == true)
            {
                blog.BlogStatus = false;
            }
            else
            {
                blog.BlogStatus = true;
            }
            _blogServirce.Update(blog);
           
            return RedirectToAction("Pswrd");
        }
    }
}
