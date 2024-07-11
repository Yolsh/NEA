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

namespace Technical_Solution
{
    public class Garage
    {
        private Random rand;
        private List<Square> Boxes;
        private List<Door> doors;
        private int[,] floorplan;
        private int Width;
        private int Length;
        private int bufferWidth;

        public Garage(int inLength, int inWidth, int inBufferWidth, int rad, int arc, int x, int y)
        {
            Width = inWidth;
            Length = inLength;
            bufferWidth = inBufferWidth;
            Boxes = new List<Square>();
            floorplan = new int[Width, Length];
            rand = new Random();
            doors = new List<Door>{new Door(rad, arc, x, y)};
        }

        public Box AddBoxes(string name, double weight, int x, int y)
        {
            Box NewBox = new Box(name, weight, x, y, Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)));
            //this is the bit where we add a Queue. for now it just creates a box.
            return NewBox;
        }

        public Garage AddBoxes(string name, double weight, int SizeX, int SizeY, int PosX, int PosY)
        {
            Box b = this.AddBoxes(name, weight, SizeX, SizeY);

            if (PosX <= 1 || PosX + SizeX > Length || PosY <= 1 || PosY + SizeY > Width) throw new IncorrectPlacementException();
            b.Position.X = PosX;
            b.Position.Y = PosY;
            Boxes.Add(new BoxBuffer(b, bufferWidth));
            Boxes.Add(b);
            BoxBuffer.CollapseBuffersWalls(Boxes, Length, Width);
            UpdateFloor();
            //BoxBuffer.CollapseBuffersContact(Boxes, floorplan, Length, Width);
            UpdateFloor();
            return this;
        }

        private void DrawPerimeter(bool axis)
        {
            //Draw Garage primeter.
            for (int i = 0; i < Length + 1; i++)
            {
                Console.Write("--");
            }
            for (int y = 1; y < Width + 1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("|");
                Console.SetCursorPosition(Length * 2 + 1, y);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, Width + 1);
            if (axis)
            {
                for (int i = 0; i < Length + 1; i++)
                {
                    Console.Write(i / 10 != 0 ? $"{i}" : i == 0 ? "0" : $"0{i}");
                }
            }
            else
            {
                for (int i = 0; i < Length + 1; i++)
                {
                    Console.Write("--");
                }
            }
        }

        public void Draw()
        {
            Console.Clear();
            DrawPerimeter(true);

            foreach (Square b in Boxes)
            {
                if (b is Box)
                {
                    (b as Box).Draw();
                }
                else if (b is BoxBuffer)
                {
                    (b as BoxBuffer).Draw();
                }
            }
        }

        public void DrawFloorPlan()
        {
            Console.Clear();
            DrawPerimeter(true);
            for (int y = 0; y < Width; y++)
            {
                for (int x = 0; x < Length; x++)
                {
                    Console.SetCursorPosition(x*2+1, y+1);
                    Console.Write($"{floorplan[y, x]}{floorplan[y,x]}");
                }
            }
        }

        public void Organise()
        {
            SortBoxList();
            SortNode root = new SortNode(Square.DimCreate(Length, Width), Square.DimCreate(1, 1)); //create to nearest door later
            BoxBuffer.ResetBuffers(Boxes);
            try
            {
                foreach (Square S in Boxes)
                {
                    if (S is BoxBuffer)
                    {
                        SortNode.AddBox(S as BoxBuffer, root);
                        SortNode.CorrectPositions(root);
                    }
                }
            }
            catch (IncorrectPlacementException)
            {
                Console.Clear();
                DrawTree(root, 0);
                Console.ReadKey();
            }
            BoxBuffer.CollapseBuffersWalls(Boxes, Length, Width);
            UpdateFloor();
            //BoxBuffer.CollapseBuffersContact(Boxes, floorplan, Length, Width);
            UpdateFloor();
        }

        private void SortBoxList() //this should be a merge sort later
        {
            List<Square> NewList = new List<Square>();
            for (int i = 0; i < Boxes.Count(); i++)
            {
                if (Boxes[i] is BoxBuffer)
                {
                    NewList.Add(Boxes[i]);
                    Boxes.Remove(Boxes[i]);
                }
            }

            bool Swapped = true;

            while (Swapped)
            {
                Swapped = false;
                for (int i = 1; i < NewList.Count(); i++)
                {
                    if (NewList[i-1].Size.X * NewList[i-1].Size.Y > NewList[i].Size.X * NewList[i].Size.Y)
                    {
                        Square temp = NewList[i];
                        NewList[i] = NewList[i-1];
                        NewList[i-1] = temp;
                        Swapped = true;
                    }
                }
            }

            NewList.AddRange(Boxes);
            Boxes = NewList;
            Console.Clear();
            foreach (Square square in NewList) 
            {
                Console.WriteLine(square.Size.X * square.Size.Y);
            }
            Console.ReadKey();
        }
        
        public void UpdateFloor()
        {
            int[,] NewFloorplan = new int[Width, Length];
            foreach (Square S in Boxes)
            {
                for (int y = S.Position.Y-1; y < S.Position.Y + S.Size.Y-1; y++)
                {
                    for (int x = S.Position.X-1; x < S.Position.X + S.Size.X-1; x++)
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
            Console.WriteLine(root.b is null ? root.Size.X + "," + root.Size.Y : "\u2588");
            if (root.Left != null) DrawTree(root.Left, 1);
            if (root.Right != null) DrawTree(root.Right, 2);
            else Console.WriteLine("_");
        }
    }
}
