using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technical_Solution
{
    public class MyPane : Panel
    {
        public Box box;

        public MyPane(Box inBox) : base() { box = inBox; }
    }
}
