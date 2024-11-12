using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace Technical_Solution
{
    public class Door
    {
        public int radius;
        public Point location;
        public int ID;
        public Wall wall;
        public enum Wall
        {
            Top,
            Bottom,
            Left,
            Right,
        }
        public Door(int radius, int Pos, int iD, Wall w, int Height)
        {
            this.radius = radius;
            wall = w;
            switch (w)
            {
                case Wall.Top:
                    this.location = new Point(Pos, 0);
                    break;
                case Wall.Bottom:
                    this.location = new Point(Pos, Height);
                    break;
                case Wall.Left:
                    this.location = new Point(0, Pos);
                    break;
                case Wall.Right:
                    this.location = new Point(Height, Pos);
                    break;
            }
            ID = iD;
        }
    }
}
