using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Context;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfNewMessageRepository : GenericRepository<NewMessage>, INewMessageDal
    {
        public List<NewMessage> GetInboxWithMessageByWriter(int id)
        {
            using (var context = new MsSqlContext())
            {
                return context.NewMessages.Include(x =>x.SenderUser).Where(x => x.MessageReceiverId == id).ToList();
            }
        }

        public List<NewMessage> GetSendboxWithMessageByWriter(int id)
        {
            using (var context = new MsSqlContext())
            {
                return context.NewMessages.Include(x => x.ReceiverUser).Where(x => x.MessageSenderId == id).ToList();
            }
        }
    }
}
