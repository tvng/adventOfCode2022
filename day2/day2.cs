// See https://aka.ms/new-console-template for more information

// Hello World! program
namespace HelloWorld
{
    class Hello
    {

        static int Part1(string player1, string player2)
        {
            int score = 0;
            // Round winning score
            // (A = 65 in ascii, 65%3 = 2 =>   -1 to normalize)
            score += ((player2[0] - player1[0] - 1) % 3) * 3;
            // Hand gesture score
            score += player2[0] - 'W'; // normalize to 1-3, wich is hand score
            return score;
        }

        static int Part2(string player1, string goal)
        {
            // normalize data
            var p1 = player1[0] - 64;
            var p2 = 0;
            switch (goal)
            {
                case "X": // loose
                    p2 = (p1 + 2) % 3;
                    if (p2 == 0)
                        p2 = 3;
                    return p2;
                case "Y": // draw
                    return p1 + 3;
                case "Z": // win
                    p2 = (p1 + 1) % 3;
                    if (p2 == 0)
                        p2 = 3;
                    return p2 + 6;
            }
            Console.WriteLine("err");
            return 0;
        }

        static void Main(string[] args)
        {
            string path = "day2input.txt";
            int score1 = 0;
            int score2 = 0;

            if (!File.Exists(path))
            {
                Console.WriteLine("path doesnt exist");
                return;
            }
            foreach (string line in System.IO.File.ReadLines(path))
            {
                string[] hands = line.Split(' ');
                score1 += Part1(hands[0], hands[1]);
                score2 += Part2(hands[0], hands[1]);
            }
            System.Console.WriteLine($"score {score1} - p2 {score2}");
        }

    }
}