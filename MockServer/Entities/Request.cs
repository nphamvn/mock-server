namespace MockServer.Entities;

public class Request
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Method { get; set; }
    public string Path { get; set; }
    public int ResponseType { get; set; } = 0; //0: Static, 1: Function
    public StaticResponse? StaticResponse { get; set; }
    public FunctionResponse? FunctionResponse { get; set; }
    public int WorkspaceId { get; set; }
    public Workspace Workspace { get; set; }
}