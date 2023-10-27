using BussniessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussniessLayer.Contrete
{
    public class ContactManager : GenericManager<Contact>, IContactService
    {
        //Dependency Injection(DI) Constructor Injection yöntemiyle yapılır
        public ContactManager(IGenericDal<Contact> genericDal) : base(genericDal)
        {
        }

        //Bu metod, sınıfın bir nesnesi oluşturulduğunda otomatik olarak çağrılır. Bu metodun parametresi, IGenericDal<Contact> adlı bir arayüz tipindedir. Bu parametre, ContactManager sınıfının GenericManager<Contact> sınıfından miras aldığı yapıcı metoda aktarılır.
    }
}
