using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Technical_Solution
{
    public class Door
    {
        public int radius;
        public int arc;
        public Square.Dimensions location;
        public Door(int radius, int arc, int x, int y)
        {
            if (arc < 90) throw new IncorrectPlacementException("door doesnt open enough");
            this.radius = radius;
            this.arc = arc;
            this.location = Square.DimCreate(x, y);
        }
    }
}
