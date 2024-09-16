namespace RockScissorsPaper.Utils.Strings
{
    public class TablePrinter
    {
        private static int GetCellWidth(List<List<string>> table)
        {

            List<int> maxLengthes = new List<int>();
            foreach (List<string> row in table)
            {
                int maxLength = row.Max(s => s.Length);
                maxLengthes.Add(maxLength);
            }

            int padding = 2;
            return maxLengthes.Max(value => value) + padding;
        }

        private static string GetLineSeparator(int cellWidth, int cellsCountInRow)
        {
            int verticalBarsCount = cellsCountInRow + 1;
            return new String('-', cellsCountInRow * cellWidth + verticalBarsCount);
        }

        public static void PrintTable(List<List<string>> table)
        {
            int cellWidth = GetCellWidth(table);
            string linesSeparator = GetLineSeparator(cellWidth, table[0].Count);

            Console.WriteLine(linesSeparator);
            foreach (List<string> row in table)
            {
                foreach (string cell in row) {
                    string formattedValue = StringFormatter.AddPadding(cell, cellWidth);
                    Console.Write($"|{formattedValue}");
                }
                Console.WriteLine("|");
                Console.WriteLine(linesSeparator);
            }
        }
    }    
}
