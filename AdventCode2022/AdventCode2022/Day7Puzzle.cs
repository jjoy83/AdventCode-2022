using AdventCode2022.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.IO;
using System.Text;

namespace AdventCode2022
{

    public static class Day7Puzzle
    {
        static List<Day7Node> Directories = new List<Day7Node>();
        static double TotalDeletableSize = 0;
        private static void LoadData()
        {
            Day7Node current = null;
            string[] input = File.ReadAllLines("Day7Input.txt");
            Day7Node root = new Day7Node()
            {
                Name = "/",
                Parent = null,
            };
            Directories.Add(root);
            int i = 0;
            while (i < input.Length - 1)
            {
                string[] lineItems = input[i].Split(' ');

                if (lineItems[0] == "$")
                {
                    switch (lineItems[1])
                    {
                        case "cd":

                            if (lineItems[2] == "/")
                            {
                                current = root;
                            }
                            else if (lineItems[2] == "..")
                            {
                                current = current.Parent;
                            }
                            else
                            {
                                var node = FindNodeByName(lineItems[2], current);
                                if (node != null)
                                {
                                    node.Parent = current;
                                    current = node;
                                }
                            }
                            i++;
                            break;
                        case "ls":
                            int j = i + 1;
                            //var items = ;
                            while (j < input.Length && input[j].Split(' ')[0] != "$")
                            {
                                if (double.TryParse(input[j].Split(' ')[0], out double size))
                                {
                                    Day7File file = new Day7File()
                                    {
                                        Size = size,
                                        Name = input[j].Split(' ')[1]
                                    };
                                    current.Files.Add(file);
                                }
                                else if (input[j].Split(' ')[0] == "dir")
                                {
                                    CreateNode(input[j].Split(' ')[1], current);
                                }
                                j++;
                            }
                            i = j;
                            break;
                    }
                }
            }
        }
        private static Day7Node FindNodeByName(string name, Day7Node current)
        {
            Day7Node node = null;
            node = Directories.Find(x => x.Name == name && current.Children.Contains(x));
            return node;
        }
        private static Day7Node CreateNode(string name, Day7Node current)
        {
            Day7Node node = null;
            node = Directories.Find(x => x.Name == name && x.Parent == current);
            if (node == null)
            {
                node = new Day7Node()
                {
                    Name = name
                   
                };
                current.Children.Add(node);
                Directories.Add(node);
            }

            return node;
        }

        public static void GetTotalSizeOfAllDeletableDirectories()
        {
            Console.WriteLine("Starting Day7 Puzzle1!");
            LoadData();
            TotalDeletableSize = 0;
            //double totalSize = 0;
            foreach (Day7Node node in Directories)
            {
                double totalSize = GetTotalDirectorySizeOfNode(node);
                //totalSize += node.TotalFileSize;
                if (totalSize < 100000)
                {
                    TotalDeletableSize += totalSize;
                }
            }

            Console.WriteLine($"Total Directory Size {TotalDeletableSize}");
            //FindNodeWithDeletableSize();
        }

        public static void GetSmallestDirectoryToDelete()
        {
            Console.WriteLine("Starting Day7 Puzzle2!");
            LoadData();
            double totalDiskSize = 70000000;
            double totalSizeNeededForUpdate = 30000000;
            double totalUsedSpace = GetTotalDirectorySizeOfNode(Directories.Find(x=>x.Name == "/"));
            double totalSpaceToDelete = totalSizeNeededForUpdate - (totalDiskSize - totalUsedSpace);
            double totalDirectorySpaceToDelete = 0;
            int i = 0;
            foreach (Day7Node node in Directories)
            {
                double totalSize = GetTotalDirectorySizeOfNode(node);
                //totalSize += node.TotalFileSize;
                if (totalSize >= totalSpaceToDelete)
                {
                    if (totalDirectorySpaceToDelete == 0)
                    {
                        totalDirectorySpaceToDelete = totalSize;
                    }
                    else if((totalDirectorySpaceToDelete - totalSpaceToDelete )> (totalSize - totalSpaceToDelete))
                    {
                        totalDirectorySpaceToDelete = totalSize;
                        Console.WriteLine($"Total Directory Size {totalDirectorySpaceToDelete}");
                    }
                   
                    string parent = node.Parent != null ? node.Parent.Name : string.Empty; 
                    Console.WriteLine($"Node is {node.Name}. node parent {parent}");
                    
                }
                i++;
                Console.WriteLine($"Loop Counter {i}");
            }

            Console.WriteLine($"Total Directory Size {totalDirectorySpaceToDelete}");
            //FindNodeWithDeletableSize();
        }

        private static void FindNodeWithDeletableSize(Day7Node node)
        {
            double totalSize = 0;
            foreach (Day7Node childNode in node.Children)
            {
                totalSize = GetTotalDirectorySizeOfNode(childNode);
                if (totalSize < 100000)
                {
                    TotalDeletableSize += totalSize;
                }

                FindNodeWithDeletableSize(childNode);

            }
        }

        private static double GetTotalDirectorySizeOfNode(Day7Node node)
        {
            double size = node.TotalFileSize;

            foreach (Day7Node childNode in node.Children)
            {
                size += GetTotalDirectorySizeOfNode(childNode);
            }
            return size;
        }
    }
}
