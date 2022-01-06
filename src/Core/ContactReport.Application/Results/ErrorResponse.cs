namespace Karatekin.Web.Api.Core.Utilities.Result
{
    public class ErrorResponse : Response
    {
        public ErrorResponse(string message) : base(false, message)
        {
        }

        public ErrorResponse() : base(false)
        {
        }
    }
}