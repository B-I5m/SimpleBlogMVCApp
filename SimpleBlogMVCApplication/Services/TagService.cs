using Microsoft.EntityFrameworkCore;
using SimpleBlogMVCApplication.Data;
using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Services.Interfaces;

namespace SimpleBlogMVCApplication.Services.Implementations;

public class TagService : ITagService
{
    private readonly ApplicationDbContext _context;

    public TagService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Tag>> GetAllAsync()
    {
        return await _context.Tags.ToListAsync();
    }

    public async Task<Tag?> GetByIdAsync(long id)
    {
        return await _context.Tags.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task CreateAsync(Tag tag)
    {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Tag tag)
    {
        _context.Tags.Update(tag);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id)
    {
        var tag = await GetByIdAsync(id);
        if (tag == null) return;

        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();
    }
}