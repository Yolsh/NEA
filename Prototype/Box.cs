﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class Box
    {
        public struct Dimensions
        {
            public int X;
            public int Y;
        }

        public string Name;
        private double Weight;
        private List<string> Contents;
        public Dimensions Size;
        public Dimensions Position;
        public Box(string inBoxName, double inWeight, int inX, int inY) 
        {
            Name = inBoxName;
            Weight = inWeight;
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
