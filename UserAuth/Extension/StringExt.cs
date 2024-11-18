using Microsoft.IdentityModel.Tokens;

namespace UserAuth.Extension
{
    public static class StringExt
    {
        public static bool IsNull(this string str)
        {
            return str.IsNullOrEmpty();
        }
    }
}
