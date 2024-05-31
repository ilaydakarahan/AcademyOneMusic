using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OneMusic.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneMusic.DataAccessLayer.Context
{
    //Bağlantı adresi getirebilmek için dataaccess katmanına dependencies kısmına nuget paketlerin yüklenmesi lazım. : DbContext
    //Paketler : EFC , EFC.tools , EFC.sqlserver , EFC.Design bunlar 4 adet paket, kullanılan sürümün son sürümü 
    //Bir de migration oluşturmadan webuı kısmı setas startup proje seçilip oraya da efc-design paketi yüklenir.
    //Migration oluştururken mutlaka data access katmanı seçilmeli.
    public class OneMusicContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)       //protected:sınıftan miras alma(dbcontext sınıfından aldık)
                                                                                            //override:miras aldığımız sınıftaki metodu ezme,configuration metodunu içine kendimiz yapı oluşturucaz.
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-BFPJH2M;database=OneMusicDb;" +
                "integrated security=true;trustServerCertificate=true");
        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Singer> Singers { get; set; }
        public DbSet<Song> Songs { get; set; }


    }
}
