using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MockServer.WebMVC.DTOs.Project;
using MockServer.WebMVC.Models.Project;
using MockServer.WebMVC.Services.Interfaces;

namespace MockServer.WebMVC.Controllers;

[Authorize]
public class ProjectsController : BaseController
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }
    public async Task<IActionResult> Index()
    {
        var vm = await _projectService.GetIndexViewModel();
        return View("Views/Projects/Index.cshtml", vm);
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> Detail(string name)
    {
        var vm = await _projectService.GetProjectViewViewModel(name);
        return View("Views/Projects/View.cshtml", vm);
    }

    [HttpGet("create")]
    public async Task<IActionResult> Create()
    {
        var vm = new CreateProjectViewModel();
        return View("Views/Projects/Create.cshtml", vm);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(CreateProjectViewModel project)
    {
        if (!await _projectService.Create(project))
        {
            return View("Views/Projects/Create.cshtml", project);
        }

        return RedirectToAction(nameof(Detail), new { name = project.Name });
    }

    [HttpPost("{name}/settings/rename")]
    public async Task<IActionResult> Rename(string name, string newName)
    {
        await _projectService.Rename(name, newName);
        return Ok();
    }

    [HttpPost("{name}/settings/generate-key")]
    public async Task<IActionResult> GenerateKey(string name)
    {
        string key = await _projectService.GenerateKey(name);
        return Ok(new { key = key });
    }

    [HttpPost("{name}/settings/delete")]
    public async Task<IActionResult> Delete(string name)
    {
        await _projectService.Delete(name);
        return RedirectToAction(nameof(Index));
    }
}