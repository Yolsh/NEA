using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Technical_Solution
{
    public class Box : Square
    {
        public string Name;
        public int Boxid;
        public double Weight;
        public BoxBuffer buffer;
        public List<string> Contents { get; private set; }
        public Color col;

        public Box(int Boxid, string inBoxName, double inWeight, Size inSize, int BufferWidth, Color inCol) : base(inSize)
        {
            Name = inBoxName;
            this.Boxid = Boxid;
            Weight = inWeight;
            col = inCol;
            buffer = new BoxBuffer(this, BufferWidth);
            Contents = new List<string>();
        }

        public void CollapseLeft()
        {
            buffer.Size.Width -= buffer.BufferWidth;
            Position.X = buffer.Position.X;
            buffer.Collapsed.Left = true;
        }

        public void CollapseTop()
        {
            buffer.Size.Height -= buffer.BufferWidth;
            Position.Y = buffer.Position.Y;
            buffer.Collapsed.Top = true;
        }

        public void CollapseRight()
        {
            buffer.Size.Width -= buffer.BufferWidth;
            buffer.Collapsed.Right = true;
        }

        public void CollapseBottom()
        {
            buffer.Size.Height -= buffer.BufferWidth;
            buffer.Collapsed.Bottom = true;
        }
    }
}
