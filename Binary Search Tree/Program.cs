using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Binary_Search_Tree.Classes;

namespace Binary_Search_Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> values = new List<int>() {10, 9, 12, 13, 4, 5, 3, 7, 8, 14, 2, 6, 1};
            Tree tree = new Tree();
            tree.CreateTree(values);
            int id = tree.SearchNode(tree.Root, 5);
            Debug.WriteLine(id);
            tree.DeleteNode(12, ref values);
            tree.Draw();
            Console.ReadKey();
        }
    }
}
