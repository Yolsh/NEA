using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical_Solution
{
    public class Square
    {
        public struct Dimensions
        {
            public int X;
            public int Y;
        }

        public Dimensions Size;
        public Dimensions Position;


        public Square(int inX, int inY)
        {
            this.Size = new Dimensions();
            Size.X = inX;
            Size.Y = inY;
        }

        public void SetPosition(int inX, int inY)
        {
            this.Position = new Dimensions();
            Position.X = inX;
            Position.Y = inY;
        }

        public static Dimensions DimCreate(int x, int y)
        {
            Dimensions dim = new Dimensions();
            dim.X = x;
            dim.Y = y;
            return dim;
        }
    }
}
