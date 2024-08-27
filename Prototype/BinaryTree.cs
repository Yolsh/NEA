using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class SortNode
    {
        public SortNode Right;
        public SortNode Down;
        public int Area;
        public BoxBuffer b;
        public Square.Dimensions Position;
        public Square.Dimensions Size;

        public SortNode(Square.Dimensions location, Square.Dimensions size)
        {
            this.Size = size;
            this.Area = Size.X * Size.Y;
            Position = location;
        }

        public static void AddBox(BoxBuffer b, SortNode root)
        {
            SortNode fit = FindNode(root, b.Size.X, b.Size.Y);

            if (fit != null)
            {
                fit.b = b;
                fit.Right = new SortNode(Square.DimCreate(fit.Position.X + b.Size.X, b.Position.Y), Square.DimCreate(fit.Size.X - b.Size.X, fit.Size.Y));
                fit.Down = new SortNode(Square.DimCreate(fit.Position.X, fit.Position.Y + b.Size.Y), Square.DimCreate(fit.Size.X, fit.Size.Y - b.Size.Y));
            }
            else
            {
                throw new IncorrectPlacementException();
            }
        }

        private static SortNode FindNode(SortNode root, int length, int width)
        {
            if (root.b != null)
            {
                SortNode r = FindNode(root.Right, length, width);
                if (r != null) return r;
                SortNode l = FindNode(root.Down, length, width);
                if (l != null) return l;
            }
            else if (width <= root.Size.Y && length <= root.Size.X)
            {
                return root;
            }
            return null;
        }

        public static void CorrectPositions(SortNode root)
        {
            if (root.b is null) return;
            int XMov = root.Position.X - root.b.Position.X;
            int YMov = root.Position.Y - root.b.Position.Y;
            root.b.Buffered.SetPosition(root.b.Buffered.Position.X + XMov, root.b.Buffered.Position.Y + YMov);
            root.b.SetPosition(root.Position.X, root.Position.Y);
            CorrectPositions(root.Right);
            CorrectPositions(root.Down);
        }
    }
}
