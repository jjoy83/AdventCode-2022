using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventCode2022
{
    public static class Day6Puzzle
    {
        public static void GetFirstCharacterMarkerLengthPuzzle1()
        {
            Console.WriteLine("Staring Day6 Puzzle1!");
            char[] input = File.ReadAllText("Day6Input.txt").ToCharArray();

            int i = 0;
            int j = 0;
            string finalMarker=string.Empty;
            while(i< input.Length) 
            {
                j=0;
                finalMarker = string.Empty;
                while(j<4)
                {
                    if (!finalMarker.Contains(input[i+j]))
                    {
                        finalMarker += input[i+j].ToString();
                    }
                    else
                    {
                        break;
                    }
                    j++;
                }

                if(finalMarker.Length == 4)
                {
                    break;
                }
                i++;
            }

            Console.WriteLine($"The length of characters for first message marker - {i}");

        }

        public static void GetFirstCharacterMarkerLengthPuzzle2()
        {
            Console.WriteLine("Staring Day6 Puzzle1!");
            char[] input = File.ReadAllText("Day6Input.txt").ToCharArray();

            int i = 0;
            int j = 0;
            string finalMarker = string.Empty;
            while (i < input.Length)
            {
                j = 0;
                finalMarker = string.Empty;
                while (j < 14)
                {
                    if (!finalMarker.Contains(input[i + j]))
                    {
                        finalMarker += input[i + j].ToString();
                    }
                    else
                    {
                        break;
                    }
                    j++;
                }

                if (finalMarker.Length == 14)
                {
                    break;
                }
                i++;
            }

            Console.WriteLine($"The length of characters for first message marker - {i}");

        }
    }
}
