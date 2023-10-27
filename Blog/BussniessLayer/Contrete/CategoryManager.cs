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
    public class CategoryManager : GenericManager<Category>, ICategoryService
    {
        //Dependency Injection(DI) Constructor Injection yöntemiyle yapılır
        public CategoryManager(IGenericDal<Category> genericDal) : base(genericDal)
        {
        }
    }
}
