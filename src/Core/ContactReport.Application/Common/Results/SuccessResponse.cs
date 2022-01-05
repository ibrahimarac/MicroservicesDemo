namespace Karatekin.Web.Api.Core.Utilities.Result
{
    public class SuccessResponse : Response
    {
        public SuccessResponse(string message) : base(true, message)
        {
        }

        public SuccessResponse() : base(true)
        {
        }
    }
}