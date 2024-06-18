using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Garage
    {
        private List<Box> Boxes;
        private int Width;
        private int Length;

        public Garage(int inLength, int inWidth)
        {
            Width = inWidth;
            Length = inLength;
            Boxes = new List<Box>();
        }

        public Garage AddBoxes(string name, double weight, int x, int y)
        {
            Box NewBox = new Box(name, weight, x, y);
            Boxes.Add(NewBox);
            return this;
        }

        public Garage AddBoxes(string name, double weight, int SizeX, int SizeY, int PosX, int PosY)
        {
            Box NewBox = new Box(name, weight, SizeX, SizeY);
            NewBox.SetPosition(PosX, PosY);
            Boxes.Add(NewBox);
            return this;
        }
        public void Draw()
        {
            //Draw Garage primeter.
            for (int i = 0; i < Length; i++)
            {
                Console.Write("--");
            }
            for (int i = 0; i < Width; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("|");
                Console.SetCursorPosition(Length*2, i);
                Console.Write("|");
            }
            Console.SetCursorPosition(0, Width);
            for (int i = 0; i < Length; i++)
            {
                Console.Write("--");
            }

            //draw all boxes currently in the garage. [Pastel]
            for (int b = 0; b < Boxes.Count(); b++)
            {
                for (int i = Boxes[b].Position.Y; i < Boxes[b].Position.Y + Boxes[b].Size.Y; i++)
                {
                    Console.SetCursorPosition(Boxes[b].Position.X, Boxes[b].Position.Y + i);
                    for (int j = Boxes[b].Position.X; j < Boxes[b].Position.X + Boxes[b].Size.X; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("\u2588\u2588");
                    }
                }
            }
        }
    }
}
