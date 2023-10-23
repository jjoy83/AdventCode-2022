using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventCode2022
{
    public static class Day4Puzzle
    {
        public static void GetInRangePairPuzzle1()
        {
            Console.WriteLine("Staring Day4 Puzzle1!");
            string[] input = File.ReadAllText("Day4Input.txt").Split(Environment.NewLine);
            int totalAssignmentPair = 0;
;
            foreach (var ElfPair in input)
            {
                string[] range = ElfPair.Split(',');

                int lowerRange1 = int.Parse(range[0].Split('-')[0]);
                int upperRange1 = int.Parse(range[0].Split('-')[1]);

                int lowerRange2 = int.Parse(range[1].Split('-')[0]);
                int upperRange2 = int.Parse(range[1].Split('-')[1]);

                if(lowerRange1 >= lowerRange2 && upperRange1 <= upperRange2)
                {
                    totalAssignmentPair++;
                }
                else if (lowerRange2 >= lowerRange1 && upperRange2 <= upperRange1)
                {
                    totalAssignmentPair++;
                }

            }
            Console.WriteLine($"Total Inrange Assignment Pair {totalAssignmentPair}");

        }

        public static void GetInRangePairPuzzle2()
        {
            Console.WriteLine("Staring Day4 Puzzle2!");
            string[] input = File.ReadAllText("Day4Input.txt").Split(Environment.NewLine);
            int totalAssignmentPair = 0;
            ;
            foreach (var ElfPair in input)
            {
                string[] range = ElfPair.Split(',');

                int lowerRange1 = int.Parse(range[0].Split('-')[0]);
                int upperRange1 = int.Parse(range[0].Split('-')[1]);

                int lowerRange2 = int.Parse(range[1].Split('-')[0]);
                int upperRange2 = int.Parse(range[1].Split('-')[1]);

                if ((lowerRange1 >= lowerRange2 && lowerRange1 <= upperRange2) || (upperRange1 >= lowerRange2 && upperRange1 <= upperRange2))
                {
                    totalAssignmentPair++;
                }
                else if ((lowerRange2 >= lowerRange1 && lowerRange2 <= upperRange1) || (upperRange2 >= lowerRange1 && upperRange2 <= upperRange1))
                {
                    totalAssignmentPair++;
                }

            }
            Console.WriteLine($"Total Inrange Assignment Pair {totalAssignmentPair}");

        }
    }
}
