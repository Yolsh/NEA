using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Pastel;
using System.Drawing.Configuration;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;

namespace Prototype
{
    public class Garage
    {
        private Random rand;
        private List<Square> Boxes;
        private List<Door> doors;
        private Square[,] floorplan;
        private int Width;
        private int Length;
        private int bufferWidth;

        public Garage(int inLength, int inWidth, int inBufferWidth, int rad, int arc, int x, int y)
        {
            Width = inWidth;
            Length = inLength;
            bufferWidth = inBufferWidth;
            Boxes = new List<Square>();
            floorplan = new Square[Width, Length];
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

            if (PosX < 1 || PosX + SizeX > Length || PosY < 1 || PosY + SizeY > Width) throw new IncorrectPlacementException();
            b.Position.X = PosX;
            b.Position.Y = PosY;
            Boxes.Add(new BoxBuffer(b, bufferWidth));
            Boxes.Add(b);
            //BoxBuffer.CollapseBuffers(Boxes, Length, Width);
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
            SortBoxListLTS();
            SortNode root = new SortNode(Square.DimCreate(0, 0), Square.DimCreate(Length, Width)); //create to nearest door later
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
                Console.Clear();
                foreach(Square S in Boxes)
                {
                    Console.WriteLine($"{S.Size.X}, {S.Size.Y}");
                }
            }
            BoxBuffer.CollapseBuffers(Boxes, Length, Width);
        }

        private void SortBoxListLTS() //this should be a merge sort later
        {
            bool Swapped = true;

            while (Swapped)
            {
                Swapped = false;
                for (int i = 1; i < Boxes.Count(); i++)
                {
                    if (Boxes[i-1].Size.X * Boxes[i-1].Size.Y > Boxes[i].Size.X * Boxes[i].Size.Y)
                    {
                        Square temp = Boxes[i];
                        Boxes[i] = Boxes[i-1];
                        Boxes[i-1] = temp;
                        Swapped = true;
                    }
                }
            }
            Boxes.Reverse();
        }
        
        public void UpdateFloor()
        {
            Square[,] NewFloorplan = new Square[Width, Length];
            foreach (Square S in Boxes)
            {
                for (int y = S.Position.Y; y < S.Position.Y + S.Size.Y; y++)
                {
                    for (int x = S.Position.X; x < S.Position.X + S.Size.X; x++)
                    {
                        NewFloorplan[y, x] = S;
                    }
                }
            }
            floorplan = NewFloorplan;
        }

        private void DrawTree(SortNode root, int dir)
        {
            Console.WriteLine(dir == 0 ? "" : dir == 1 ? "/" : "\\") ;
            Console.WriteLine(root.b is null ? root.Size.X + "," + root.Size.Y : "\u2588");
            if (root.Right != null) DrawTree(root.Right, 1);
            if (root.Down != null) DrawTree(root.Down, 2);
            else Console.WriteLine("_");
        }
    }
}
