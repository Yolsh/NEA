using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Technical_Solution
{
    public class Box : Square
    {
        public string Name;
        public double Weight;
        public BoxBuffer buffer;
        public List<string> Contents { get; private set; }
        public Color col;

        public Box(string inBoxName, double inWeight, Size inSize, int BufferWidth, Color inCol) : base(inSize)
        {
            Name = inBoxName;
            Weight = inWeight;
            col = inCol;
            buffer = new BoxBuffer(this, BufferWidth);
            Contents = new List<string>();
        }

        public void Draw()
        {
            for (int y = Position.Y; y < Position.Y + Size.Height; y++)
            {
                for (int x = Position.X; x < Position.X + Size.Width; x++)
                {
                    if (x == Position.X && y == Position.Y)
                    {
                        Console.SetCursorPosition(x * 2 - 1, y);
                        //Console.Write($"{x},{y}");
                        //for (int i = x.ToString().Length+y.ToString().Length+1; i < Size.X*2; i++)
                        //{
                        //    Console.Write("\u2588".Pastel(col));
                        //}
                        Console.Write(Name);
                        for (int i = Name.Length; i < Size.Width * 2; i++)
                        {
                            Console.Write("\u2588");
                        }
                        x += Position.X + Size.Height;
                    }
                    else
                    {
                        Console.SetCursorPosition(x * 2 - 1, y);
                        Console.Write("\u2588\u2588");
                    }
                }
            }
        }
    }
}
