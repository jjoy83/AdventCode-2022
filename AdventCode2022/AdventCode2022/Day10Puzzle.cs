using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventCode2022
{
    public static class Day10Puzzle
    {
        private static int sumOfX = 0;
        private static int printCounter = 20;
        public static void GetInstructionsPuzzle1()
        {
            string[] input = File.ReadAllLines("Day10Input.txt");
            int cycle = 1;
            int x = 1;
            int addxCycleCounter = 0;



            while (true)
            {
                foreach (string line in input)
                {
                    string[] items = line.Split(' ');

                    switch (items[0])
                    {
                        case "addx":
                            while (true)
                            {
                                CheckCycle(cycle, x);
                                addxCycleCounter++;
                                cycle++;
                                if (addxCycleCounter == 2)
                                {
                                    x = x + int.Parse(items[1]);
                                    addxCycleCounter = 0;
                                    break;
                                }
                            }
                            break;

                        case "noop":
                            CheckCycle(cycle, x);
                            cycle++;
                            break;
                    }

                    if (printCounter == 260)
                    {
                        break;
                    }

                }
                Console.WriteLine($"Sum of x is {sumOfX}");
                break;

            }


        }

        private static void CheckCycle(int cycle, int x)
        {
            if (cycle == printCounter)
            {
                Console.WriteLine($"Value of x for cycle {printCounter} is {x}");
                sumOfX += x * printCounter;
                printCounter += 40;

            }

        }
    }
}
