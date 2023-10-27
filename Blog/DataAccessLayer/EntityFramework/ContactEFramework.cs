using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class ContactEFramework : GenericRepository<Contact>, IContactDal
    {
        //Dependency Injection(DI) Constructor Injection yöntemiyle yapılır
        public ContactEFramework(Context context) : base(context)
        {
        }
    }
}
