namespace MockServer.Entities;

public class Response
{
    public int Id { get; set; }

    public int Type { get; set; } = 0; //0: Static, 1: Function
    //Static
    public int? StatusCode { get; set; }
    public string? Body { get; set; }
    // public Dictionary<string, string>? Headers { get; set; }
    // public Dictionary<string, string>? Cookies { get; set; }

    //Function
    public string? Framework { get; set; }
    public string? File { get; set; }
    public int RequestId { get; set; }
    public Request Request { get; set; }
}