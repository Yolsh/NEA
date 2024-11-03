using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ColorInverter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Color Original = Color.FromArgb(255, 164, 032);
            string B = Convert.ToString(int.Parse(Original.B.ToString()), 2);
            while (B.Length < 8) B = "0" + B;
            int InvB = Convert.ToInt32(B.Substring(0, 4).Reverse().Aggregate("", (tot, cur) => tot += cur) + B.Substring(4, 4).Reverse().Aggregate("", (tot, cur) => tot += cur), 2);
            string G = Convert.ToString(int.Parse(Original.G.ToString()), 2);
            while (G.Length < 8) G = "0" + G;
            int InvG = Convert.ToInt32(G.Substring(0, 4).Reverse().Aggregate("", (tot, cur) => tot += cur) + G.Substring(4, 4).Reverse().Aggregate("", (tot, cur) => tot += cur), 2);
            string R = Convert.ToString(int.Parse(Original.R.ToString()), 2);
            while (R.Length < 8) R = "0" + R;
            int InvR = Convert.ToInt32(R.Substring(0, 4).Reverse().Aggregate("", (tot, cur) => tot += cur) + R.Substring(4, 4).Reverse().Aggregate("", (tot, cur) => tot += cur), 2);
            Color Inverted = Color.FromArgb(InvB, InvG, InvR);
            for (int i = 0; i < 10; i ++)
            {
                this.BackColor = Original;
                Thread.Sleep(300);
                this.BackColor = Inverted;
            }
        }
    }
}
