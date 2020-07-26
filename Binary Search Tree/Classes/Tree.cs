using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Binary_Search_Tree.Classes
{
    public class Tree
    {
        public Node Root { get; set; }
        public List<Node> Nodes { get; set; }

        public Tree()
        {
            Nodes = new List<Node>();
        }

        public void CreateTree(List<int> values)
        {
            if (Root != null)
            {
                GenerateNode(Root, values);
            }
            else
            {
                Root = new Node(values[0]);
                Nodes.Add(Root);
                CreateTree(values.Skip(1).ToList());
            }
        }

        private void GenerateNode(Node root, List<int> values)
        {
            if (values.Count > 0)
            {
                if (root.LeftChild == null && values[0] < root.Value)
                {
                    root.LeftChild = new Node(values[0]);
                    root.LeftChild.ParentNode = root;
                    Nodes.Add(root.LeftChild);
                    GenerateNode(Root, values.Skip(1).ToList());
                }
                else if (root.LeftChild != null && values[0] < root.Value)
                {
                    GenerateNode(root.LeftChild, values);
                }
                if (root.RightChild == null && values[0] > root.Value)
                {
                    root.RightChild = new Node(values[0]);
                    root.RightChild.ParentNode = root;
                    Nodes.Add(root.RightChild);
                    GenerateNode(Root, values.Skip(1).ToList());
                }
                else if (root.RightChild != null && values[0] > root.Value)
                {
                    GenerateNode(root.RightChild, values);
                }
            }
        }
        public void Draw()
        {
            foreach (var node in Nodes)
            {

                if (node.LeftChild != null && node.RightChild != null)
                {
                    Console.WriteLine($"Node:  {node.Value}");
                    Console.WriteLine("     /    \\");
                    Console.WriteLine($"    {node.LeftChild.Value}     {node.RightChild.Value}");
                    Console.WriteLine();
                }
                else if (node.LeftChild != null)
                {
                    Console.WriteLine($"Node:  {node.Value}");
                    Console.WriteLine("     /");
                    Console.WriteLine($"    {node.LeftChild.Value}");
                    Console.WriteLine();
                }
                else if (node.RightChild != null)
                {
                    Console.WriteLine($"Node:  {node.Value}");
                    Console.WriteLine("          \\");
                    Console.WriteLine($"          {node.RightChild.Value}");
                    Console.WriteLine();
                }
            }
        }
    }
}