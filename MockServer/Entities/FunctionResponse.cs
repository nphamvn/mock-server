namespace MockServer.Entities;

public class FunctionResponse
{
    public int Id { get; set; }
    public string Framework { get; set; }
    public string File { get; set; }
    public int RequestId { get; set; }
    public Request Request { get; set; }
}