using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MockServer.WebMVC.Models.Request;

namespace MockServer.WebMVC.Models.Project;

public class ProjectViewViewModel
{
    public ProjectIndexItem ProjectInfo { get; set; }
    public IEnumerable<RequestItem> Requests { get; set; }
}
