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

        public static void CollapseBuffersWalls(List<Square> Boxes, int Length, int Width)
        {
            foreach (Square S in Boxes)
            {
                if (S is BoxBuffer)
                {
                    BoxBuffer movable = S as BoxBuffer;

                    //collapse buffers when touching walls.
                    if (movable.Position.Y == 1 && !movable.Collapsed.Top) movable.CollapseTop();
                    if (movable.Position.Y + movable.Size.Y >= Width && !movable.Collapsed.Bottom) movable.CollapseBottom();
                    if (movable.Position.X == 1 && !movable.Collapsed.Left) movable.CollapseLeft();
                    if (movable.Position.X + movable.Size.X >= Length && !movable.Collapsed.Right) movable.CollapseRight();
                }
            }
        }

        public static void CollapseBuffersContact(List<Square> Boxes, int[,] floorplan, int Length, int Width)
        {
            foreach (Square S in Boxes)
            {
                if (S is BoxBuffer)
                {
                    BoxBuffer movable = S as BoxBuffer;

                    //collapse buffers covered by other buffers.
                    if (movable.Position.X - 1 > 0 && floorplan[movable.Position.Y, movable.Position.X - 1] == 1)
                    {
                        bool covered = true;
                        for (int y = movable.Position.Y - 1; y < movable.Position.Y + movable.Size.Y - 1; y++) if (floorplan[y, movable.Position.X - 2] != 1) covered = false;
                        if (covered) movable.CollapseLeft();
                    }
                    if (movable.Position.Y - 1 > 0 && floorplan[movable.Position.Y - 1, movable.Position.X] == 1)
                    {
                        bool covered = true;
                        for (int x = movable.Position.X - 1; x < movable.Position.X + movable.Size.X - 1; x++) if (floorplan[movable.Position.Y - 2, x] != 1) covered = false;
                        if (covered) movable.CollapseTop();
                    }
                    if (movable.Position.X + movable.Size.X + 1 < floorplan.GetLength(1) && floorplan[movable.Position.Y, movable.Position.X + movable.Size.X] == 1)
                    {
                        bool covered = true;
                        for (int y = movable.Position.Y - 1; y < movable.Position.Y + movable.Size.Y - 1; y++) if (floorplan[y, movable.Position.X + movable.Size.X] != 1) covered = false;
                        if (covered) movable.CollapseRight();
                    }
                    if (movable.Position.Y + movable.Size.Y + 1 < floorplan.GetLength(0) && floorplan[movable.Position.Y + movable.Size.Y, movable.Position.X] == 1)
                    {
                        bool covered = true;
                        for (int x = movable.Position.X - 1; x < movable.Position.X + movable.Size.X - 1; x++) if (floorplan[movable.Position.Y + movable.Size.Y, x] != 1) covered = false;
                        if (covered) movable.CollapseBottom();
                    }
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

        public void CollapseLeft()
        {
            Size.X--;
            Buffered.Position.X = Position.X;
            Collapsed.Left = true;
        }

        public void CollapseTop()
        {
            Size.Y--;
            Buffered.Position.Y = Position.Y;
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
