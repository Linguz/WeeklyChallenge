using System;

namespace WeeklyChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
                RockPaperScissors();
        }

        private static void RockPaperScissors()
        {
            string c1 = "", c2 = "";
            bool cont = true;

            while (cont)
            {
                Console.Write("Player one, choose rock, paper, or scissors: ");
                c1 = Console.ReadLine();
                if (c1.Equals("rock") || c1.Equals("paper") || c1.Equals("scissors"))
                {
                    cont = false;
                }
                Console.WriteLine("");
            }
            
            cont = true;
            while (cont)
            {
                Console.Write("Player two, choose rock, paper, or scissors: ");
                c2 = Console.ReadLine();
                if (c2.Equals("rock") || c2.Equals("paper") || c2.Equals("scissors"))
                {
                    cont = false;
                }
                Console.WriteLine("");
            }

            Console.WriteLine(RockPaperScissorsLogic(c1, c2));
        }

        private static string RockPaperScissorsLogic(string first, string second)
        {
            string P1 = "Player 1 wins";
            string P2 = "Player 2 wins";

            if (first == second)
            {
                return "TIE";
            }
            else if (first == "rock")
            {
                if (second == "scissors")
                {
                    return P1;
                }
                else if (second == "paper")
                {
                    return P2;
                }
            }
            else if (first == "scissors")
            {
                if (second == "rock")
                {
                    return P2;
                }
                else if (second == "paper")
                {
                    return P1;
                }
            }
            else if (first == "paper")
            {
                if (second == "scissors")
                {
                    return P2;
                }
                else if (second == "rock")
                {
                    return P1;
                }
            }

            return "CONFUSION";
        }
    }
}
