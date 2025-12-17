using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBlogMVCApplication.Models.Entities;
using SimpleBlogMVCApplication.Services.Interfaces;
using SimpleBlogMVCApplication.ViewModels.Tag;

namespace SimpleBlogMVCApplication.Controllers;

public class TagController : Controller
{
    private readonly ITagService _tagService;
    private readonly IMapper _mapper;

    public TagController(ITagService tagService, IMapper mapper)
    {
        _tagService = tagService;
        _mapper = mapper;
    }


    public async Task<IActionResult> Index()
    {
        var tags = await _tagService.GetAllAsync();
        return View(tags);
    }


    public IActionResult Create()
    {
        return View(new TagViewModel());
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(TagViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var tag = _mapper.Map<Tag>(model);
        await _tagService.CreateAsync(tag);

        return RedirectToAction(nameof(Index));
    }


    public async Task<IActionResult> Edit(long id)
    {
        var tag = await _tagService.GetByIdAsync(id);
        if (tag == null) return NotFound();

        var model = _mapper.Map<TagViewModel>(tag);
        return View(model);
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(TagViewModel model)
    {
        if (!ModelState.IsValid) return View(model);

        var tag = _mapper.Map<Tag>(model);
        tag.Id = model.Id!.Value;

        await _tagService.UpdateAsync(tag);
        return RedirectToAction(nameof(Index));
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(long id)
    {
        await _tagService.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }
}