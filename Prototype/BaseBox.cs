using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public  class BaseBox
    {
        public struct Dimensions
        {
            public int X;
            public int Y;
        }

        public Dimensions Size;
        public Dimensions Position;


        public BaseBox(int inX, int inY)
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
    }
}
