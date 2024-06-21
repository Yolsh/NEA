using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Pastel;

namespace Prototype
{
    public class Box : Square
    {
        public string Name;
        private double Weight;
        private List<string> Contents;
        public Color col;

        public Box(string inBoxName, double inWeight, int inX, int inY, Color inCol) : base(inX, inY)
        {
            Name = inBoxName;
            Weight = inWeight;
            col = inCol;
        }

        public void Draw()
        {
            for (int y = Position.Y; y < Position.Y + Size.Y; y++)
            {
                for (int x = Position.X; x < Position.X + Size.X; x++)
                {
                    Console.SetCursorPosition(x * 2-1, y);
                    Console.Write((x == Position.X && y == Position.Y ? "00" : "\u2588\u2588").Pastel(col));
                }
            }
        }
    }
}
