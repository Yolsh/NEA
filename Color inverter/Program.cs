using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Color_inverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Color Original = BX.BackColor;
            Color Inverted = Color.FromArgb(int.Parse("255" +
                Convert.ToInt16(Convert.ToString(BX.BackColor.B, 2).Reverse()).ToString() +
                Convert.ToInt16(Convert.ToString(BX.BackColor.G, 2).Reverse()).ToString() +
                Convert.ToInt16(Convert.ToString(BX.BackColor.R, 2).Reverse()).ToString()));
        }
    }
}
