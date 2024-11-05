using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technical_Solution
{
    public class BoxPane : Panel
    {
        public Box box;

        public BoxPane(Box inBox) : base() { box = inBox; }
    }

    public class DoorPane : Panel
    {
        public Door door;

        public DoorPane(Door inDoor) : base() { door = inDoor; }
    }
}
