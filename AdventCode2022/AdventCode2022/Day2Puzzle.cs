using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventCode2022
{
    public static class Day2Puzzle
    {
        static Dictionary<string, int> gameScoreList;
        static int totalGameScore = 0;
        static int totalGameScorePuzzle2 = 0;
        static int Win = 6;
        static int Lose = 0;
        static int Draw = 3;
        static int X = 1; static int Y = 2; static int Z = 3;
        static int Rock = 1; static int Paper = 2; static int Sissor = 3;

        public static void GetElfTotalGameScore()
        {
            Console.WriteLine("Staring Day2 Puzzle1!");
            gameScoreList = new Dictionary<string, int>();

            //Puzzle 1
            //"A" --> "X" Draw
            //"A" --> "Y" Win
            //"A" --> "Z" Lose

            //"B"-- > "X" Lose
            //"B"-- > "Y" Draw
            //"B"-- > "Z" Win

            //"C"-- > "X" Win
            //"C"-- > "Y" Lose
            //"C"-- > "Z" Draw


            string[] input = File.ReadAllText("Day2Input.txt").Split(Environment.NewLine);

            foreach(string game in input)
            {
                char[] chars = game.ToCharArray();
                var gameScore = GetTotalGameScore(chars[0], chars[2]);
                //gameScoreList.Add(game, gameScore);
                totalGameScore += gameScore;

            }

            Console.WriteLine($"Total Game Score - {totalGameScore}");
           
        }

        public static void GetElfTotalGameScorePuzzle2()
        {
            Console.WriteLine("Staring Day2 Puzzle2!");
            gameScoreList = new Dictionary<string, int>();

            //Puzzle 2
            //"A" --> "X" Sissor Lose
            //"A" --> "Y" Rock Draw
            //"A" --> "Z" Paper Win

            //"B"-- > "X" Rock Lose
            //"B"-- > "Y" Paper Draw
            //"B"-- > "Z" Sissor Win
             
            //"C"-- > "X" Paper Lose
            //"C"-- > "Y" Sissor Draw
            //"C"-- > "Z" Rock Win


            string[] input = File.ReadAllText("Day2Input.txt").Split(Environment.NewLine);

            foreach (string game in input)
            {
                char[] chars = game.ToCharArray();
                var gameScore = GetTotalGameScorePuzzle2(chars[0], chars[2]);
                //gameScoreList.Add(game, gameScore);
                totalGameScorePuzzle2 += gameScore;

            }

            Console.WriteLine($"Total Game Score - {totalGameScorePuzzle2}");

        }

        public static int GetTotalGameScore(char firstLetter, char secondLetter)
        {
            int totalGameScore = 0;
            switch (firstLetter)
            {
                case 'A':
                    if(secondLetter == 'X')
                    {
                        totalGameScore += X + Draw;
                    }
                    else if(secondLetter == 'Y'){
                        totalGameScore += Y + Win;
                    }
                    else if (secondLetter == 'Z')
                    {
                        totalGameScore += Z + Lose;
                    }
                    break;
                case 'B':
                    if (secondLetter == 'X')
                    {
                        totalGameScore += X + Lose;
                    }
                    else if (secondLetter == 'Y')
                    {
                        totalGameScore += Y + Draw;
                    }
                    else if (secondLetter == 'Z')
                    {
                        totalGameScore += Z + Win;
                    }
                    break;
                case 'C':
                    if (secondLetter == 'X')
                    {
                        totalGameScore += X + Lose;
                    }
                    else if (secondLetter == 'Y')
                    {
                        totalGameScore += Y + Draw;
                    }
                    else if (secondLetter == 'Z')
                    {
                        totalGameScore += Z + Win;
                    }
                    break;
               

            }
            return totalGameScore;

        }


        public static int GetTotalGameScorePuzzle2(char firstLetter, char secondLetter)
        {
            int totalGameScore = 0;
            switch (firstLetter)
            {
                case 'A':
                    if (secondLetter == 'X')
                    {
                        totalGameScore += Sissor + Lose;
                    }
                    else if (secondLetter == 'Y')
                    {
                        totalGameScore += Rock + Draw;
                    }
                    else if (secondLetter == 'Z')
                    {
                        totalGameScore += Paper + Win;
                    }
                    break;
                case 'B':
                    if (secondLetter == 'X')
                    {
                        totalGameScore += Rock + Lose;
                    }
                    else if (secondLetter == 'Y')
                    {
                        totalGameScore += Paper + Draw;
                    }
                    else if (secondLetter == 'Z')
                    {
                        totalGameScore += Sissor + Win;
                    }
                    break;
                case 'C':
                    if (secondLetter == 'X')
                    {
                        totalGameScore += Paper + Lose;
                    }
                    else if (secondLetter == 'Y')
                    {
                        totalGameScore += Sissor + Draw;
                    }
                    else if (secondLetter == 'Z')
                    {
                        totalGameScore += Rock + Win;
                    }
                    break;

            }
            return totalGameScore;

        }
    }
}
