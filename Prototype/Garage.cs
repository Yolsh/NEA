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
        private Box[,] floorplan;
        private int Width;
        private int Length;
        private int bufferWidth;

        public Garage(int inLength, int inWidth, int inBufferWidth)
        {
            Width = inWidth;
            Length = inLength;
            bufferWidth = inBufferWidth;
            floorplan = new Box[Width, Length];
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

            if (PosX <= 1 || PosX + SizeX >= Length || PosY <= 1 || PosY + SizeY >= Width) throw new IncorrectPlacementException();
            PosX--;
            PosY--;
            b.Position.X = PosX;
            b.Position.Y = PosY;

            for (int i = PosY; i < PosY + SizeY; i++)
            {
                for (int j = PosX; j < PosX + SizeX; j++)
                {
                    if (i < floorplan.GetLength(0) && j < floorplan.GetLength(1))
                    {
                        floorplan[i, j] = b;
                    }
                }
            }

            return this;
        }

        private void DrawPerimeter(bool axis)
        {
            //Draw Garage primeter.
            for (int i = 0; i < Length + 1; i++)
            {
                Console.Write("--");
            }
            for (int y = 1; y < floorplan.GetLength(0) + 1; y++)
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
                    Console.Write(i / 10 != 0 ? $"{i}" : i == 0 ? "0" : $"{i}{i}");
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

        public void DrawWithArray()
        {
            DrawPerimeter(false);

            for (int y = 0; y < Width; y++)
            {
                for (int x = 0; x < Length; x++)
                {
                    Console.SetCursorPosition(x*2+1, y+1);
                    if (floorplan[y, x] != null)
                    {
                        Box b = floorplan[y, x];
                        Console.Write((x == b.Position.X && y == b.Position.Y ? b.Name : "\u2588\u2588").Pastel(b.col));
                    }
                    else Console.Write("  ");
                }
            }
        }
    }
}
