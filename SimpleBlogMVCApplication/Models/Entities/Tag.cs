namespace SimpleBlogMVCApplication.Models.Entities;
public class Tag : BaseEntity
{
    
    public string Name { get; set; } = null!;

    public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
}