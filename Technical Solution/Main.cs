using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Technical_Solution
{
    public partial class Main : Form
    {
        private Garage garage;
        private List<Box> Boxes;
        private LoadMenu loadMenu;

        public Main(LoadMenu loadMenu)
        {
            garage = new Garage(300, 300, 5, 6, 90, 0, 3);
            InitializeComponent();
            Boxes = new List<Box>();
            Box newBox = new Box("bob", 2.2, 40, 40, Color.Brown);
            newBox.SetPosition(10, 20);
            Boxes.Add(newBox);
            this.loadMenu = loadMenu;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Box B in Boxes)
            {
                Panel P = new Panel();
                P.BackColor = B.col;
                P.Location = new Point(B.Position.X, B.Position.Y);
                P.Size = new Size(B.Size.X, B.Size.Y);
                FloorView.Controls.Add(P);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadMenu.Show();
        }
    }
}
