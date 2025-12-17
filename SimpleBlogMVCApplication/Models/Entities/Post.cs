using System.ComponentModel.DataAnnotations;

namespace SimpleBlogMVCApplication.Models.Entities;

public class Post : BaseEntity
{
    
    public string Title { get; set; } = null!;
    
    public string Content { get; set; } = null!;

    public DateTime PublishedAt { get; set; } = DateTime.UtcNow;

    public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
}