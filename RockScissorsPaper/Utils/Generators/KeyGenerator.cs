using System.Security.Cryptography;


namespace RockScissorsPaper.Utils.Generators
{
    public class KeyGenerator
    {
        public static byte[] GenerateKey()
        {
            byte[] key = new byte[32];

            RandomNumberGenerator generator = RandomNumberGenerator.Create();

            generator.GetBytes(key);

            return key;
        }
    }
}
