using BussniessLayer.Abstract;
using BussniessLayer.Contrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Database stringi appsettings doyasýnda onu ve context sýnýfýmýzý birleþtirdik. bu iþlemden önce library class lar arasýnda referaslarýn tanýmlanmasý gerekir
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MehmetBlogDb")));


//automapper çalýþmasý için
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());  


//builder.Services.AddScoped<IBlogDal, BlogEFramework>();
//builder.Services.AddScoped<IAboutDal, AboutEFramework>();
//builder.Services.AddScoped<IGenericService<Blog> , BlogManager>();
//builder.Services.AddScoped<IGenericService<Category>, CategoryManager>();
//builder.Services.AddScoped<IGenericService<About>, AboutManager>();
//builder.Services.AddScoped<IGenericService<Comment>, CommentManager>();
builder.Services.AddScoped<IGenericDal<Blog>, BlogEFramework>();
builder.Services.AddScoped<IGenericDal<About>, AboutEFramework>();
builder.Services.AddScoped<IGenericDal<Category>, CategoryEFramework>();
builder.Services.AddScoped<IGenericDal<Comment>, CommentEFramework>();
builder.Services.AddScoped<IGenericDal<Contact>, ContactEFramework>();
builder.Services.AddScoped<IGenericDal<ReplyComment>, ReplyCommentEframework>();
builder.Services.AddScoped<IBlogServirce, BlogManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IReplyCommentService, ReplyCommentManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IContactService, ContactManager>();


//Generic harici metot için 
builder.Services.AddScoped<IReplyCommentDal, ReplyCommentEframework>();
builder.Services.AddScoped<IBlogDal,BlogEFramework>();
builder.Services.AddScoped<ICommentDal,CommentEFramework>();








var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Error/Index/","?code={0}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
