using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Abstract
{
    public interface IAlbumDal: IGenericDal<Album>
    {
        List<Album> GetAlbumsByArtist(int id);  //Artistin id sine göre albüm getirme

        List<Album> GetAlbumswithArtist();  //Tüm sanatçılarla albümleri getirme. Bu ana sayfada tüm albümleri listelemek için.
    }
}
