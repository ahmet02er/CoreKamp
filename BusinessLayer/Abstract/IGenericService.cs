using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IGenericService<T>
    {
        void GenericAdd(T parametre);
        void GenericDelete(T parametre);
        void GenericUpdate(T parametre);
        List<T> GenericGetList();
        T GenericGetById(int id);
    }
}
