using System.Net;

namespace SaleAssistant.Business.Models
{
    public class ServiceError
    {
        public string FieldKey { get; set; }

        public string Message { get; set; }

        public HttpStatusCode StatusCode { get; set; }
    }
}