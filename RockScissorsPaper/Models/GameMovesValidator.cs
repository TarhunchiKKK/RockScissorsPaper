namespace RockScissorsPaper.Models
{
    public class GameMovesValidator
    {
        private static bool CheckArrayLength(string[] moves)
        {
            return moves.Length >= 3 ? true : false;
        }

        private static bool CheckForDuplicates(string[] moves)
        {
            HashSet<string> movesSet = new HashSet<string>(moves);
            return movesSet.Count == moves.Length;
        }

        public static (bool, List<string>) ValidateMoves(string[] strings)
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
