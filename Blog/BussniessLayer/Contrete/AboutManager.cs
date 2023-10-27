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
    public class AboutManager : GenericManager<About>, IAboutService
    {
        //Dependency Injection(DI) Constructor Injection yöntemiyle yapılır
        //mehmet nacar
        //02/09/2023
        // .net core
        public AboutManager(IGenericDal<About> genericDal) : base(genericDal)
        {
        }
    }
}
