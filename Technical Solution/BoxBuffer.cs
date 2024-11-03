using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Technical_Solution
{
    public class BoxBuffer : Square
    {
        public struct Sides
        {
            public bool Top, Left, Right, Bottom;
        }
        public int BufferWidth { get; private set; }
        public Sides Collapsed;

        public BoxBuffer(Box b, int Width) : base(new Size(b.Size.Width + 2*Width, b.Size.Height+2*Width))
        {
            Position.X = b.Position.X - Width;
            Position.Y = b.Position.Y - Width;
            BufferWidth = Width;
        }

        [JsonConstructor]
        public BoxBuffer(int BufferWidth, Size inSize, Point inLoc) : base(inSize)
        {
            Position = inLoc;
            this.BufferWidth = BufferWidth;
        }
    }
}
