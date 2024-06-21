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
        Box Buffered;
        int BufferWidth;
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
                    if (movable.Position.Y - movable.BufferWidth == 0) movable.CollapseTop();
                    if (movable.Position.Y + 2 * movable.BufferWidth +1 == Width) movable.CollapseBottom();
                    if (movable.Position.X - movable.BufferWidth == 0) movable.CollapseLeft();
                    if (movable.Position.X + 2* movable.BufferWidth + 1== Length) movable.CollapseRight();
                    //check against floorplan if the buffer can be shrunk.
                }
            }
        }

        public void CollapseLeft()
        {
            Size.X--;
            Buffered.Position.X--;
            Position.X = Buffered.Position.X;
        }

        public void CollapseTop()
        {
            Size.Y--;
            Buffered.Position.Y--;
            Position.Y = Buffered.Position.Y;
        }

        public void CollapseRight()
        {
            Size.X--;
            Buffered.Position.X++;
            Position.X++;
        }

        public void CollapseBottom()
        {
            Size.Y--;
            Buffered.Position.Y++;
            Position.Y++;
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
