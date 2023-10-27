using AutoMapper;
using BussniessLayer.Abstract;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.Controllers
{
    public class ContactController : Controller
    {
        IContactService _contactService;
        IMapper _mapper;

        public ContactController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ContactViewModel contact)
        {
            if (contact == null)
            {
              
                return View();
            }
            else
            {
                if (ModelState.IsValid)
                {
                    _contactService.Insert(_mapper.Map<Contact>(contact));
                    return RedirectToAction("Index");
                }
             
            }
            return View();

        }
    }
}
