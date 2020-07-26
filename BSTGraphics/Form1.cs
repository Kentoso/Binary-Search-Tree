using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            formGraphics = this.CreateGraphics();
            List<int> values = new List<int>() { 10, 9, 12, 13, 4, 5, 3, 7, 8, 14, 2, 6, 1 };
            Tree tree = new Tree();
            tree.CreateTree(values);
            Draw.DrawTree(tree, formGraphics);
            
        }
        private void Form1_Load(object sender, System.EventArgs e)
        {

        }
        protected override void OnPaint(PaintEventArgs e)
        {

        }
    }
}
