using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        void Insert(T parametre);
        void Delete(T parametre);
        void Update(T parametre);
        List<T> GetListAll();
        T GetById(int id);
    }
}
