namespace SimpleBlogMVCApplication.Models.ViewModels;

public class PostCreateViewModel
{
    public long? Id { get; set; }


  
    public string Title { get; set; }

    public string Content { get; set; }

    public List<long> SelectedTagIds { get; set; } = new List<long>();
}
