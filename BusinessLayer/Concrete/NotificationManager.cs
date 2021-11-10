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
    public class NotificationManager : INotificationService
    {
        INotificationDal _notificationDal;

        public NotificationManager(INotificationDal notificationDal)
        {
            _notificationDal = notificationDal;
        }

        public void GenericAdd(Notification parametre)
        {
            throw new NotImplementedException();
        }

        public void GenericDelete(Notification parametre)
        {
            throw new NotImplementedException();
        }

        public Notification GenericGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Notification> GenericGetList()
        {
            return _notificationDal.GetListAll();
        }

        public void GenericUpdate(Notification parametre)
        {
            throw new NotImplementedException();
        }
    }
}
