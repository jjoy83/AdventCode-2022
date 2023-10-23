using System;
using System.Collections.Generic;
using System.Text;

namespace AdventCode2022.Model
{
    public class Day7Node
    {
        public string Name { get; set; }
        public List<Day7File> Files { get; set; } = new List<Day7File>();
        public Day7Node Parent { get; set; }
        public List<Day7Node> Children { get; set; } = new List<Day7Node>();

        public double TotalFileSize
        {
            get
            {
                double totalSize = 0;
                foreach (Day7File file in Files)
                {
                    totalSize += file.Size;
                }
                return totalSize;

            }
        }
    }
}
