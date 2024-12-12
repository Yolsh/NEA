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
using System.Text.RegularExpressions;

namespace Technical_Solution
{
    public class Garage
    {
        public List<Box> Boxes;
        public List<Door> doors;
        public int Width;
        public int Length;
        public int bufferWidth;
        public string Name;
        public ulong BoxCount;
        public int doorCount;

        public Garage(int dc, ulong bc, string inName, int inLength, int inWidth, int inBufferWidth, int rad, int dist, Door.Wall wall)
        {
            Width = inWidth;
            Length = inLength;
            bufferWidth = inBufferWidth;
            BoxCount = bc;
            doorCount = dc;
            Name = inName;
            Boxes = new List<Box>();
            doors = new List<Door>{new Door(rad, dist, doorCount, wall)};
            doorCount++;
        }

        public void AddDoor(int rad, int dist, Door.Wall wall)
        {
            foreach (Door d in doors)
            {
                if (d.wall == wall && ((d.distance > dist && d.distance < rad) || (dist > d.distance && dist < d.radius)))
                {
                    throw new IncorrectPlacementException();
                }
            }
            doors.Add(new Door(rad, dist, doorCount, wall));
            doorCount++;
        }

        public Garage AddBox(Box b, Point Pos)
        {
            b.Position = Pos;
            Boxes.Add(b);
            BoxCount++;
            return this;
        }

        public void Organise()
        {
            SortBoxList(Boxes, 0, Boxes.Count() - 1);

            SortNode root = new SortNode(new Size(Length, Width), new Point(0, 0)); //create to nearest door later

            foreach (Box S in Boxes)
            {
                S.ResetBuffer();
                SortNode.AddBox(S, root);
            }
            SortNode.CorrectPositions(root, doors);
        }

        public void Organise(List<Box> BoxQueue)
        {
            for (int i = 0; i < BoxQueue.Count(); i++) Boxes.Add(BoxQueue[i]);

            SortBoxList(Boxes, 0, Boxes.Count() - 1);

            SortNode root = new SortNode(new Size(Length, Width), new Point(0, 0)); //create to nearest door later

            foreach (Box S in Boxes)
            {
                S.ResetBuffer();
                SortNode.AddBox(S, root);
            }
            SortNode.CorrectPositions(root, doors);
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
                if (Left[L].buffer.Size.Height <= Right[R].buffer.Size.Height)
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

        static private void SortBoxList(List<Box> BoxList, int start, int end)
        {
            int midpoint = (int)Math.Ceiling(((double)start + (end - 1)) / 2);
            if (start < end)
            {
                SortBoxList(BoxList, start, midpoint);
                SortBoxList(BoxList, midpoint + 1, end);
            }
            Merger(BoxList, start, midpoint, end);
        }

        public List<ulong> SearchBoxes(string item)
        {
            List<ulong> found = new List<ulong>();
            foreach (Box b in Boxes)
            {
                foreach (string S in b.Contents)
                {
                    if (Regex.Replace(item, "\\s", "").ToUpper() == Regex.Replace(S, "\\s", "").ToUpper()) found.Add(b.Boxid);
                }
            }
            return found;
        }
    }
}
