using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Binary_Search_Tree.Classes;

namespace BSTGraphics.Classes
{
    class Draw
    {
        public static void DrawTree(Tree tree, Graphics graphics)
        {
            DrawNode(tree.Root, graphics, (400, 0));
            graphics.Dispose();
      
        }
        private static void DrawNode(Node node, Graphics graphics, (int x, int y) position)
        {
            StringFormat sf = new StringFormat();
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            graphics.FillEllipse(myBrush, new Rectangle(position.x, position.y, 50, 50));
            graphics.DrawString(node.Value.ToString(), new Font(FontFamily.GenericSansSerif, 10), Brushes.White, new Rectangle(position.x, position.y, 50, 50), sf);
            if (node.RightChild != null && node.LeftChild != null)
            {
                graphics.DrawLine(new Pen(Color.Black, 2), position.x + 35, position.y + 35, position.x + 75, position.y + 75);
                graphics.DrawLine(new Pen(Color.Black, 2), position.x + 15, position.y + 35, position.x - 25, position.y + 75);
                DrawNode(node.RightChild, graphics, (position.x + 50, position.y + 50));
                DrawNode(node.LeftChild, graphics, (position.x - 50, position.y + 50));
            }
            else if (node.RightChild != null)
            {
                graphics.DrawLine(new Pen(Color.Black, 2), position.x + 35, position.y + 35, position.x + 75, position.y + 75);
                DrawNode(node.RightChild, graphics, (position.x + 50, position.y + 50));
            }
            else if (node.LeftChild != null)
            {
                graphics.DrawLine(new Pen(Color.Black, 2), position.x + 15, position.y + 35, position.x - 25, position.y + 75);
                DrawNode(node.LeftChild, graphics, (position.x - 50, position.y + 50));
            }
            myBrush.Dispose();
        }
    }
}
