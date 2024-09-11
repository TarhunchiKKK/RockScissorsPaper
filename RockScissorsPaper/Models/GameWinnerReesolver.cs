namespace RockScissorsPaper.Models
{
    internal class GameWinnerReesolver
    {
        List<string> Moves { init; get; } = null!;

        public GameWinnerReesolver(string[] moves)
        {
            this.Moves = new List<string>(moves);
        }

        public GameResult Compare(string userMove, string computerMove)
        {
            if (userMove == computerMove)
            {
                return GameResult.Draw;
            }

            int userMoveIndex = this.Moves.IndexOf(userMove);
            int computerMoveIndex = this.Moves.IndexOf(computerMove);

            int n = Moves.Count;
            double p = Moves.Count / 2;
            double result = (userMoveIndex - computerMoveIndex + n - p) % n - p;
            return result < 0 ? GameResult.Lose : GameResult.Win;
        }
    }
}
