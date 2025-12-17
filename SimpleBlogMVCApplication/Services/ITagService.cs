using SimpleBlogMVCApplication.Models.Entities;

namespace SimpleBlogMVCApplication.Services.Interfaces;

public interface ITagService
{
    Task<List<Tag>> GetAllAsync();
    Task<Tag?> GetByIdAsync(long id);        
    Task CreateAsync(Tag tag);
    Task UpdateAsync(Tag tag);               
    Task DeleteAsync(long id);             
}