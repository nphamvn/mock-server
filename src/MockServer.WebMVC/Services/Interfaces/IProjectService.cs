using MockServer.Core.Enums;
using MockServer.WebMVC.DTOs.Project;
using MockServer.WebMVC.Models.Project;

namespace MockServer.WebMVC.Services.Interfaces;

public interface IProjectService
{
    Task<ProjectIndexViewModel> GetIndexViewModel(ProjectSearchModel searchModel);
    Task<bool> Create(CreateProjectViewModel project);
    Task<ProjectViewViewModel> GetProjectViewViewModel(string name);
    Task Rename(string name, string newName);
    Task<string> GenerateKey(string name);
    Task Delete(string name);
    Task SetAccessibility(string name, ProjectAccessibility accessibility);
}