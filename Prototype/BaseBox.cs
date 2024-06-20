using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public abstract class BaseBox
    {
        public struct Dimensions
        {
            public int X;
            public int Y;
        }

        public Dimensions Size;
        public Dimensions Position;
        public Color col;

        public void SetPosition(int inX, int inY)
        {
            this.Position = new Dimensions();
            Position.X = inX;
            Position.Y = inY;
        }
    }
}
