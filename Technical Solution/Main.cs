using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;

namespace Technical_Solution
{
    public partial class Main : Form
    {
        private Random rand;
        public Garage garage;
        public List<Box> Box_Queue;
        private double Scale;

        public Main()
        {
            InitializeComponent();
            rand = new Random();
            Box_Queue = new List<Box>();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.JSONContainer collected = new Forms.JSONContainer();
            collected.garage = garage;
            collected.Box_Queue = Box_Queue;
            string save = JsonConvert.SerializeObject(collected, Formatting.Indented);
            using (StreamWriter sw = new StreamWriter($"{garage.Name}.json", false))
            {
                sw.Write(save);
            }
            MessageBox.Show("This Garage has been saved");
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.L_Menu.Show();
        }

        public void Draw()
        {
            DrawFloor();
            DrawQueue();
        }

        private void DrawQueue()
        {
            int Offset_Y = 25;
            foreach (Box box in Box_Queue)
            {
                MyPane BoxPan = new MyPane(box);
                BoxPan.MouseMove += new MouseEventHandler(this.Box_Drag);
                BoxPan.MouseDoubleClick += new MouseEventHandler(Forms.Box_Menu.FormShow);
                BoxPan.BackColor = box.col;
                BoxPan.Location = new Point(25, Offset_Y);
                BoxPan.Size = new Size((int)Math.Round(box.Size.Width * Scale), (int)Math.Round(box.Size.Height * Scale));
                Offset_Y = Offset_Y + BoxPan.Size.Height + 25;

                Box_Queue_Group.Controls.Add(BoxPan);
            }
        }

        private void DrawFloor()
        {
            Panel Floor = new Panel();
            Floor.BackColor = Color.Coral;
            Floor.Name = "Floor";
            Floor.Location = new Point(15, 15);
            Scale = 1.0;

            if ((double)(FloorView.Size.Width - 30) / garage.Length < (double)(FloorView.Size.Height - 30) / garage.Width) Scale = (double)(FloorView.Size.Width - 30) / garage.Length;
            else if ((double)(FloorView.Size.Width - 30) / garage.Length > (double)(FloorView.Size.Height - 30) / garage.Width) Scale = (double)(FloorView.Size.Height - 30) / garage.Width;
            Floor.Size = new Size((int)(garage.Length * Scale), (int)(garage.Width * Scale));

            if (FloorView.Controls.ContainsKey("Floor")) Floor = FloorView.Controls["Floor"] as Panel;
            else FloorView.Controls.Add(Floor);

            foreach (Box b in garage.Boxes.OfType<Box>())
            {
                Panel BuffPan;
                if (Floor.Controls.ContainsKey($"BuffPan{b.Name}"))
                {
                    BuffPan = Floor.Controls[$"BuffPan{b.Name}"] as Panel;
                    if (BuffPan.Location != new Point((int)Math.Round(b.buffer.Position.X * Scale), (int)Math.Round(b.buffer.Position.Y * Scale))) BuffPan.Location = new Point((int)Math.Round(b.buffer.Position.X * Scale), (int)Math.Round(b.buffer.Position.Y * Scale));
                    if (BuffPan.Size != new Size((int)Math.Round(b.buffer.Size.Width * Scale), (int)Math.Round(b.buffer.Size.Height * Scale))) BuffPan.Size = new Size((int)Math.Round(b.buffer.Size.Width * Scale), (int)Math.Round(b.buffer.Size.Height * Scale));
                }
                else
                {
                    BuffPan = new Panel();
                    BuffPan.Name = $"BuffPan{b.Name}";
                    BuffPan.BackColor = Color.AliceBlue;
                    BuffPan.Location = new Point((int)Math.Round(b.buffer.Position.X * Scale), (int)Math.Round(b.buffer.Position.Y * Scale));
                    BuffPan.Size = new Size((int)Math.Round(b.buffer.Size.Width * Scale), (int)Math.Round(b.buffer.Size.Height * Scale));

                    Floor.Controls.Add(BuffPan);
                }
                BuffPan.BringToFront();

                MyPane Pan;
                if (Floor.Controls.ContainsKey(b.Name))
                {
                    Pan = Floor.Controls[b.Name] as MyPane;
                    if (Pan.Location != new Point((int)Math.Round(b.Position.X * Scale), (int)Math.Round(b.Position.Y * Scale))) Pan.Location = new Point((int)Math.Round(b.Position.X * Scale), (int)Math.Round(b.Position.Y * Scale));
                    if (Pan.Size != new Size((int)Math.Round(b.Size.Width * Scale), (int)Math.Round(b.Size.Height * Scale))) Pan.Size = new Size((int)Math.Round(b.Size.Width * Scale), (int)Math.Round(b.Size.Height * Scale));
                }
                else
                {
                    Pan = new MyPane(b);
                    Pan.Name = b.Name;
                    Pan.BackColor = b.col;
                    Pan.MouseMove += new MouseEventHandler(this.Box_Drag);
                    Pan.MouseDoubleClick += new MouseEventHandler(Forms.Box_Menu.FormShow);
                    Pan.Location = new Point((int)Math.Round(b.Position.X * Scale), (int)Math.Round(b.Position.Y * Scale));
                    Pan.Size = new Size((int)Math.Round(b.Size.Width * Scale), (int)Math.Round(b.Size.Height * Scale));

                    Floor.Controls.Add(Pan);
                }
                Pan.BringToFront();
            }
        }

        private void Add_Btn_Click(object sender, EventArgs e)
        {
            Err_Lbl.Hide();
            if (Name_Txt.Text != "" && Weight_Txt.Text != "" && Length_Txt.Text != "" && Width_Txt.Text != "" &&
                Weight_Txt.Text.Split('.').Length <= 2 &&
                Regex.IsMatch(Weight_Txt.Text, "[0-9]*\\.*[0-9]+") &&
                Regex.IsMatch(Length_Txt.Text, "[0-9]+") &&
                Regex.IsMatch(Width_Txt.Text, "[0-9]+") &&
                Col_Pan.BackColor != Color.FromName("Control"))
            {
                Box NewBox = new Box(Name_Txt.Text, double.Parse(Weight_Txt.Text), new Size(int.Parse(Length_Txt.Text), int.Parse(Width_Txt.Text)), garage.bufferWidth, Col_Pan.BackColor);
                Box_Queue.Add(NewBox);
                DrawQueue();

                Name_Txt.Text = "";
                Weight_Txt.Text = "";
                Length_Txt.Text = "";
                Width_Txt.Text = "";
                Colour_Txt.Text = "";
            }
            else Err_Lbl.Show();
        }

        private void Colour_Txt_TextChanged(object sender, EventArgs e)
        {
            Col_Pan.BackColor = Color.FromName(Colour_Txt.Text);
        }

        private void Rand_Col_Btn_Click(object sender, EventArgs e)
        {
            Col_Pan.BackColor = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
        }

        private void Box_Drag(object sender, MouseEventArgs e)
        {
            MyPane Pan = sender as MyPane;

            if (Box_Queue_Group.Contains(Pan))
            {
                Box_Queue_Group.Controls.Remove(Pan);
                this.Controls.Add(Pan);
                Pan.Location = new Point(Box_Queue_Group.Location.X + Pan.Location.X, Box_Queue_Group.Location.Y + Pan.Location.Y);
                Pan.BringToFront();
            }

            if (e.Button == MouseButtons.Left)
            {
                Pan.Location = new Point(e.X + Pan.Location.X, e.Y + Pan.Location.Y);
            }
            else if (Pan.Location.X > FloorView.Location.X && Pan.Location.X + Pan.Size.Width < FloorView.Location.X + FloorView.Size.Width &&
                Pan.Location.Y > FloorView.Location.Y && Pan.Location.Y + Pan.Size.Height < FloorView.Location.Y + FloorView.Size.Height)
            {
                Box_Queue.Remove(Pan.box);
                Point OldPos;
                if (!FloorView.Controls["Floor"].Controls.Contains(Pan))
                {
                    Point NewLoc = new Point((int)Math.Round((Pan.Location.X - FloorView.Location.X - FloorView.Controls["Floor"].Location.X) / Scale), (int)Math.Round((Pan.Location.Y - FloorView.Location.Y) / Scale));
                    if (!garage.Boxes.Contains(Pan.box)) garage.AddBox(Pan.box, NewLoc);
                    Pan.box.buffer.Position = new Point(NewLoc.X - garage.bufferWidth, NewLoc.Y - garage.bufferWidth);
                    DrawFloor();
                }
                else
                {
                    Point NewLoc = new Point((int)Math.Round(Pan.Location.X / Scale), (int)Math.Round(Pan.Location.Y / Scale));
                    Pan.box.buffer.Position = new Point(NewLoc.X - garage.bufferWidth, NewLoc.Y - garage.bufferWidth);
                    OldPos = Pan.box.Position;
                    Pan.box.Position = NewLoc;
                    if (OldPos != NewLoc) DrawFloor();
                }
            }
            else if (!(Pan.Location.X > Box_Queue_Group.Location.X && Pan.Location.X + Pan.Size.Width < Box_Queue_Group.Location.X + Box_Queue_Group.Size.Width &&
                Pan.Location.Y > Box_Queue_Group.Location.Y && Pan.Location.Y + Pan.Size.Height < Box_Queue_Group.Location.Y + Box_Queue_Group.Size.Height))
            {
                this.Controls.Remove(Pan);
                DrawQueue();
            }
        }
    }
}
