﻿using System;
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
        public int arc;
        public Point location;
        public Door(int radius, int x, int y)
        {
            this.radius = radius;
            this.location = new Point(x, y);
        }
    }
}
