using System.ComponentModel.DataAnnotations;

namespace SimpleBlogMVCApplication.ViewModels.Tag;

public class TagCreateViewModel
{
    public string Name { get; set; } = null!;
}