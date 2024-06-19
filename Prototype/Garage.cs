using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Pastel;

namespace Prototype
{
    public class Garage
    {
        private Random rand;
        private List<Box> Boxes;
        private int[,] floorplan;
        private int Width;
        private int Length;

        public Garage(int inLength, int inWidth)
        {
            Width = inWidth;
            Length = inLength;
            Boxes = new List<Box>();
            floorplan = new int[Width, Length];
            rand = new Random();
        }

        public Garage AddBoxes(string name, double weight, int x, int y)
        {
            Box NewBox = new Box(name, weight, x, y, Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256)));
            Boxes.Add(NewBox);
            return this;
        }

        public Garage AddBoxes(string name, double weight, int SizeX, int SizeY, int PosX, int PosY)
        {
            this.AddBoxes(name, weight, SizeX, SizeY);

            for (int i = PosY; i < PosY + SizeY; i++)
            {
                for (int j = PosX; j < PosX + SizeX; j++)
                {
                    if (i < floorplan.GetLength(0) && j < floorplan.GetLength(1))
                    { 
                        floorplan[i, j] = 1; 
                    }
                }
            }

            Boxes.Last().SetPosition(PosX, PosY);

            return this;
        }
        public void Draw()
        {
            //Draw Garage primeter.
            for (int i = 0; i < Length+1; i++)
            {
                Console.Write("--");
            }
            for (int y = 1; y < floorplan.GetLength(0)+1; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.Write("|");
                Console.SetCursorPosition(Length*2+1, y);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, Width + 1);
            for (int i = 0; i < Length+1; i++)
            {
                Console.Write(i /10 != 0 ? $"{i}" : $"{i}{i}");
            }

            foreach (Box b in Boxes)
            {
                int layer = 0;
                for (int i = b.Position.Y+1; i < b.Position.Y + b.Size.Y; i++)
                {
                    Console.SetCursorPosition(b.Position.X+1, b.Position.Y+1 + layer);
                    for (int j = b.Position.X+1; j < b.Position.X + b.Size.X; j++)
                    {
                        Console.Write((layer == 0 && j == b.Position.X + 1 ? $"{b.Position.X}{b.Position.Y}" : "\u2588\u2588").Pastel(b.col));
                    }
                    layer++;
                }
            }
        }
    }
}
