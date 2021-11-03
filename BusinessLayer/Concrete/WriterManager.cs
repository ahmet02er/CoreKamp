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
   public class WriterManager:IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public void GenericAdd(Writer parametre)
        {
            _writerDal.Insert(parametre);
        }

        public void GenericDelete(Writer parametre)
        {
            throw new NotImplementedException();
        }

        public Writer GenericGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GenericGetList()
        {
            throw new NotImplementedException();
        }

        public void GenericUpdate(Writer parametre)
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerDal.GetListAll(x => x.WriterId == id);
        }
    }
}
