using System;
using System.Collections.Generic;

namespace WeeklyChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            Boolean exit = false;
            while (!exit)
            {
                Console.WriteLine();
                List<string> options = new List<string>() { "q", "1", "2", "3", "4", "5" };
                Console.WriteLine("1: Rock Paper Scissors");
                Console.WriteLine("2: OverTime");
                Console.WriteLine("3: UniqueFract");
                Console.WriteLine("4: AlmostPalindrome");
                Console.WriteLine("5: RecursionStaircase");
                Console.WriteLine("q: Exit");
                
                Console.Write("Select a choice: ");
                string input = Console.ReadLine();
                
                while (!(options.Contains(input)))
                {
                    Console.Write("Please select a valid choice: ");
                    input = Console.ReadLine();
                }

                switch(input)
                {
                    case "q":
                        exit = true;
                        break;
                    case "1":
                        RockPaperScissors();
                        break;
                    case "2":
                        OverTime();
                        break;
                    case "3":
                        UniqueFract();
                        break;
                    case "4":
                        AlmostPalindrome();
                        break;
                    case "5":
                        RecursionStaircase();
                        break;
                    default:
                        Console.WriteLine("You're not meant to get here.");
                        exit = true;
                        break;
                }
            }
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

        private static void OverTime()
        {
            double[] parameters = new double[4];
            string[] queries = new string[] {"Start time: ", "End time: ", "Hourly rate: ", "Overtime multiplier: "};

            for(int i = 0; i < 4; i++)
            {
                double temp;
                bool cont = true;
                while (cont)
                {
                    Console.Write(queries[i]);
                    try
                    {
                        temp = Double.Parse(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please input a number.");
                        continue;
                    }
                    
                    parameters[i] = temp;
                    cont = false;
                }
            }
            OverTimePay(parameters[0], parameters[1], parameters[2], parameters[3]);
        }
        private static void OverTimePay(double start, double end, double rate, double multiplier)
        {
            // 9-17 is regular hours
            // after 17 is overtime
            double total = 0;
            if (end <= 17)
            {
                // no overtime
                total = (end-start) * rate;
            }
            else
            {
                double baseTotal = (17-start) * rate;
                double overTotal = (end-17) * rate * multiplier;
                total = baseTotal + overTotal;
            }

            if (start < 9)
            {
                Console.WriteLine("You should not begin work before 9am. Please check with your manager to ensure proper compensation.");
            }

            Console.WriteLine($"{total:C}");
        }
    
        private static void UniqueFract()
        {
            double total = 0;
            List<double> holder = new List<double>();
            for (double d = 1; d < 10; d++)
            {
                for (double n = 1; n < 9; n++)
                {
                    double fraction = n/d;
                    if (fraction >= 1)
                    {
                        break;
                    }
                    if (holder.Contains(fraction))
                    {
                        continue;
                    }
                    else
                    {
                        holder.Add(fraction);
                        total += fraction;
                    }
                }
            }
            Console.WriteLine($"Total of all unique fractions whose numerator and denominator are less than 1: {total}");
        }

        private static void AlmostPalindrome()
        {
            Console.Write("What is the string you'd like to check? ");
            string palindoom = Console.ReadLine();

            bool doomed = CheckPalindrome(palindoom);

            if (doomed)
            {
                Console.WriteLine("This string is or is almost a palindrome!");
            }
            else
            {
                Console.WriteLine("This string is not nearly a palindrome.");
            }
        }
        private static bool CheckPalindrome(string palindoom)
        {
            int check = 0;
            for (int i = 0; i < palindoom.Length; i++)
            {
                int j = palindoom.Length - i - 1;

                if (j <= i)
                {
                    break;
                }

                if (palindoom[i] != palindoom[j])
                {
                    check++;
                }
            }

            if (check > 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void RecursionStaircase()
        {
            Console.Write("How many stairs are there? ");
            int n = 0;
            int ways = 0;
            bool contain = true;
            do
            {
                string input = Console.ReadLine();

                try
                {
                    n = Int32.Parse(input);
                    contain = false;
                }
                catch
                {
                    Console.WriteLine("That is not a number. Try again.");
                }

                if (n < 0)
                {
                    Console.WriteLine("Please input a positive number.");
                    contain = true;
                }
            } while (contain);

            ways = StaircaseCounter(n);

            Console.WriteLine($"There are {ways} way(s) to climb these steps.");
        }
        private static int StaircaseCounter(int n)
        {
            int x = 1;
            int y = 1;

            if (n < 2)
            {
                return 1;
            }
            
            for (int i = 1; i < n; i++)
            {
                int z = x + y;
                x = y;
                y = z;
            }

            return y;
        }
    }
}
