using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace TestingSystem.BLL.JWTAuth
{
    public static class AuthOptions
    {
        public static string Key { get; } = "eynssssfsdisksuo";
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Key));
        }
    }
}
