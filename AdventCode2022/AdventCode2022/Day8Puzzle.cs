using AdventCode2022.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;

namespace AdventCode2022
{
    public static class Day8Puzzle
    {
        private static int[,] ForestArray;
        //private static int[] VisibleTrees;
        private static void LoadData()
        {

            ForestArray = new int[99, 99];

            string[] input = File.ReadAllLines("Day8Input.txt");
            for (int row = 0; row < input.Length; row++)
            {
                char[] trees = input[row].ToCharArray();
                for (int col = 0; col < trees.Length; col++)
                {
                    ForestArray[row, col] = int.Parse(trees[col].ToString());
                }
            }

        }

        public static void NumberOfTreesVisiblePuzzle1()
        {
            Console.WriteLine("Starting Day8 Puzzle1!");

            LoadData();
            int count = 0;

            for (int row = 0; row <= ForestArray.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= ForestArray.GetUpperBound(1); col++)
                {


                    if(row==0 || col==0|| row == ForestArray.GetUpperBound(0) || col == ForestArray.GetUpperBound(1) || IsVisibleFromBottom(row, col) || IsVisibleFromTop(row, col) || IsVisibleFromLeft(row, col) || IsVisibleFromRight(row, col))
                    {
                        count++;
                    }

                }

            }
            Console.WriteLine($"Total Number of Visible Trees {count}");
        }

        public static void TreeSscorePuzzle2()
        {
            Console.WriteLine("Starting Day8 Puzzle2!");
            double maxTreeScore = 0;

            LoadData();

            for (int row = 0; row <= ForestArray.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= ForestArray.GetUpperBound(1); col++)
                {

                    double score = TreeScoreFromBottom(row, col) * TreeScoreFromLeft(row, col) * TreeScoreFromRight(row, col) * TreeScoreFromTop(row, col) ;

                    if(score > maxTreeScore)
                    {
                        maxTreeScore = score ;
                    }

                }

            }
            Console.WriteLine($"Max Tree score {maxTreeScore}");
        }

        private static bool IsVisibleFromTop(int row, int col)
        {
            bool isVisible = true;

            int i = row - 1;

            while (i >= 0)
            {
                if (ForestArray[i, col] >= ForestArray[row, col])
                {
                    isVisible = false;
                    break;
                }
                else
                {
                    i--;
                    continue;
                }
            }
            return isVisible;

        }

        private static bool IsVisibleFromBottom(int row, int col)
        {
            bool isVisible = true;

            int i = row + 1;

            while (i <= ForestArray.GetUpperBound(0))
            {
                if (ForestArray[i, col] >= ForestArray[row, col])
                {
                    isVisible = false;
                    break;
                }
                else
                {
                    i++;
                    continue;
                }
            }
            return isVisible;
        }

        private static bool IsVisibleFromLeft(int row, int col)
        {
            bool isVisible = true;

            int i = col - 1;

            while (i >= 0)
            {
                if (ForestArray[row, i] >= ForestArray[row, col])
                {
                    isVisible = false;
                    break;
                }
                else
                {
                    i--;
                    continue;
                }
              
            }
            return isVisible;
        }

        private static bool IsVisibleFromRight(int row, int col)
        {
            bool isVisible = true;

            int i = col + 1;

            while (i <= ForestArray.GetUpperBound(1))
            {
                if (ForestArray[row, i] >= ForestArray[row, col])
                {
                    isVisible = false;
                    break;
                }
                else
                {
                    i++;
                    continue;
                }
            }
            return isVisible;
        }

        private static int TreeScoreFromTop(int row, int col)
        {
            int score = 0;

            int i = row - 1;

            while (i >= 0)
            {
                if (ForestArray[i, col] >= ForestArray[row, col])
                {
                    score++;
                    break;
                }
                else
                {
                    i--;
                    score++;
                    continue;
                }
            }
            return score;

        }

        private static int TreeScoreFromBottom(int row, int col)
        {
            int score = 0;

            int i = row + 1;

            while (i <= ForestArray.GetUpperBound(0))
            {
                if (ForestArray[i, col] >= ForestArray[row, col])
                {
                    score++;
                    break;
                }
                else
                {
                    i++;
                    score++;
                    continue;
                }
            }
            return score;
        }

        private static int TreeScoreFromLeft(int row, int col)
        {
            int score = 0;

            int i = col - 1;

            while (i >= 0)
            {
                if (ForestArray[row, i] >= ForestArray[row, col])
                {
                    score++;
                    break;
                }
                else
                {
                    i--;
                    score++;
                    continue;
                }

            }
            return score;
        }

        private static int TreeScoreFromRight(int row, int col)
        {
            int score = 0;

            int i = col + 1;

            while (i <= ForestArray.GetUpperBound(1))
            {
                if (ForestArray[row, i] >= ForestArray[row, col])
                {
                    score++;
                    break;
                }
                else
                {
                    i++;
                    score++;
                    continue;
                }
            }
            return score;
        }
    }
}
