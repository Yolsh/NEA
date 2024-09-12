using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical_Solution
{
    public class SortNode
    {
        public SortNode Left;
        public SortNode Right;
        public int Area;
        public Box b;
        public Point Position;
        public Size Size;

        public SortNode(Size size, Point location)
        {
            this.Size = size;
            this.Area = Size.Width * Size.Height;
            Position = location;
        }

        public static void AddBox(Box b, SortNode root)
        {
            if (root.b is null)
            {
                root.b = b;
                root.Left = new SortNode(new Size(root.Size.Width - b.Size.Width, b.Size.Height), new Point(root.Position.X + b.Size.Width, root.Position.Y));
                root.Right = new SortNode(new Size(root.Size.Width, root.Size.Height - b.Size.Height), new Point(root.Position.X, root.Position.Y + b.Size.Height));
            }
            else if (b.Size.Height <= root.Left.Size.Height && b.Size.Width <= root.Left.Size.Width) AddBox(b, root.Left);
            else if (b.Size.Height <= root.Right.Size.Height && b.Size.Width <= root.Right.Size.Width) AddBox(b, root.Right);
            else
            {
                throw new IncorrectPlacementException();
            }
        }

        public static void CorrectPositions(SortNode root)
        {
            if (root.b is null) return;
            int XMov = root.Position.X - root.b.Position.X;
            int YMov = root.Position.Y - root.b.Position.Y;
            root.b.Position = new Point(root.b.Position.X + XMov, root.b.Position.Y + YMov);
            root.b.buffer.Position = new Point(root.Position.X, root.Position.Y);
            CorrectPositions(root.Left);
            CorrectPositions(root.Right);
        }
    }
}
