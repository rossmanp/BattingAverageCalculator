using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GC_Lab8_BattingAverageCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            bool run = true;
            Console.WriteLine("Welcome to the Batting Average Calculator!");
            while (run)
            {
                Console.Write("\nEnter the number of batters: ");
                int batter = IntValidator.getIntWithinRange(0, 500);
                Console.Write("\nEnter the number of at bats for each batter: ");
                int atBat = IntValidator.getIntWithinRange(0, 5000);                
                int[,] atBats = new int[batter, atBat];
                double[] hitCount = new double[batter];
                Console.WriteLine("\n0 = out, 1 = single, 2 = double, 3 = triple, 4 = home run");
                for (int j = 0; j < batter; j++)
                {
                    Console.WriteLine("\nEnter at bats for batter " + (j + 1) + ":");
                    for (int i = 0; i < atBat; i++)
                    {
                        Console.Write("\nResult for at bat " + (i + 1) + ": ");
                        int atBatResult = IntValidator.getIntWithinRange(0, 4);
                        if (atBatResult != 0)
                        {
                            hitCount[j]++;
                        }
                        atBats[j, i] = atBatResult;
                    }
                }
                for (int j = 0; j < batter; j++)
                {
                    double sum = 0;
                    for (int i = 0; i < atBat; i++)
                    {
                        sum += atBats[j, i];
                    }
                    double batting = hitCount[j] / atBat;
                    double slugging = sum / atBat;
                    Console.WriteLine("\nBatting average for batter " + (j + 1) + ":{0:F3} ", batting);
                    Console.WriteLine("Slugging percentage for batter " + (j + 1) + ":{0:F3} ", slugging);
                }
                run = Continue();
            }
            Console.ReadLine();

        }

        public static Boolean Continue()
        {
            Console.Write("\nDo you want to use the calculator again with more batters? (y/n): ");
            string input = Console.ReadLine();
            Boolean run = true;
            input = input.ToLower();

            if (input == "n")
            {
                Console.WriteLine("\nGoodbye!");
                run = false;
            }
            else if (input == "y")
            {
                run = true;
            }
            else
            {
                Console.WriteLine("I'm sorry, I didn't understand your input. Let's try that again!");
                run = Continue();
            }

            return run;
        }
    }
}
