using OneMusic.DataAccessLayer.Abstract;
using OneMusic.DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly OneMusicContext _context;

        public GenericRepository(OneMusicContext context)   //Proje ilk çalışmaya başladığında önce burdan başlar.Ctor yapısı
                                                            //contexti=> _context'e 
        {
            _context = context;
        }

        public void Create(T entity)    //Ekleme ve güncelleme işlemi yaparken parametre hazır geliyor,
                                        //entity parametresi T türünde(T hangi tablo olduğu).Set işlemine gerek yok.
        {                               
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)  //Silme ve diğerlerinde ise parametre olarak id var ancak hangi tablo lduğu belli olmadığı için Set(T) ile belirtiyoruz.
        {
            var value=_context.Set<T>().Find(id);
            _context.Set<T>().Remove(value);
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetList()
        {   //T öğesi entity e denk gelir.
            return _context.Set<T>().ToList();
        }

        public void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }
    }
}
