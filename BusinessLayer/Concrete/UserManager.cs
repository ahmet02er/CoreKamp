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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void GenericAdd(AppUser parametre)
        {
            throw new NotImplementedException();
        }

        public void GenericDelete(AppUser parametre)
        {
            throw new NotImplementedException();
        }

        public AppUser GenericGetById(int id)
        {
            return _userDal.GetById(id);
        }

        public List<AppUser> GenericGetList()
        {
            throw new NotImplementedException();
        }

        public void GenericUpdate(AppUser parametre)
        {
            _userDal.Update(parametre);
        }
    }
}
