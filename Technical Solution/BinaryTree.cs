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
        public Box b;
        public Point Position;
        public Size Size;

        public SortNode(Size size, Point location)
        {
            this.Size = size;
            Position = location;
        }

        public static void AddBox(Box b, SortNode root)
        {
            if (root.b is null)
            {
                root.b = b;
                root.Left = new SortNode(new Size(root.Size.Width - b.buffer.Size.Width, b.buffer.Size.Height), new Point(root.Position.X + b.buffer.Size.Width, root.Position.Y));
                root.Right = new SortNode(new Size(root.Size.Width, root.Size.Height - b.buffer.Size.Height), new Point(root.Position.X, root.Position.Y + b.buffer.Size.Height));
            }
            else if (b.buffer.Size.Height <= root.Left.Size.Height && b.buffer.Size.Width <= root.Left.Size.Width) 
            {
                try
                {
                    AddBox(b, root.Left);
                }
                catch (IncorrectPlacementException)
                {
                    AddBox(b, root.Right);
                }
            }
            else if (b.buffer.Size.Height <= root.Right.Size.Height && b.buffer.Size.Width <= root.Right.Size.Width) AddBox(b, root.Right);
            else
            {
                throw new IncorrectPlacementException();
            }
        }

        public static void CorrectPositions(SortNode root)
        {
            if (root.b is null) return;
            root.b.Position = new Point(root.Position.X + root.b.buffer.BufferWidth, root.Position.Y + root.b.buffer.BufferWidth);
            root.b.buffer.Position = root.Position;
            CorrectPositions(root.Left);
            CorrectPositions(root.Right);
        }

        public static string CorrectPositions(SortNode root, string output)
        {
            if (root.b is null) return output += $"|{root.Position.X}, {root.Position.Y}|, ";
            output = CorrectPositions(root.Left, output);
            output = CorrectPositions(root.Right, output);
            root.b.Position = new Point(root.Position.X + root.b.buffer.BufferWidth, root.Position.Y + root.b.buffer.BufferWidth);
            root.b.buffer.Position = root.Position;
            return output += $"({root.Position.X}, {root.Position.Y}), ";
        }
    }
}
