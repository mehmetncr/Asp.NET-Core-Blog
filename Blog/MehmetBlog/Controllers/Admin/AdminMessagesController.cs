using AutoMapper;
using BussniessLayer.Abstract;
using EntityLayer.Concrete;
using MehmetBlog.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MehmetBlog.Controllers.Admin
{
    public class AdminMessagesController : Controller
    {
        IContactService _contactService;
        IMapper _mapper;

        public AdminMessagesController(IContactService contactService, IMapper mapper)
        {
            _contactService = contactService;
            _mapper = mapper;
        }

        public IActionResult Pswrd()
        {
            
            return View(_mapper.Map<List<ContactViewModel>>(_contactService.GetListAll()));
        }

        public IActionResult PswrdChangeStatusMessage(int id)
        {
            Contact message = _contactService.GetById(id);
            if (message.ContactStatus == true)
            {
                message.ContactStatus = false;
            }
            else
            {
                message.ContactStatus = true;
            }
            _contactService.Update(message);


            return RedirectToAction("Pswrd");
        }
        public IActionResult PswrdDetails(int id) 
        {
           
            return View(_mapper.Map<ContactViewModel>(_contactService.GetById(id)));
        }
    }
}
