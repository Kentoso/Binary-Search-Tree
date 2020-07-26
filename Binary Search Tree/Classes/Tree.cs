using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Diagnostics;
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
        public void GenerateNode(Node root, int value)
        {
            if (value > 0)
            {
                if (root.LeftChild == null && value < root.Value)
                {
                    root.LeftChild = new Node(value);
                    root.LeftChild.ParentNode = root;
                    Nodes.Add(root.LeftChild);
                }
                else if (root.LeftChild != null && value < root.Value)
                {
                    GenerateNode(root.LeftChild, value);
                }
                if (root.RightChild == null && value > root.Value)
                {
                    root.RightChild = new Node(value);
                    root.RightChild.ParentNode = root;
                    Nodes.Add(root.RightChild);
                }
                else if (root.RightChild != null && value > root.Value)
                {
                    GenerateNode(root.RightChild, value);
                }
            }
        }
        public void DeleteNode(int value, ref List<int> values)
        {
            Nodes = Nodes.Where(x => x.Value != value).ToList();
            values = values.Where(x => x != value).ToList();
            
            foreach (var node in Nodes)
            {
                if (node.RightChild != null)
                {
                    if (node.RightChild.Value == value)
                    {
                        GenerateNode(Root, values);
                    }
                }

                if (node.LeftChild != null)
                {
                    if (node.LeftChild.Value == value)
                    {
                        GenerateNode(Root, values);
                    }
                }
                
            }
            GenerateNode(Root, values);
        }

        public string SearchNode(Node root, int value, bool findId = false)
        {
            if (!findId)
            {
                if (value > root.Value)
                {
                    if (root.RightChild != null)
                    {
                        return "Right " + SearchNode(root.RightChild, value);
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (value < root.Value)
                {
                    if (root.LeftChild != null)
                    {
                        return "Left " + SearchNode(root.LeftChild, value);
                    }
                    else
                    {
                        return "";
                    }
                }
                else if (value == root.Value)
                {
                    Debug.WriteLine($"Found!: {value}");
                    return "Found";
                }
                else
                {
                    Debug.WriteLine("Haven't found");
                    return "";
                }
            }
            else
            {
                if (value > root.Value)
                {
                    if (root.RightChild != null)
                    {
                        return SearchNode(root.RightChild, value);
                    }
                    else
                    {
                        return "-1";
                    }
                }
                else if (value < root.Value)
                {
                    if (root.LeftChild != null)
                    {
                        return SearchNode(root.LeftChild, value);
                    }
                    else
                    {
                        return "-1";
                    }
                }
                else if (value == root.Value)
                {
                    Debug.WriteLine($"Found!: {value}");
                    return root.Id.ToString();
                }
                else
                {
                    Debug.WriteLine("Haven't found");
                    return "-1";
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