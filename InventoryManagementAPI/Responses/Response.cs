using System.Net;

namespace InventoryManagementAPI.Responses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }
    public T? Content { get; set; }
    public Response() { }

    public Response(HttpStatusCode statusCode, string message)
    {
        StatusCode = (int)statusCode;
        Message = message;
    }
    
    public Response(HttpStatusCode statusCode, string message, T? data)
    {
        StatusCode = (int)statusCode;
        Message = message;
        Content = data;
    }
}