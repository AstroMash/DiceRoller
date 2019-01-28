using System;
using System.Linq;

namespace DiceRoller
{
    class Program
    {
        static void Main()
        {
            ConsoleKey key;

            Console.WriteLine("Press ENTER to roll the dice...");

            key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.Enter)
            {
                Console.Clear();
                Dice.Roll();
                Main();
            }
        }
    }

    class Dice
    {
        public static void Roll()
        {
            var dice = new string[7][];

            dice[0] = new [] { "    1    ", "+-------+", "|       |", "|   o   |", "|       |", "+-------+" };
            dice[1] = new [] { "    2    ", "+-------+", "| o     |", "|       |", "|     o |", "+-------+" };
            dice[2] = new [] { "    3    ", "+-------+", "| o     |", "|   o   |", "|     o |", "+-------+" };
            dice[3] = new [] { "    4    ", "+-------+", "| o   o |", "|       |", "| o   o |", "+-------+" };
            dice[4] = new [] { "    5    ", "+-------+", "| o   o |", "|   o   |", "| o   o |", "+-------+" };
            dice[5] = new [] { "    6    ", "+-------+", "| o   o |", "| o   o |", "| o   o |", "+-------+" };

            var results = new int[5];
            var random = new Random();
            var ascii = "";

            for (var i = 0; i < results.Length; i++)
            {
                results[i] = random.Next(1, 7);
            }

            for (var i = 0; i < dice[0].Length; i++)
            {
                int j = 0;
                ascii += dice[(results[j] - 1)][i];
                j++;
                ascii += " ";
                ascii += dice[(results[j] - 1)][i];
                j++;
                ascii += " ";
                ascii += dice[(results[j] - 1)][i];
                j++;
                ascii += " ";
                ascii += dice[(results[j] - 1)][i];
                j++;
                ascii += " ";
                ascii += dice[(results[j] - 1)][i];
                ascii += "\n";
            }

            if (results.All(x => x == results.First()))
            {
                ascii += @" __ __  _____  _____  _____  _____  _____  _____ 
|  |  ||  _  ||  |  ||_   _||__   ||   __||   __|
|_   _||     ||     |  | |  |   __||   __||   __|
  |_|  |__|__||__|__|  |_|  |_____||_____||_____|
";
            }

            Console.WriteLine(ascii);

        }
    }
}
