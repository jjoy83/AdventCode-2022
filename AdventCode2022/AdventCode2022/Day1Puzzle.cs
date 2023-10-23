using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventCode2022
{
    public static class Day1Puzzle
    {
        static int elfTotalCalorie = 0;
        static int maxCalorieElf = 0;
        static int elfNumber = 0;
        static Dictionary<int, int> elfCaloriesList;
        static int top3ElfCalories = 0;
        public static void GetMaxElfTotalCalorie()
        {
            Console.WriteLine("Staring Day1 Puzzle!");
           

            string[] input = File.ReadAllText("Day1Input.txt").Split(Environment.NewLine + Environment.NewLine);
            elfCaloriesList = new Dictionary<int, int>();
            foreach (string elfData in input)
            {
                elfNumber++;
                elfTotalCalorie = 0;
                string[] elfCalorieItems = elfData.Split(Environment.NewLine.ToCharArray());
                foreach (string foodItem in elfCalorieItems)
                {
                    if (!string.IsNullOrEmpty(foodItem))
                    {
                        elfTotalCalorie += int.Parse(foodItem);
                    }
                }
                elfCaloriesList.Add(elfNumber, elfTotalCalorie);


                if (maxCalorieElf == 0)
                {
                    maxCalorieElf = elfTotalCalorie;
                    //elfWithMaxCalorie = elfNumber;
                }
                else if (maxCalorieElf < elfTotalCalorie)
                {
                    maxCalorieElf = elfTotalCalorie;
                    //elfWithMaxCalorie = elfNumber;
                }
                else
                {
                    continue;
                }
            }

            int topElfCount = 0;
            foreach (var elf in elfCaloriesList.OrderByDescending(x => x.Value))
            {
                topElfCount++;
                top3ElfCalories += elf.Value;

                if (topElfCount >= 3)
                {
                    break;
                }

            }

            Console.WriteLine($"Top 3 Elf Max Calories {maxCalorieElf}");

            Console.WriteLine($"Max Calories ElfNumber {top3ElfCalories}");
        }
    }
}
