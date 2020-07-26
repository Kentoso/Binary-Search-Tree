using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binary_Search_Tree.Classes;
using BSTGraphics.Classes;

namespace BSTGraphics
{
    public partial class Form1 : Form
    {
        System.Drawing.Graphics formGraphics;
        private Tree tree;
        private List<int> values;
        public Form1()
        {
            InitializeComponent();
            tree = new Tree();
            values = new List<int>() { 10, 9, 12, 13, 4, 5, 3, 7, 8, 14, 2, 6, 1 };
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(textBox1.Text);
                values.Add(num);
                tree.GenerateNode(tree.Root, num);
            }
            catch (FormatException)
            {
                textBox1.Text = "";
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            formGraphics = this.CreateGraphics();
            tree.CreateTree(values);
            Draw.DrawTree(tree, formGraphics);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(textBox2.Text);
                values = values.Where(x => x != num).ToList();
                tree = new Tree();
            }
            catch (FormatException)
            {
                textBox1.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(textBox3.Text);
                label1.Text = tree.SearchNode(tree.Root, num);
            }
            catch (FormatException)
            {
                textBox1.Text = "";
            }
        }
    }
}
