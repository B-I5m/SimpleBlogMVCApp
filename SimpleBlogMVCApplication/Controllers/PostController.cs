using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Services.Interfaces;
using SimpleBlogMVCApplication.ViewModels.Post;

namespace SimpleBlogMVCApplication.Controllers;

[Authorize]
public class PostController : Controller
{
    private readonly IPostService _postService;
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;
    

    public PostController(IPostService postService, ITagService tagService, IMapper mapper)
    {
        _postService = postService;
        _tagService = tagService;
        _mapper = mapper;
    }

    public async Task<IActionResult> Index(long? tagId)
    {
        var posts = await _postService.GetAllAsync(tagId);
        return View(posts);
    }

    public async Task<IActionResult> Details(long id)
    {
        var post = await _postService.GetByIdAsync(id);
        if (post == null) return NotFound();

        return View(post);
    }

    public async Task<IActionResult> Create()
    {
        ViewBag.Tags = await _tagService.GetAllAsync();
        return View(new PostCreateViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Create(PostCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Tags = await _tagService.GetAllAsync();
            return View(model);
        }

        var post = _mapper.Map<Post>(model);
        await _postService.CreateAsync(post, model.SelectedTagIds);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(long id)
    {
        var post = await _postService.GetByIdAsync(id);
        if (post == null) return NotFound();

        var model = new PostCreateViewModel
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            SelectedTagIds = post.PostTags?.Select(pt => pt.TagId).ToList() ?? new List<long>()
        };

        ViewBag.Tags = await _tagService.GetAllAsync();
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(PostCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Tags = await _tagService.GetAllAsync();
            return View(model);
        }

        var post = _mapper.Map<Post>(model);
        post.Id = model.Id!.Value;

        await _postService.UpdateAsync(post, model.SelectedTagIds);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(long id)
    {
        await _postService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}
