using OneMusic.BusinessLayer.Abstract;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.BusinessLayer.Concrete
{
    public class SingerManager : ISingerService
    {
        private readonly ISingerDal _singerDal;

        public SingerManager(ISingerDal singerDal)
        {
            _singerDal = singerDal;
        }

        public void TCreate(Singer entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Singer TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Singer> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Singer entity)
        {
            throw new NotImplementedException();
        }
    }
}
