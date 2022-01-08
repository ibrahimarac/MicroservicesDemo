


using Newtonsoft.Json;

namespace Assesment.Core.Results
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