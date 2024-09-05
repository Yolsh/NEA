using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Technical_Solution
{
    public class BoxBuffer : Square
    {
        public struct Sides
        {
            public bool Top, Left, Right, Bottom;
        }
        public int BufferWidth { get; private set; }
        public Sides Collapsed;

        public BoxBuffer(Box b, int Width) : base(new Size(b.Size.Width + 2*Width, b.Size.Height+2*Width))
        {
            Position.X = b.Position.X - Width;
            Position.Y = b.Position.Y - Width;
            BufferWidth = Width;
        }

        [JsonConstructor]
        public BoxBuffer(int Width, Size inSize, Point inLoc) : base(inSize)
        {
            Position = inLoc;
            BufferWidth = Width;
        }

        //public static void CollapseBuffersWalls(List<Square> Boxes, int Length, int Width)
        //{
        //    foreach (Square S in Boxes)
        //    {
        //        if (S is BoxBuffer)
        //        {
        //            BoxBuffer movable = S as BoxBuffer;

        //            //collapse buffers when touching walls.
        //            if (movable.Position.Y == 1 && !movable.Collapsed.Top) movable.CollapseTop();
        //            if (movable.Position.Y + movable.Size.Height >= Width && !movable.Collapsed.Bottom) movable.CollapseBottom();
        //            if (movable.Position.X == 1 && !movable.Collapsed.Left) movable.CollapseLeft();
        //            if (movable.Position.X + movable.Size.Width >= Length && !movable.Collapsed.Right) movable.CollapseRight();
        //        }
        //    }
        //}

        //public static void CollapseBuffersContact(List<Square> Boxes, int[,] floorplan, int Length, int Width)
        //{
        //    foreach (Square S in Boxes)
        //    {
        //        if (S is BoxBuffer)
        //        {
        //            BoxBuffer movable = S as BoxBuffer;

        //            //collapse buffers covered by other buffers.
        //            if (movable.Position.X - 1 > 0 && floorplan[movable.Position.Y, movable.Position.X - 1] == 1)
        //            {
        //                bool covered = true;
        //                for (int y = movable.Position.Y - 1; y < movable.Position.Y + movable.Size.Height - 1; y++) if (floorplan[y, movable.Position.X - 2] != 1) covered = false;
        //                if (covered) movable.CollapseLeft();
        //            }
        //            if (movable.Position.Y - 1 > 0 && floorplan[movable.Position.Y - 1, movable.Position.X] == 1)
        //            {
        //                bool covered = true;
        //                for (int x = movable.Position.X - 1; x < movable.Position.X + movable.Size.Width - 1; x++) if (floorplan[movable.Position.Y - 2, x] != 1) covered = false;
        //                if (covered) movable.CollapseTop();
        //            }
        //            if (movable.Position.X + movable.Size.Width + 1 < floorplan.GetLength(1) && floorplan[movable.Position.Y, movable.Position.X + movable.Size.Width] == 1)
        //            {
        //                bool covered = true;
        //                for (int y = movable.Position.Y - 1; y < movable.Position.Y + movable.Size.Height - 1; y++) if (floorplan[y, movable.Position.X + movable.Size.Width] != 1) covered = false;
        //                if (covered) movable.CollapseRight();
        //            }
        //            if (movable.Position.Y + movable.Size.Height + 1 < floorplan.GetLength(0) && floorplan[movable.Position.Y + movable.Size.Height, movable.Position.X] == 1)
        //            {
        //                bool covered = true;
        //                for (int x = movable.Position.X - 1; x < movable.Position.X + movable.Size.Width - 1; x++) if (floorplan[movable.Position.Y + movable.Size.Height, x] != 1) covered = false;
        //                if (covered) movable.CollapseBottom();
        //            }
        //        }
        //    }
        //}

    //    public static void ResetBuffers(List<Square> Boxes) //needs to work with other minimum widths
    //    {
    //        foreach (Square S in Boxes)
    //        {
    //            if (S is BoxBuffer)
    //            {
    //                BoxBuffer reset = S as BoxBuffer;
    //                if (reset.Collapsed.Left)
    //                {
    //                    reset.Size.Width++;
    //                    reset.Buffered.Position.X++;
    //                    reset.Collapsed.Left = false;
    //                }
    //                if (reset.Collapsed.Right)
    //                {
    //                    reset.Size.Width++;
    //                    reset.Buffered.Position.X--;
    //                    reset.Position.X--;
    //                    reset.Collapsed.Right = false;
    //                }
    //                if (reset.Collapsed.Top)
    //                {
    //                    reset.Size.Height++;
    //                    reset.Buffered.Position.Y++;
    //                    reset.Collapsed.Top = false;
    //                }
    //                if (reset.Collapsed.Bottom)
    //                {
    //                    reset.Size.Height++;
    //                    reset.Buffered.Position.Y--;
    //                    reset.Position.Y--;
    //                    reset.Collapsed.Bottom = false;
    //                }
    //            }
    //        }
    //    }

    //    public void CollapseLeft()
    //    {
    //        Size.Width--;
    //        Buffered.Position.X = Position.X;
    //        Collapsed.Left = true;
    //    }

    //    public void CollapseTop()
    //    {
    //        Size.Height--;
    //        Buffered.Position.Y = Position.Y;
    //        Collapsed.Top = true;
    //    }

    //    public void CollapseRight()
    //    {
    //        Size.Width--;
    //        Buffered.Position.X++;
    //        Position.X++;
    //        Collapsed.Right = true;
    //    }

    //    public void CollapseBottom()
    //    {
    //        Size.Height--;
    //        Buffered.Position.Y++;
    //        Position.Y++;
    //        Collapsed.Bottom = true;
    //    }
    }
}
