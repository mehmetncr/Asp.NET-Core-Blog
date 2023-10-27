using BussniessLayer.Abstract;
using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussniessLayer.Contrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {

        private readonly IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        public void Delete(T t)
        {
            _genericDal.Delete(t);
        }

        public T GetById(int id)
        {
           return _genericDal.GetById(id);
        }

        public List<T> GetListAll()
        {
            return _genericDal.GetListAll();
        }

        public void Insert(T t)
        {
            _genericDal.Insert(t);
        }

        public void Update(T t)
        {
            _genericDal.Update(t);
        }
    }
}
