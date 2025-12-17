using System.ComponentModel.DataAnnotations;

namespace SimpleBlogMVCApplication.ViewModels.Tag;

public class TagViewModel
{
    public long? Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;
}