using MockServer.Core.Enums;

namespace MockServer.WebMVC.DTOs.Project;

public class CreateProjectDto
{
    public string Name { get; set; }
    public ProjectAccessibility Accessibility { get; set; }
    public string Description { get; set; }
}