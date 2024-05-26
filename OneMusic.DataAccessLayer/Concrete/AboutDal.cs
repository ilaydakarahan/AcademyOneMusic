using OneMusic.DataAccessLayer.Abstract;
using OneMusic.DataAccessLayer.Context;
using OneMusic.DataAccessLayer.Repositories;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Concrete
{
    public class AboutDal : GenericRepository<About>, IAboutDal     //Burda interfacesi tekrar eklememizin sebebi genericrepositoryde olmayan
                                                                    //sadece About a özgü bir metod tanımlamak isteyebiliriz.
                                                                    //Öyle bir metodu interface içinde tanımlayacağız.Orda tanımlayıp içeriğini burda yazarız.
    {
        public AboutDal(OneMusicContext context) : base(context)    //base ifadesi context nesnesini aldığımız yeri belirtir,bir üst sınıfı yani genericrepo..
        {

        }
    }
}
