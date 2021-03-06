using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface INewMessageDal : IGenericDal<NewMessage>
    {
        List<NewMessage> GetInboxWithMessageByWriter(int id);
        List<NewMessage> GetSendboxWithMessageByWriter(int id);
    }
}
