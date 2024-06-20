using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Prototype
{
    public class Box : BaseBox
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
    }
}
