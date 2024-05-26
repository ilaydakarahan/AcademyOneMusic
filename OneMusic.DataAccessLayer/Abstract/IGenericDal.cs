using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Abstract
{
    //Her entity(tablo) için bir interface oluşturup kullanacağımız metotları burda tanımlamamız gerekirdi.
    //Ancak bu uzun olacağı için generic bir interface yazıp, tüm metotları burda tanımlayıp
    // (T türünde) Repository sınıfında içlerini dolduracağız.
    public interface IGenericDal<T> where T : class
    {   
        //CRUD işlemleri
        List<T> GetList();
        T GetById(int id);  //ide ye göre getirme metodu. T türünde tanımlarız,yani tek bir dönüş tipi olan( parametresi id)
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);


    }
}
