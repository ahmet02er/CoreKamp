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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void GenericAdd(Message parametre)
        {
            throw new NotImplementedException();
        }

        public void GenericDelete(Message parametre)
        {
            throw new NotImplementedException();
        }

        public Message GenericGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GenericGetList()
        {
            return _messageDal.GetListAll();
        }

        public void GenericUpdate(Message parametre)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetInboxListByWriter(string parametre)
        {
            return _messageDal.GetListAll(x=>x.MessageReceiver==parametre);
        }
    }
}
