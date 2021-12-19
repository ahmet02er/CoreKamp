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
   public class AdminManager:IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void GenericAdd(Admin parametre)
        {
            throw new NotImplementedException();
        }

        public void GenericDelete(Admin parametre)
        {
            throw new NotImplementedException();
        }

        public Admin GenericGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Admin> GenericGetList()
        {
            return _adminDal.GetListAll();
        }

        public void GenericUpdate(Admin parametre)
        {
            throw new NotImplementedException();
        }
    }
}
