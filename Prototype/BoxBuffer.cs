using Pastel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Prototype
{
    public class BoxBuffer : Square
    {
        public struct Sides
        {
            public bool Top, Left, Right, Bottom;
        }

        public Box Buffered;
        private int BufferWidth;
        public Sides Collapsed;

        public BoxBuffer(Box b, int Width) : base(b.Size.X + 2*Width, b.Size.Y+2*Width)
        {
            Position.X = b.Position.X - Width;
            Position.Y = b.Position.Y - Width;
            Buffered = b;
            BufferWidth = Width;
        }

        public static void CollapseBuffers(List<Square> Boxes, int[,] floorplan, int Length, int Width)
        {
            foreach (Square S in Boxes)
            {
                if (S is BoxBuffer)
                {
                    BoxBuffer movable = S as BoxBuffer;
                    if (movable.Position.Y == 1 && !movable.Collapsed.Top) movable.CollapseTop();
                    if (movable.Position.Y + movable.Size.Y == Width && !movable.Collapsed.Bottom) movable.CollapseBottom();
                    if (movable.Position.X == 1 && !movable.Collapsed.Left) movable.CollapseLeft();
                    if (movable.Position.X + movable.Size.X == Length && !movable.Collapsed.Right) movable.CollapseRight();
                }
            }
        }

        public void CollapseLeft()
        {
            Size.X--;
            Buffered.Position.X--;
            Position.X = Buffered.Position.X;
            Collapsed.Left = true;
        }

        public void CollapseTop()
        {
            Size.Y--;
            Buffered.Position.Y--;
            Position.Y = Buffered.Position.Y;
            Collapsed.Top = true;
        }

        public void CollapseRight()
        {
            Size.X--;
            Buffered.Position.X++;
            Position.X++;
            Collapsed.Right = true;
        }

        public void CollapseBottom()
        {
            Size.Y--;
            Buffered.Position.Y++;
            Position.Y++;
            Collapsed.Bottom = true;
        }

        public void Draw()
        {
            for (int y = Position.Y; y < Position.Y + Size.Y; y++)
            {
                for (int x = Position.X; x < Position.X + Size.X; x++)
                {
                    if (x > Buffered.Size.X || x < Buffered.Position.X ||
                        y > Buffered.Size.Y || y < Buffered.Position.X)
                    {
                        Console.SetCursorPosition(x * 2-1, y);
                        Console.Write("\u2588\u2588".Pastel("#FFE5B4"));
                    }
                }
            }
        }
    }
}
