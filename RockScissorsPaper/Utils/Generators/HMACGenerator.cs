using System.Text;
using System.Security.Cryptography;
using RockScissorsPaper.Utils.Strings;


namespace RockScissorsPaper.Utils.Generators
{
    public class HMACGenerator
    {
        public static string GenerateHMACSHA256(byte[] key, string source)
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);

            HMACSHA256 hmac = new HMACSHA256(key);

            byte[] hash = hmac.ComputeHash(sourceBytes);

            return StringConverter.FromHMAC(hash);
        }
    }
}
