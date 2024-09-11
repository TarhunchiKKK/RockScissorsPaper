namespace RockScissorsPaper.Utils.Strings
{
    public class StringConverter
    {
        public static string FromHMAC(byte[] hmac)
        {
            return BitConverter.ToString(hmac).Replace("-", "").ToLower();
        }
    }
}
