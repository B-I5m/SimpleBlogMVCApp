using System.ComponentModel.DataAnnotations;

namespace SimpleBlogMVCApplication.ViewModels.Post;

public class PostCreateViewModel
{
    public long? Id { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = null!;

    [Required]
    public string Content { get; set; } = null!;

    public List<long> SelectedTagIds { get; set; } = new();
}