using AutoMapper;
using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.ViewModels.Post;
using SimpleBlogMVCApplication.ViewModels.Tag;

namespace SimpleBlogMVCApplication.Mapping;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        
        CreateMap<PostCreateViewModel, Post>().ReverseMap();

       
        CreateMap<TagCreateViewModel, Tag>().ReverseMap();
        CreateMap<TagViewModel, Tag>().ReverseMap();    
    }
}