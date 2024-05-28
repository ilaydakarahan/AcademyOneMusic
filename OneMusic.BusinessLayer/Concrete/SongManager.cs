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
    public class SongManager : ISongService
    {
        private readonly ISongDal _songDal;

        public SongManager(ISongDal songDal)
        {
            _songDal = songDal;
        }

        public void TCreate(Song entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(int id)
        {
            throw new NotImplementedException();
        }

        public Song TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Song> TGetList()
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Song entity)
        {
            throw new NotImplementedException();
        }
    }
}
