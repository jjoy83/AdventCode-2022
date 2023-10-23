using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AdventCode2022
{
    public static class Day5Puzzle
    {
        static Stack<string> stack1 = new Stack<string>();
        static Stack<string> stack2 = new Stack<string>();
        static Stack<string> stack3 = new Stack<string>();
        static Stack<string> stack4 = new Stack<string>();
        static Stack<string> stack5 = new Stack<string>();
        static Stack<string> stack6 = new Stack<string>();
        static Stack<string> stack7 = new Stack<string>();
        static Stack<string> stack8 = new Stack<string>();
        static Stack<string> stack9 = new Stack<string>();

        private static void LoadData()
        {
            stack1.Clear();
            stack2.Clear();
            stack3.Clear();
            stack4.Clear();
            stack5.Clear();
            stack5.Clear();
            stack6.Clear();
            stack7.Clear();
            stack8.Clear();
            stack9.Clear();

            //Stack1
            stack1.Push("F");
            stack1.Push("C");
            stack1.Push("P");
            stack1.Push("G");
            stack1.Push("Q");
            stack1.Push("R");

            //Stack2
            stack2.Push("W");
            stack2.Push("T");
            stack2.Push("C");
            stack2.Push("P");

            //Stack3
            stack3.Push("B");
            stack3.Push("H");
            stack3.Push("P");
            stack3.Push("M");
            stack3.Push("C");

            //Stack4
            stack4.Push("L");
            stack4.Push("T");
            stack4.Push("Q");
            stack4.Push("S");
            stack4.Push("M");
            stack4.Push("P");
            stack4.Push("R");

            //Stack5
            stack5.Push("P");
            stack5.Push("H");
            stack5.Push("J");
            stack5.Push("Z");
            stack5.Push("V");
            stack5.Push("G");
            stack5.Push("N");

            //Stack6
            stack6.Push("D");
            stack6.Push("P");
            stack6.Push("J");

            //Stack7
            stack7.Push("L");
            stack7.Push("G");
            stack7.Push("P");
            stack7.Push("Z");
            stack7.Push("F");
            stack7.Push("J");
            stack7.Push("T");
            stack7.Push("R");

            //Stack8
            stack8.Push("N");
            stack8.Push("L");
            stack8.Push("H");
            stack8.Push("C");
            stack8.Push("F");
            stack8.Push("P");
            stack8.Push("T");
            stack8.Push("J");

            //Stack9
            stack9.Push("G");
            stack9.Push("V");
            stack9.Push("Z");
            stack9.Push("Q");
            stack9.Push("H");
            stack9.Push("T");
            stack9.Push("C");
            stack9.Push("W");


        }

        public static void GetTopCratesPuzzle1()
        {
            LoadData();

            Console.WriteLine("Staring Day5 Puzzle1!");
            string[] input = File.ReadAllText("Day5Input.txt").Split(Environment.NewLine);

            foreach (var item in input)
            {
                var instruct = item.Split(' ');
                //instruct[1] -  number of items
                //instruct[3] - source stack number
                //instruct[5] - dest stack number
                for (int i = 0; i < int.Parse(instruct[1]); i++)
                {
                    var poppedItem = GetStackFromNumber(instruct[3]).Pop();
                    GetStackFromNumber(instruct[5]).Push(poppedItem);
                }
            }

            Console.WriteLine($"Final Message - {stack1.Pop() + stack2.Pop() + stack3.Pop() + stack4.Pop() + stack5.Pop() + stack6.Pop() + stack7.Pop() + stack8.Pop() + stack9.Pop()}");


        }

        public static void GetTopCratesPuzzle2()
        {
            LoadData();

            Console.WriteLine("Staring Day5 Puzzle1!");
            string[] input = File.ReadAllText("Day5Input.txt").Split(Environment.NewLine);

            foreach (var item in input)
            {
                var instruct = item.Split(' ');
                //instruct[1] -  number of items
                //instruct[3] - source stack number
                //instruct[5] - dest stack number

                int numberOfMoves = int.Parse(instruct[1]);
                if(numberOfMoves == 1)
                {
                    var poppedItem = GetStackFromNumber(instruct[3]).Pop();
                    GetStackFromNumber(instruct[5]).Push(poppedItem);
                }
                else
                {
                    int i = numberOfMoves;
                    string poppedItem = string.Empty;
                    while(i > 0)
                    {
                        poppedItem += GetStackFromNumber(instruct[3]).Pop();
                        i--;
                    }
                    
                    int j = numberOfMoves - 1;
                    char[] reverseItems = poppedItem.ToCharArray();
                    while(j >= 0)
                    {
                        GetStackFromNumber(instruct[5]).Push(reverseItems[j].ToString());
                        j--;
                    }
                    
                }
            }

            Console.WriteLine($"Final Message - {stack1.Pop() + stack2.Pop() + stack3.Pop() + stack4.Pop() + stack5.Pop() + stack6.Pop() + stack7.Pop() + stack8.Pop() + stack9.Pop()}");


        }

        private static Stack<string> GetStackFromNumber(string number)
        {
            Stack<string> returnStack = new Stack<string>();
            switch (number)
            {
                case "1":
                    returnStack = stack1;
                    break;
                case "2":
                    returnStack = stack2;
                    break;
                case "3":
                    returnStack = stack3;
                    break;
                case "4":
                    returnStack = stack4;
                    break;
                case "5":
                    returnStack = stack5;
                    break;
                case "6":
                    returnStack = stack6;
                    break;
                case "7":
                    returnStack = stack7;
                    break;
                case "8":
                    returnStack = stack8;
                    break;
                case "9":
                    returnStack = stack9;
                    break;

            }
            return returnStack;
        }



    }
}
