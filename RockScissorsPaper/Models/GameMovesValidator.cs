namespace RockScissorsPaper.Models
{
    public class GameMovesValidator
    {
        private static bool CheckArrayLength(string[] strings)
        {
            return strings.Length >= 3 ? true : false;
        }

        private static bool CheckForDuplicates(string[] strings)
        {
            for (int i = 0; i < strings.Length; i++)
            {
                for (int j = i + 1; j < strings.Length; j++)
                {
                    if (strings[i] == strings[j])
                    {
                        return false;
                    }
                }

            }
            return true;
        }

        public static (bool, List<string>) Validate(string[] strings)
        {
            bool isValid = true;
            List<string> errors = new();

            if (!CheckForDuplicates(strings))
            {
                isValid = false;
                errors.Add("Commandline arguments should be unique");
            }

            if (!CheckArrayLength(strings))
            {
                isValid = false;
                errors.Add("Commandline argumnts count should be more than 2");
            }

            return (isValid, errors);
        }
    }
}
