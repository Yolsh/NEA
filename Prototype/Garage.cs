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
        private List<Box> Boxes;
        private int[,] floorplan;
        private int Width;
        private int Length;
        private int bufferWidth;

        public Garage(int inLength, int inWidth, int inBufferWidth)
        {
            Width = inWidth;
            Length = inLength;
            bufferWidth = inBufferWidth;
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

            if (PosX <= 0 || PosX + SizeX >= Length || PosY <= 0 || PosY + SizeY >= Width) throw new IncorrectPlacementException();

            for (int i = PosY; i < PosY + SizeY; i++)
            {
                for (int j = PosX; j < PosX + SizeX; j++)
                {
                    if (i < floorplan.GetLength(0) && j < floorplan.GetLength(1))
                    {
                        floorplan[i, j] = Boxes.Count();
                    }
                }
            }

            Boxes.Last().SetPosition(PosX, PosY);

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

        public void Draw()
        {
            DrawPerimeter(true);

            foreach (Box b in Boxes)
            { 
                DrawBox(b);
            }
        }

        public void DrawBox(Box b)
        {
            int layer = 0;
            for (int i = b.Position.Y + 1 - bufferWidth; i < b.Position.Y + b.Size.Y + 1 + bufferWidth; i++)
            {
                Console.SetCursorPosition(b.Position.X * 2, b.Position.Y + 1 + layer);
                for (int j = b.Position.X + 1-bufferWidth; j < b.Position.X + b.Size.X + 1 + bufferWidth; j++)
                {
                    Console.Write(i == b.Position.Y + 1 - bufferWidth || i == b.Position.Y + b.Size.Y + bufferWidth ||
                        j == b.Position.X + 1 - bufferWidth  || j == b.Position.X + b.Size.X + bufferWidth ? "\u2588\u2588".Pastel("#FFE5B4") : 
                        (i == b.Position.Y+1 && j == b.Position.X + 1 ? $"{b.Position.X}{b.Position.Y}" : "\u2588\u2588").Pastel(b.col));
                }
                layer++;
            }
        }

        public void DrawWithArray()
        {
            DrawPerimeter(false);

            for (int y = 1; y < Width+1; y++)
            {
                for (int x = 1; x < Length+1; x++)
                {
                    Console.SetCursorPosition(x, y);
                    int i = floorplan[y - 1, x - 1];
                    Console.Write(i / 10 != 0 ? $"{i}" : $"0{i}");
                }
            }
        }
    }
}
