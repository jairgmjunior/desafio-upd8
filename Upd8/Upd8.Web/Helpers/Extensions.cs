using System.Text.RegularExpressions;

namespace Upd8.Web.Helpers
{
    public static class Extensions
    {
        public static string Clear(this string str)
        {
            if (string.IsNullOrWhiteSpace(str))
            {
                return str;
            }

            var characters = new Regex(@"[^0-9]");
            return characters.Replace(str, "");
        }
    }
}
