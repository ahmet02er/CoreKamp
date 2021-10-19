using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
   public class AboutManager:IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void GenericAdd(About parametre)
        {
            throw new NotImplementedException();
        }

        public void GenericDelete(About parametre)
        {
            throw new NotImplementedException();
        }

        public About GenericGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GenericGetList()
        {
            return _aboutDal.GetListAll();
        }

        public void GenericUpdate(About parametre)
        {
            throw new NotImplementedException();
        }
    }
}
