using AutoMapper;
using EntityLayer.Concrete;
using MehmetBlog.ViewComponents.ReplyComments;
using MehmetBlog.ViewModels;

namespace MehmetBlog.Mapping
{
    public class MappingProfile : Profile
    {
        //View modelden entitye ve entityden view modele geçmek için mapping işlemni yapılır. projenin en derin katmanlarından olan Entityleri böylece soyutlamış oluruz
        public MappingProfile() 
        { 
            CreateMap<Blog,BlogViewModel>().ReverseMap();  //reverse(); ile tesine de çalışacağını belirttik
            CreateMap<Comment,CommentsViewModel>().ReverseMap();  
            CreateMap<ReplyComment,ReplyCommentViewModel>().ReverseMap();
            CreateMap<Category,CategoryViewModel>().ReverseMap();
            CreateMap<Blog, RecentPostBlogsViewModel>();
            CreateMap<Contact, ContactViewModel>().ReverseMap();

        }
    }
}
