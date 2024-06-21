using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Pastel;
using System.Drawing.Configuration;

namespace Prototype
{
    public class Garage
    {
        private Random rand;
        private List<Square> Boxes;
        private int[,] floorplan;
        private int Width;
        private int Length;
        private int bufferWidth;

        public Garage(int inLength, int inWidth, int inBufferWidth)
        {
            Width = inWidth;
            Length = inLength;
            bufferWidth = inBufferWidth;
            Boxes = new List<Square>();
            floorplan = new int[Width, Length];
            rand = new Random();
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
            UpdateFloor();
            BoxBuffer.CollapseBuffers(Boxes, Length, Width);
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

        private void UpdateFloor()
        {
            int[,] NewFloorplan = new int[Length, Width];
            foreach (Square S in Boxes)
            {
                for (int y = S.Position.Y; y < S.Position.Y + S.Size.Y; y++)
                {
                    for (int x = S.Position.X; x < S.Position.X + S.Size.X; x++)
                    {
                        if (S is Box) NewFloorplan[y, x] = 2;
                        else if (S is BoxBuffer) NewFloorplan[y, x] = 1;
                    }
                }
            }
            floorplan = NewFloorplan;
        }
    }
}
