using OneMusic.BusinessLayer.Abstract;
using OneMusic.BusinessLayer.Concrete;
using OneMusic.DataAccessLayer.Abstract;
using OneMusic.DataAccessLayer.Concrete;
using OneMusic.DataAccessLayer.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IAboutDal, AboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAlbumDal, AlbumDal >();
builder.Services.AddScoped<IAlbumService, AlbumManager>();
builder.Services.AddScoped<IBannerDal, BannerDal>();
builder.Services.AddScoped<IBannerService, BannerManager>();
builder.Services.AddScoped<IContactDal, ContactDal>();
builder.Services.AddScoped<IContactService, ContactManager>();
builder.Services.AddScoped<IMessageDal, MessageDal>();
builder.Services.AddScoped<IMessageService, MessageManager>();
builder.Services.AddScoped<ISingerDal, SingerDal>();
builder.Services.AddScoped<ISingerService, SingerManager>();
builder.Services.AddScoped<ISongDal, SongDal>();
builder.Services.AddScoped<ISongService, SongManager>();

builder.Services.AddDbContext<OneMusicContext>();   //Context nesnesini bildiriyoruz.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
