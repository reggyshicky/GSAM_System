using System.Net;

namespace Application.Models
{
    public class APIResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }

        public string Message { get; set; } = string.Empty;

        public T? Result { get; set; }
    }
}
