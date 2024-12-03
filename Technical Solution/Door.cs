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
        public int distance;
        public int ID;
        public Wall wall;
        public enum Wall
        {
            Top,
            Bottom,
            Left,
            Right,
        }
        public Door(int radius, int Dist, int iD, Wall w)
        {
            this.radius = radius;
            wall = w;
            this.distance = Dist;
            ID = iD;
        }
    }
}
