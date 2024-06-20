using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    public class BoxBuffer : BaseBox
    {
        public BoxBuffer(Box b, int Width) : base(b.Size.X + 2*Width, b.Size.Y+2*Width)
        {
            Position.X = b.Position.X - Width;
            Position.Y = b.Position.Y - Width;
        }
    }
}
