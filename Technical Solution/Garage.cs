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

        public Garage(string inName, int inLength, int inWidth, int inBufferWidth, int rad, int x, int y)
        {
            Width = inWidth;
            Length = inLength;
            bufferWidth = inBufferWidth;
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
            //BoxBuffer.CollapseBuffersWalls(Boxes, Length, Width);
            //UpdateFloor();
            //BoxBuffer.CollapseBuffersContact(Boxes, floorplan, Length, Width);
            //UpdateFloor();
            return this;
        }

        public void Organise()
        {
            SortBoxList();
            SortNode root = new SortNode(new Size(Length, Width), new Point(1, 1)); //create to nearest door later
            //BoxBuffer.ResetBuffers(Boxes);
            try
            {
                foreach (Box S in Boxes)
                {
                    SortNode.AddBox(S, root);
                    SortNode.CorrectPositions(root);
                }
            }
            catch (IncorrectPlacementException)
            {
                Console.Clear();
                DrawTree(root, 0);
                Console.ReadKey();
            }
            //BoxBuffer.CollapseBuffersWalls(Boxes, Length, Width);
            UpdateFloor();
            //BoxBuffer.CollapseBuffersContact(Boxes, floorplan, Length, Width);
            UpdateFloor();
        }

        private void SortBoxList() //this should be a merge sort later
        {
            List<List<Box>> Collection = new List<List<Box>>();
            foreach (Box b in Boxes)
            {
                Collection.Add(new List<Box>{b});
            }

            while(Collection.Count() > 1)
            {
                for (int i = 0; i < Collection.Count; i++)
                {
                    int count = 0;
                    foreach (Box b in Collection[i+1])
                    {
                        if (b.Size.Width > Collection[i][count].Size.Width)
                        {

                        }
                        count++;
                    }
                }
            }



            //List<Box> NewList = new List<Box>();
            //for (int i = 0; i < Boxes.Count(); i++)
            //{
            //    if (Boxes[i] is BoxBuffer)
            //    {
            //        NewList.Add(Boxes[i]);
            //        Boxes.Remove(Boxes[i]);
            //    }
            //}

            //bool Swapped = true;

            //while (Swapped)
            //{
            //    Swapped = false;
            //    for (int i = 1; i < NewList.Count(); i++)
            //    {
            //        if (NewList[i - 1].Size.Width * NewList[i - 1].Size.Height > NewList[i].Size.Width * NewList[i].Size.Height)
            //        {
            //            Square temp = NewList[i];
            //            NewList[i] = NewList[i - 1];
            //            NewList[i - 1] = temp;
            //            Swapped = true;
            //        }
            //    }
            //}

            //NewList.AddRange(Boxes);
            //Boxes = NewList;
            //Console.Clear();
            //foreach (Square square in NewList)
            //{
            //    Console.WriteLine(square.Size.Width * square.Size.Height);
            //}
            //Console.ReadKey();
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

        private void DrawTree(SortNode root, int dir)
        {
            Console.WriteLine(dir == 0 ? "" : dir == 1 ? "/" : "\\") ;
            Console.WriteLine(root.b is null ? root.Size.Width + "," + root.Size.Height : "\u2588");
            if (root.Left != null) DrawTree(root.Left, 1);
            if (root.Right != null) DrawTree(root.Right, 2);
            else Console.WriteLine("_");
        }
    }
}
