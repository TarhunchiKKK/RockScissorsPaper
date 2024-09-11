namespace RockScissorsPaper.Utils.Strings
{
    public class StringFormatter
    {
        public static string AddPadding(string source, int neccessaryLength)
        {
            double paddingSize = ((double)(neccessaryLength - source.Length) / 2);

            string leftPadding = new String(' ', (int)Math.Floor(paddingSize));
            string rightPadding = new String(' ', (int)Math.Ceiling(paddingSize));

            return leftPadding + source + rightPadding;
        }
    }
}
