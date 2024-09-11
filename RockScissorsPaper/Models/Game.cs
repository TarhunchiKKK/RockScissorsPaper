using RockScissorsPaper.Utils.Strings;

namespace RockScissorsPaper.Models
{
    public delegate string GenerateHMAC(byte[] key, string source);

    public class Game
    {
        List<string> Moves { init; get; } = null!;

        GameWinnerReesolver WinnerResolver { init; get; } = null!;

        GameRules GameRules { init; get; } = null!;

        GenerateHMAC HMACGenerator { init; get; } = null!;

        public Game(string[] moves, GenerateHMAC generateHMAC)
        {
            this.Moves = new List<string>(moves);
            this.WinnerResolver = new GameWinnerReesolver(moves);
            this.GameRules = new GameRules(moves, this.WinnerResolver.Compare);
            this.HMACGenerator = generateHMAC;
        }

        private string GetUserMove()
        {
            Dictionary<string, string> menu = new();
            for (int i = 1; i <= this.Moves.Count; i++)
            {
                menu.Add(i.ToString(), this.Moves[i - 1]);
            }
            menu.Add("0", "exit");
            menu.Add("?", "help");

            while (true)
            {
                foreach (var (key, value) in menu)
                {
                    Console.WriteLine($"{key} - {value}");
                }

                Console.Write("Enter your move: ");
                string? menuItem = Console.ReadLine();

                if (menuItem != null)
                {
                    if (menu.ContainsKey(menuItem))
                    {
                        string userMove = menu[menuItem]!;
                        Console.WriteLine($"Your move: {userMove}");

                        if (userMove == "help")
                        {
                            this.GameRules.PrintRules();
                        }
                        else
                        {
                            return userMove;
                        }
                    }
                }
            }
        }

        private string GetComputerMove()
        {
            Random random = new Random();
            int index = random.Next(0, this.Moves.Count);
            return this.Moves[index];
        }

        public void Start(byte[] hmacKey)
        {
            string computerMove = GetComputerMove();
            string computerHMAC = this.HMACGenerator(hmacKey, computerMove);
            Console.WriteLine($"HMAC: {computerHMAC}");

            string userMove = GetUserMove();
            if (userMove == "exit")
            {
                return;
            }

            Console.WriteLine($"Computer move: {computerMove}");

            GameResult gameResult = this.WinnerResolver.Compare(userMove, computerMove);
            switch (gameResult)
            {
                case GameResult.Win:
                    Console.WriteLine("You win!");
                    break;
                case GameResult.Lose:
                    Console.WriteLine("You lose!");
                    break;
                case GameResult.Draw:
                    Console.WriteLine("Draw");
                    break;
            }
            //string r = hmacKey.ToString()!;
            Console.WriteLine($"HMAC key: {StringConverter.FromHMAC(hmacKey)}");
        }
    }
}
