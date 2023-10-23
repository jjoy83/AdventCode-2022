using AdventCode2022.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace AdventCode2022
{
    public static class Day9Puzzle
    {
        private static List<Day9Node> visitedPositionsForTail = new List<Day9Node>();
        private static Day9Node Tail = new Day9Node();

        private static List<Day9Node> visitedPositionsForOne = new List<Day9Node>();
        private static List<Day9Node> visitedPositionsForTwo = new List<Day9Node>();
        private static List<Day9Node> visitedPositionsForThree = new List<Day9Node>();
        private static List<Day9Node> visitedPositionsForFour = new List<Day9Node>();
        private static List<Day9Node> visitedPositionsForFive = new List<Day9Node>();
        private static List<Day9Node> visitedPositionsForSix = new List<Day9Node>();
        private static List<Day9Node> visitedPositionsForSeven = new List<Day9Node>();
        private static List<Day9Node> visitedPositionsForEight = new List<Day9Node>();
        private static List<Day9Node> visitedPositionsForNine = new List<Day9Node>();
        private static Day9Node Head = new Day9Node() { NodeNum = 0 };
        private static Day9Node One = new Day9Node() { NodeNum = 1 };
        private static Day9Node Two = new Day9Node() { NodeNum = 2 };
        private static Day9Node Three = new Day9Node() { NodeNum = 3 };
        private static Day9Node Four = new Day9Node() { NodeNum = 4 };
        private static Day9Node Five = new Day9Node() { NodeNum = 5 };
        private static Day9Node Six = new Day9Node() { NodeNum = 6 };
        private static Day9Node Seven = new Day9Node() { NodeNum = 7 };
        private static Day9Node Eight = new Day9Node() { NodeNum = 8 };
        private static Day9Node Nine = new Day9Node() { NodeNum = 9 };

        public static void GetVisitedPositionsPuzzle1()
        {
            visitedPositionsForTail.Clear();
            string[] input = File.ReadAllLines("Day9Input.txt");
            visitedPositionsForTail.Add(new Day9Node
            {
                col = Tail.col,
                row = Tail.row
            });

            foreach (string line in input)
            {
                string[] items = line.Split(' ');
                int cnt = int.Parse(items[1]);
                int i = 1;
                while (i <= cnt)
                {
                    switch (items[0])
                    {
                        case "L":
                            Head.row -= 1;
                            break;
                        case "R":
                            Head.row += 1;
                            break;
                        case "U":
                            Head.col -= 1;
                            break;
                        case "D":
                            Head.col += 1;
                            break;

                    }

                    TraverseNode(Head, Tail, visitedPositionsForTail);
                    i++;
                }

            }

            Console.WriteLine($"Visited Position - {visitedPositionsForTail.Count()}");
        }

        public static void GetVisitedPositionsPuzzle2()
        {
            string[] input = File.ReadAllLines("Day9Input.txt");

            visitedPositionsForOne.Add(new Day9Node
            {
                col = One.col,
                row = One.row
            });

            visitedPositionsForTwo.Add(new Day9Node
            {
                col = Two.col,
                row = Two.row
            });

            visitedPositionsForThree.Add(new Day9Node
            {
                col = Three.col,
                row = Three.row
            });

            visitedPositionsForFour.Add(new Day9Node
            {
                col = Four.col,
                row = Four.row
            });

            visitedPositionsForFive.Add(new Day9Node
            {
                col = Five.col,
                row = Five.row
            });

            visitedPositionsForSix.Add(new Day9Node
            {
                col = Six.col,
                row = Six.row
            });

            visitedPositionsForSeven.Add(new Day9Node
            {
                col = Seven.col,
                row = Seven.row
            });

            visitedPositionsForEight.Add(new Day9Node
            {
                col = Eight.col,
                row = Eight.row
            });

            visitedPositionsForNine.Add(new Day9Node
            {
                col = Nine.col,
                row = Nine.row
            });


            foreach (string line in input)
            {
                string[] items = line.Split(' ');
                int cnt = int.Parse(items[1]);
                int i = 1;
                while (i <= cnt)
                {
                    switch (items[0])
                    {
                        case "L":
                            Head.row -= 1;
                            break;
                        case "R":
                            Head.row += 1;
                            break;
                        case "U":
                            Head.col -= 1;
                            break;
                        case "D":
                            Head.col += 1;
                            break;

                    }

                    TraverseNode(Head, One, visitedPositionsForOne);
                    TraverseNode(One, Two, visitedPositionsForTwo);
                    TraverseNode(Two, Three, visitedPositionsForThree);
                    TraverseNode(Three, Four, visitedPositionsForFour);
                    TraverseNode(Four, Five, visitedPositionsForFive);
                    TraverseNode(Five, Six, visitedPositionsForSix);
                    TraverseNode(Six, Seven, visitedPositionsForSeven);
                    TraverseNode(Seven, Eight, visitedPositionsForEight);
                    TraverseNode(Eight, Nine, visitedPositionsForNine);

                    i++;
                }

            }

            Console.WriteLine($"Visited Position - {visitedPositionsForNine.Count()}");
        }

        public static void AddNodeToVisitedNode(List<Day9Node> visitedPositions, Day9Node node)
        {
            if (visitedPositions.Find(x => x.row == node.row && x.col == node.col) == null)
            {
                visitedPositions.Add(node);
            }

        }

        private static void TraverseNode(Day9Node sourceNode, Day9Node targetNode, List<Day9Node> visitedPositions)
        {
            if (sourceNode.row == targetNode.row)
            {
                if (sourceNode.col - targetNode.col >= 2)
                {
                    targetNode.col++;
                    AddNodeToVisitedNode(visitedPositions, new Day9Node
                    {
                        col = targetNode.col,
                        row = targetNode.row
                    });
                }
                else if (targetNode.col - sourceNode.col >= 2)
                {
                    targetNode.col--;
                    AddNodeToVisitedNode(visitedPositions, new Day9Node
                    {
                        col = targetNode.col,
                        row = targetNode.row
                    });
                }

            }
            else if (sourceNode.col == targetNode.col)
            {
                if (sourceNode.row - targetNode.row >= 2)
                {
                    targetNode.row++;
                    AddNodeToVisitedNode(visitedPositions, new Day9Node
                    {
                        col = targetNode.col,
                        row = targetNode.row
                    });
                }
                else if (targetNode.row - sourceNode.row >= 2)
                {
                    targetNode.row--;
                    AddNodeToVisitedNode(visitedPositions, new Day9Node
                    {
                        col = targetNode.col,
                        row = targetNode.row
                    });
                }
            }
            else
            {
                //diagonal
                if (sourceNode.col - targetNode.col >= 2 || targetNode.col - sourceNode.col >= 2 || sourceNode.row - targetNode.row >= 2 || targetNode.row - sourceNode.row >= 2)
                {

                   /*
                    diagonal top right = x- 1, y + 1
                    diagonal top left =x-1, y - 1
                    diagonal bottom right = x+ 1, y + 1
                    diagonal bottok left = x+1, y - 1
                   */

                    if(sourceNode.row < targetNode.row)
                    {
                        if (sourceNode.col > targetNode.col)
                        {
                            targetNode.row = targetNode.row - 1;
                            targetNode.col = targetNode.col + 1;
                        }
                        else
                        {
                            targetNode.row = targetNode.row - 1;
                            targetNode.col = targetNode.col - 1;
                        }
                    }
                    else
                    {
                        if (sourceNode.col > targetNode.col)
                        {
                            targetNode.row = targetNode.row + 1;
                            targetNode.col = targetNode.col + 1;
                        }
                        else
                        {
                            targetNode.row = targetNode.row + 1;
                            targetNode.col = targetNode.col - 1;
                        }
                    }

                    AddNodeToVisitedNode(visitedPositions, new Day9Node
                    {
                        col = targetNode.col,
                        row = targetNode.row
                    });


                }
                
            }

        }

    }
}

