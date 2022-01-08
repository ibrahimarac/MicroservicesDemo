


using Newtonsoft.Json;

namespace Karatekin.Web.Api.Core.Utilities.Result
{
    public class Response
    {
        public Response(bool success, string message) : this(success)
        {
            Message = message;
        }

        [JsonConstructor]
        public Response(bool success)
        {
            Success = success;
        }

        public Response()
        {

        }

        [JsonProperty]
        public bool Success { get; }

        [JsonProperty]
        public string Message { get; }
    }
}