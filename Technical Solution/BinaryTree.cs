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
            CorrectPositions(root.Left);
            CorrectPositions(root.Right);
            root.b.Position = new Point(root.Position.X + root.b.buffer.BufferWidth, root.Position.Y + root.b.buffer.BufferWidth);
            root.b.buffer.Position = root.Position;
            if (root.Left.b != null)
            {
                root.b.CollapseRight();
                MoveLeft(root.Left);
            }
            if (root.Right.b != null)
            {
                root.b.CollapseBottom();
                MoveUp(root.Right);
            }
            if (root.b.buffer.Position.X == 0)
            {
                root.b.CollapseLeft();
                MoveLeft(root.Left);
            }
            if (root.b.buffer.Position.Y == 0)
            {
                root.b.CollapseTop();
                MoveUp(root.Right);
            }
            return;
        }


        private static void MoveLeft(SortNode ToMove)
        {
            if (ToMove.b == null) return;
            ToMove.b.buffer.Position.X -= ToMove.b.buffer.BufferWidth;
            ToMove.b.Position.X -= ToMove.b.buffer.BufferWidth;
            if (ToMove.Left.b == null) ToMove.b.CollapseLeft();
            if (ToMove.Right.b == null) ToMove.b.CollapseTop();
            MoveLeft(ToMove.Left);
            MoveLeft(ToMove.Right);
        }

        private static void MoveUp(SortNode ToMove)
        {
            if (ToMove.b == null) return;
            ToMove.b.buffer.Position.Y -= ToMove.b.buffer.BufferWidth;
            ToMove.b.Position.Y -= ToMove.b.buffer.BufferWidth;
            if (ToMove.Left.b == null) ToMove.b.CollapseLeft();
            if (ToMove.Right.b == null) ToMove.b.CollapseTop();
            MoveUp(ToMove.Left);
            MoveUp(ToMove.Right);
        }
    }
}
