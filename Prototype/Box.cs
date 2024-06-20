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
        
        public Box(string inBoxName, double inWeight, int inX, int inY, Color inCol) 
        {
            Name = inBoxName;
            Weight = inWeight;
            this.Size = new Dimensions();
            Size.X = inX;
            Size.Y = inY;
            col = inCol;
        }
    }
}
