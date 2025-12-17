using SimpleBlogMVCApplication.Models.Entities;

namespace SimpleBlogMVCApplication.Services.Interfaces;

public interface IPostService
{
    Task<List<Post>> GetAllAsync(long? tagId = null);
    Task<Post?> GetByIdAsync(long id);
    Task CreateAsync(Post post, List<long> tagIds);
    Task UpdateAsync(Post post, List<long> tagIds);
    Task DeleteAsync(long id);
}