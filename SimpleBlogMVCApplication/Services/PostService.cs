
using Microsoft.EntityFrameworkCore;
using SimpleBlogMVCApplication.Data;
using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Services.Interfaces;

namespace SimpleBlogMVCApplication.Services.Implementations;

public class PostService : IPostService
{
    private readonly ApplicationDbContext _context;

    public PostService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Post>> GetAllAsync(long? tagId = null)
    {
        var query = _context.Posts
            .Include(p => p.PostTags)
            .ThenInclude(pt => pt.Tag)
            .AsQueryable();

        if (tagId.HasValue)
            query = query.Where(p => p.PostTags.Any(pt => pt.TagId == tagId));

        return await query.ToListAsync();
    }

    public async Task<Post?> GetByIdAsync(long id)
    {
        return await _context.Posts
            .Include(p => p.PostTags)
            .ThenInclude(pt => pt.Tag)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task CreateAsync(Post post, List<long> tagIds)
    {
        foreach (var tagId in tagIds)
            post.PostTags.Add(new PostTag { TagId = tagId });

        _context.Posts.Add(post);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Post post, List<long> tagIds)
    {
        var existing = await _context.Posts
            .Include(p => p.PostTags)
            .FirstAsync(p => p.Id == post.Id);

        existing.Title = post.Title;
        existing.Content = post.Content;

        existing.PostTags.Clear();
        foreach (var tagId in tagIds)
            existing.PostTags.Add(new PostTag { TagId = tagId });

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var post = await _context.Posts.FindAsync(id);
        if (post != null)
        {
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }
    }
}