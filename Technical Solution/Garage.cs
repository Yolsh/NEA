using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Collections.ObjectModel;
using System.Threading;
using System.Diagnostics;

namespace Technical_Solution
{
    public class Garage
    {
        public List<Box> Boxes;
        public List<Door> doors;
        private int[,] floorplan;
        public int Width;
        public int Length;
        public int bufferWidth;
        public string Name;
        public int BoxCount;

        public Garage(int bc, string inName, int inLength, int inWidth, int inBufferWidth, int rad, int x, int y)
        {
            Width = inWidth;
            Length = inLength;
            bufferWidth = inBufferWidth;
            BoxCount = bc;
            Name = inName;
            Boxes = new List<Box>();
            floorplan = new int[Width, Length];
            doors = new List<Door>{new Door(rad, x, y)};
        }

        public void AddDoor(int rad, int x, int y)
        {
            doors.Add(new Door(rad, x, y));
        }

        public Garage AddBox(Box b, Point Pos)
        {
            //if (PosX <= 1 || PosX + SizeX > Length || PosY <= 1 || PosY + SizeY > Width) throw new IncorrectPlacementException();
            b.Position = Pos;
            Boxes.Add(b);
            BoxCount = Boxes.Count();
            //BoxBuffer.CollapseBuffersWalls(Boxes, Length, Width);
            //UpdateFloor();
            //BoxBuffer.CollapseBuffersContact(Boxes, floorplan, Length, Width);
            //UpdateFloor();
            return this;
        }

        public string Organise()
        {
            SortBoxList(Boxes, Boxes.Count() - 1);

            //check Sorted
            string output = "";
            foreach (Box b in Boxes )
            {
                output += $"{b.Size.Width * b.Size.Height}, ";
            }

            SortNode root = new SortNode(new Size(Length, Width), new Point(1, 1)); //create to nearest door later

            foreach (Box S in Boxes) SortNode.AddBox(S, root);
            SortNode.CorrectPositions(root);
            return output;
        }

        public string Organise(List<Box> BoxQueue)
        {
            List<Box> newList = new List<Box>();
            for (int i = 0; i < BoxQueue.Count(); i++) Boxes.Add(BoxQueue[i]);

            SortBoxList(Boxes, newList.Count() - 1);

            //check Sorted
            string output = "";
            foreach (Box b in Boxes)
            {
                output += $"{b.Size.Width * b.Size.Height}, ";
            }

            SortNode root = new SortNode(new Size(Length, Width), new Point(1, 1)); //create to nearest door later

            foreach (Box S in Boxes) SortNode.AddBox(S, root);
            SortNode.CorrectPositions(root);
            return output;
        }

        private static void Merger(List<Box> NewList, int s, int m, int e)
        {
            int LSize = m - s + 1;
            int RSize = e - m;

            Box[] Left = new Box[LSize];
            Box[] Right = new Box[RSize];

            for (int i = 0; i < LSize; i++) Left[i] = NewList[s + i];
            for (int i = 0; i < RSize; i++) Right[i] = NewList[m + i + 1];

            int L = 0, R = 0, pointer = s;
            while (L < Left.Length && R < Right.Length)
            {
                if (Left[L].Size.Width * Left[L].Size.Height <= Right[R].Size.Width * Right[R].Size.Height)
                {
                    NewList[pointer] = Right[R];
                    R++;
                }
                else
                {
                    NewList[pointer] = Left[L];
                    L++;
                }
                pointer++;
            }

            while (L < LSize)
            {
                NewList[pointer] = Left[L];
                L++;
                pointer++;
            }
            while (R < RSize)
            {
                NewList[pointer] = Right[R];
                R++;
                pointer++;
            }
        }

        static private void SortBoxList(List<Box> BoxList, int end, int start = 0)
        {
            int midpoint = (int)Math.Ceiling(((double)start + (end - 1)) / 2);
            if (start < end)
            {
                SortBoxList(BoxList, start, midpoint);
                SortBoxList(BoxList, midpoint + 1, end);
            }
            Merger(BoxList, start, midpoint, end);
        }

        public void UpdateFloor()
        {
            int[,] NewFloorplan = new int[Width, Length];
            foreach (Square S in Boxes)
            {
                for (int y = S.Position.Y-1; y < S.Position.Y + S.Size.Height-1; y++)
                {
                    for (int x = S.Position.X-1; x < S.Position.X + S.Size.Width-1; x++)
                    {
                        if (S is BoxBuffer) NewFloorplan[y, x] = 1;
                        else if (S is Box) NewFloorplan[y, x] = 2;
                    }
                }
            }
            floorplan = NewFloorplan;
        }
    }
}
