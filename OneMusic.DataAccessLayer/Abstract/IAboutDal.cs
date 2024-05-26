using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Abstract
{
    public interface IAboutDal : IGenericDal<About>
    {
        //Buraya hiç işlem eklemeyeceğiz çünkü bu sınıf ıgenericdaldan miras alıyor. O sınıfa gidip ordaki T yerlerine
        //hep bu about sınıfını koyucak.
    }
}
