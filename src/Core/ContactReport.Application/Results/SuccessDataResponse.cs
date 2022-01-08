using System.Text.Json.Serialization;

namespace Karatekin.Web.Api.Core.Utilities.Result
{
    public class SuccessDataResponse<T> : DataResponse<T>
    {
        [JsonConstructor]
        public SuccessDataResponse(T data, string message) : base(data, true, message)
        {
        }

        [JsonConstructor]
        public SuccessDataResponse(T data) : base(data, true)
        {
        }

        [JsonConstructor]
        public SuccessDataResponse(string message) : base(default, true, message)
        {
        }

        [JsonConstructor]
        public SuccessDataResponse() : base(default, true)
        {
        }
    }
}