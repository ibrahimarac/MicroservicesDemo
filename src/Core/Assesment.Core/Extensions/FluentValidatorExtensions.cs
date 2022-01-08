using System.Text.RegularExpressions;

namespace Assesment.Core.Extensions
{
    public static class FluentValidatorExtensions
    {
        public static bool IsGuid(this string guid)
        {
            Regex regex = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
            return regex.IsMatch(guid);
        }
    }
}
