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

        public static void CollapseBuffers(List<Square> Boxes, int Length, int Width)
        {
            foreach (Square S in Boxes)
            {
                if (S is BoxBuffer)
                {
                    BoxBuffer movable = S as BoxBuffer;

                    //collapse buffers when touching walls.
                    if (movable.Position.Y == 0 && !movable.Collapsed.Top) movable.CollapseTop();
                    if (movable.Position.Y + movable.Size.Y >= Width && !movable.Collapsed.Bottom) movable.CollapseBottom();
                    if (movable.Position.X == 0 && !movable.Collapsed.Left) movable.CollapseLeft();
                    if (movable.Position.X + movable.Size.X >= Length && !movable.Collapsed.Right) movable.CollapseRight();
                }
            }
        }

        public static void ResetBuffers(List<Square> Boxes) //needs to work with other minimum widths
        {
            foreach (Square S in Boxes)
            {
                if (S is BoxBuffer)
                {
                    BoxBuffer reset = S as BoxBuffer;
                    if (reset.Collapsed.Left)
                    {
                        reset.Size.X++;
                        reset.Buffered.Position.X++;
                        reset.Collapsed.Left = false;
                    }
                    if (reset.Collapsed.Right)
                    {
                        reset.Size.X++;
                        reset.Buffered.Position.X--;
                        reset.Position.X--;
                        reset.Collapsed.Right = false;
                    }
                    if (reset.Collapsed.Top)
                    {
                        reset.Size.Y++;
                        reset.Buffered.Position.Y++;
                        reset.Collapsed.Top = false;
                    }
                    if (reset.Collapsed.Bottom)
                    {
                        reset.Size.Y++;
                        reset.Buffered.Position.Y--;
                        reset.Position.Y--;
                        reset.Collapsed.Bottom = false;
                    }
                }
            }
        }

        private void CollapseLeft()
        {
            Size.X--;
            Buffered.Position.X = Position.Y;
            Collapsed.Left = true;
        }

        private void CollapseTop()
        {
            Size.Y-=BufferWidth;
            Buffered.Position.Y--;
            Collapsed.Top = true;
        }

        private void CollapseRight()
        {
            Size.X--;
            Buffered.Position.X++;
            Position.X++;
            Collapsed.Right = true;
        }

        private void CollapseBottom()
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
                    if (x > Buffered.Size.X-1 || x < Buffered.Position.X+1 ||
                        y > Buffered.Size.Y-1 || y < Buffered.Position.X+1)
                    {
                        Console.SetCursorPosition(x * 2+1, y+1);
                        Console.Write("\u2588\u2588".Pastel("#FFE5B4"));
                    }
                }
            }
        }
    }
}
