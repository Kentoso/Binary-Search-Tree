using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Search_Tree.Classes
{
    public class Node
    {
        public int Id { get; set; }
        public Node ParentNode { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
        public int Value { get; set; }

        private static int globalId { get; set; }

        public Node(int value)
        {
            Id = globalId++;
            Value = value;
        }


    }
}
