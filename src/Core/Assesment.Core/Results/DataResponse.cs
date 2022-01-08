using Newtonsoft.Json;

namespace Assesment.Core.Results
{
    public class DataResponse<T> : Response
    {
        [JsonConstructor]
        public DataResponse(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }

        
        public DataResponse(T data, bool success) : base(success)
        {
            Data = data;
        }

        
        public DataResponse()
        {

        }

        [JsonProperty]
        public T Data { get; }
    }
}