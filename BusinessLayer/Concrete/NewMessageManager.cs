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
    public class NewMessageManager : INewMessageService
    {
        INewMessageDal _newMessageDal;

        public NewMessageManager(INewMessageDal newMessageDal)
        {
            _newMessageDal = newMessageDal;
        }

        public void GenericAdd(NewMessage parametre)
        {
            throw new NotImplementedException();
        }

        public void GenericDelete(NewMessage parametre)
        {
            throw new NotImplementedException();
        }

        public NewMessage GenericGetById(int id)
        {
            return _newMessageDal.GetById(id);
        }

        public List<NewMessage> GenericGetList()
        {
            return _newMessageDal.GetListAll();
        }

        public void GenericUpdate(NewMessage parametre)
        {
            throw new NotImplementedException();
        }

        public List<NewMessage> GetInboxListByWriter(int id)
        {
            return _newMessageDal.GetListWithMessageByWriter(id);
        }
    }
}
