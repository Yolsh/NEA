using System;
using System.Collections.Generic;
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
        public BoxBuffer b;
        public Square.Dimensions Position;
        public Square.Dimensions Size;

        public SortNode(Square.Dimensions size, Square.Dimensions location)
        {
            this.Size = size;
            this.Area = Size.X * Size.Y;
            Position = location;
        }

        public static void AddBox(BoxBuffer b, SortNode root)
        {
            if (root.b is null)
            {
                root.b = b;
                root.Left = new SortNode(Square.DimCreate(root.Size.X - b.Size.X, b.Size.Y), Square.DimCreate(root.Position.X + b.Size.X, root.Position.Y));
                root.Right = new SortNode(Square.DimCreate(root.Size.X, root.Size.Y - b.Size.Y), Square.DimCreate(root.Position.X, root.Position.Y + b.Size.Y));
            }
            else if (b.Size.Y <= root.Left.Size.Y && b.Size.X <= root.Left.Size.X) AddBox(b, root.Left);
            else if (b.Size.Y <= root.Right.Size.Y && b.Size.X <= root.Right.Size.X) AddBox(b, root.Right);
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
            root.b.Buffered.SetPosition(root.b.Buffered.Position.X + XMov, root.b.Buffered.Position.Y + YMov);
            root.b.SetPosition(root.Position.X, root.Position.Y);
            CorrectPositions(root.Left);
            CorrectPositions(root.Right);
        }
    }
}
