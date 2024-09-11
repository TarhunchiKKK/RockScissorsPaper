using RockScissorsPaper.Utils.Strings;


namespace RockScissorsPaper.Models
{
    internal delegate GameResult CompareMoves(string userMove, string computerMove);

    internal class GameRules
    {        
        string TopLeftCellContent { get; } = "v PC\\User >";

        List<string> Moves { init; get; } = null!;

        CompareMoves CompareMoves { init; get; } = null!;

        public GameRules(string[] moves, CompareMoves compareMoves)
        {
            this.Moves = new List<string>(moves);
            this.CompareMoves = compareMoves;
        }

        private int GetCellWidth()
        {
            List<string> allCellsContent = new List<string>(this.Moves);
            allCellsContent.AddRange([
                this.TopLeftCellContent, 
                GameResult.Win.ToString(), 
                GameResult.Lose.ToString(), 
                GameResult.Draw.ToString()
            ]);
            return allCellsContent.Max(s => s.Length) + 2;
        }

        private string GetLineSeparator(int cellWidth)
        {
            int cellsCount = Moves.Count + 1;
            int verticalBarsCount = cellsCount + 1;
            return new String('-', cellsCount * cellWidth + verticalBarsCount);
        }

        private void PrintHeaders(int cellWidth)
        {
            // all headers
            List<string> headers = new List<string>();
            headers.Add(this.TopLeftCellContent);
            headers.AddRange(this.Moves);

            // print headers
            foreach (string header in headers)
            {
                string formattedHeader = StringFormatter.AddPadding(header, cellWidth);
                Console.Write($"|{formattedHeader}");
            }
            Console.WriteLine("|");
        }

        public void PrintRules()
        {
            int cellWidth = GetCellWidth();
            string linesSeparator = GetLineSeparator(cellWidth);

            // headers
            Console.WriteLine(linesSeparator);
            PrintHeaders(cellWidth);
            Console.WriteLine(linesSeparator);

            // table
            for (int i = 0; i < this.Moves.Count; i++)
            {
                string formattedValue = StringFormatter.AddPadding(this.Moves[i], cellWidth);
                Console.Write($"|{formattedValue}|");

                for (int j = 0; j < this.Moves.Count; j++)
                {
                    GameResult compareResult = this.CompareMoves(this.Moves[i], this.Moves[j]);
                    string formattedCompareResult = StringFormatter.AddPadding(compareResult.ToString(), cellWidth);
                    Console.Write($"{formattedCompareResult}|");
                }

                Console.WriteLine();
                Console.WriteLine(linesSeparator);
            }
        }
    }
}
