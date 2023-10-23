using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventCode2022
{
    public static class Day3Puzzle
    {
        static int totalPriorities = 0;
        static int UPPER_CASE = 38;
        static int LOWER_CASE = 96;
        public static void GetTotalPrioritiesPuzzle1()
        {
            Console.WriteLine("Staring Day3 Puzzle1!");
            string[] input = File.ReadAllText("Day3Input.txt").Split(Environment.NewLine);

            foreach (var sackItem in input)
            {
                int halfLength = sackItem.Length / 2;
                var compartments1 = sackItem.Substring(0, halfLength);
                var compartments2 = sackItem.Substring(halfLength);

                foreach (char item in compartments1.ToCharArray())
                {
                    if (compartments2.Contains(item))
                    {
                        var commonItem = item.ToString();
                        int commonItemvalue = item;
                        int priorityValue = 0;
                        Console.WriteLine($"Item {commonItem}, item value {commonItemvalue}");
                        if (char.IsUpper(item))
                        {
                            priorityValue = commonItemvalue - UPPER_CASE;
                        }
                        else if (char.IsLower(item))
                        {
                            priorityValue = commonItemvalue - LOWER_CASE;
                        }
                        totalPriorities += priorityValue;
                        break;
                    }

                }

            }
            Console.WriteLine($"Final Total Priorities {totalPriorities}");

        }

        public static void GetTotalPrioritiesPuzzle2()
        {
            Console.WriteLine("Staring Day3 Puzzle2!");
            string[] input = File.ReadAllText("Day3Input.txt").Split(Environment.NewLine);

            int i = 0;
            while (i < input.Length - 2)
            {
                int priorityValue = 0;
                foreach (char item in input[i].ToCharArray())
                {
                    if (input[i + 1].Contains(item) && input[i + 2].Contains(item))
                    {
                        var commonItem = item.ToString();
                        int commonItemvalue = item;
                      
                        Console.WriteLine();
                        if (char.IsUpper(item))
                        {
                            priorityValue = commonItemvalue - UPPER_CASE;
                        }
                        else if (char.IsLower(item))
                        {
                            priorityValue = commonItemvalue - LOWER_CASE;
                        }
                        i = i + 3;
                        break;
                    }
                }
                totalPriorities += priorityValue;
            }
            Console.WriteLine($"Final Total Priorities {totalPriorities}");
        }
    }
}
