using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;
using Newtonsoft.Json;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Runtime.InteropServices;

namespace Technical_Solution
{
    public partial class Main : Form
    {
        private Random rand;
        public Garage garage;
        public List<Box> Box_Queue;
        private double Scale;
        private System.Timers.Timer KeyPressTimeOut;
        private bool keyAllow;

        public Main()
        {
            InitializeComponent();
            MyInitializer();
            rand = new Random();
            Box_Queue = new List<Box>();
            KeyPressTimeOut = new System.Timers.Timer(200);
            KeyPressTimeOut.Elapsed += (Source, e) => keyAllow = true;
            KeyPressTimeOut.Enabled = true;
            KeyPressTimeOut.AutoReset = false;
            LoadLastOpened();
        }

        private void MyInitializer()
        {
            int Space = 16;
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Size.Width, Screen.PrimaryScreen.WorkingArea.Size.Height - 24);
            this.MenuStrip.Size = new Size(this.Size.Width, 24);
            this.FloorView.Location = new Point(Space, this.MenuStrip.Size.Height + Space);
            this.FloorView.Size = new Size((int)(0.8 * this.Size.Width), (int)(0.75 * this.Size.Height));
            this.Box_Queue_Group.Location = new Point(this.FloorView.Location.X + this.FloorView.Size.Width + Space, this.FloorView.Location.Y);
            this.Box_Queue_Group.Size = new Size(this.Size.Width - this.Box_Queue_Group.Location.X - Space, this.Size.Height - (this.MenuStrip.Size.Height + (2 * Space)));
            this.Add_Box_Group.Location = new Point(this.FloorView.Location.X, this.FloorView.Location.Y + this.FloorView.Size.Height + Space);
            this.OrganBox.Location = new Point(this.Add_Box_Group.Location.X + this.Add_Box_Group.Size.Width + Space, this.Add_Box_Group.Location.Y);
            this.SearchGroupBox.Location = new Point(this.OrganBox.Location.X + this.OrganBox.Size.Width + Space, this.OrganBox.Location.Y);
            this.ClearGB.Location = new Point(this.SearchGroupBox.Location.X + this.SearchGroupBox.Size.Width + Space, this.SearchGroupBox.Location.Y);
        }

        private void LoadLastOpened() 
        {
            string GarageFile = "";
            string JsonFile = "";
            if (File.Exists("LastOpened.txt"))
            {
                using (StreamReader sr = new StreamReader("LastOpened.txt"))
                {
                    GarageFile = sr.ReadLine();
                    if (GarageFile == "")
                    {
                        MessageBox.Show("You have not opened a file before to do so go to File > Load and either create a new garage or load an existing one");
                        sr.Close();
                        return;
                    }
                    sr.Close();
                }
            }
            else
            {
                MessageBox.Show("You have not opened a file before to do so go to File > Load and either create a new garage or load an existing one");
                return;
            }

            if (File.Exists(GarageFile))
            {
                using (StreamReader sr = new StreamReader(GarageFile))
                {
                    while (!sr.EndOfStream)
                    {
                        JsonFile += sr.ReadLine();
                    }
                    sr.Close();
                }
            }
            else
            {
                MessageBox.Show("Youre save can no longer be found to load a new file go to File > Load and either create a new garage or load an existing one");
                return;
            }

            try
            {
                Forms.JSONContainer collected = JsonConvert.DeserializeObject<Forms.JSONContainer>(JsonFile);
                garage = collected.garage;
                Box_Queue = collected.Box_Queue;
            }
            catch (JsonException)
            {
                MessageBox.Show("Youre save can no longer be loaded to load a new file go to File > Load and either create a new garage or load an existing one");
                return;
            }

            Draw();
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
            using (FileStream fileStream = File.Open("LastOpened.txt", FileMode.Create))
            {
                using (StreamWriter sr = new StreamWriter(fileStream))
                {
                    sr.Write($"{garage.Name}.json");
                    sr.Close();
                }
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
            Box_Queue_Group.Controls.Clear();
            foreach (Box box in Box_Queue)
            {
                BoxPane BoxPan = new BoxPane(box);
                BoxPan.Name = box.Boxid.ToString();
                BoxPan.MouseMove += new MouseEventHandler(this.Box_Drag);
                BoxPan.MouseClick += new MouseEventHandler(this.OpenBoxMenuRC);
                BoxPan.MouseHover += new EventHandler(this.Rotate);
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

            foreach (Box b in garage.Boxes)
            {
                Panel BuffPan;
                if (Floor.Controls.ContainsKey($"BuffPan{b.Boxid}"))
                {
                    BuffPan = Floor.Controls[$"BuffPan{b.Boxid}"] as Panel;
                    if (BuffPan.Location != new Point((int)Math.Round(b.buffer.Position.X * Scale), (int)Math.Round(b.buffer.Position.Y * Scale))) BuffPan.Location = new Point((int)Math.Round(b.buffer.Position.X * Scale), (int)Math.Round(b.buffer.Position.Y * Scale));
                    if (BuffPan.Size != new Size((int)Math.Round(b.buffer.Size.Width * Scale), (int)Math.Round(b.buffer.Size.Height * Scale))) BuffPan.Size = new Size((int)Math.Round(b.buffer.Size.Width * Scale), (int)Math.Round(b.buffer.Size.Height * Scale));
                }
                else
                {
                    BuffPan = new Panel();
                    BuffPan.Name = $"BuffPan{b.Boxid}";
                    BuffPan.BackColor = Color.Coral;
                    BuffPan.Location = new Point((int)Math.Round(b.buffer.Position.X * Scale), (int)Math.Round(b.buffer.Position.Y * Scale));
                    BuffPan.Size = new Size((int)Math.Round(b.buffer.Size.Width * Scale), (int)Math.Round(b.buffer.Size.Height * Scale));

                    Floor.Controls.Add(BuffPan);
                }
                BuffPan.BringToFront();
            }

            foreach (Box b in garage.Boxes)
            {
                BoxPane Pan;
                if (Floor.Controls.ContainsKey(b.Boxid.ToString()))
                {
                    Pan = Floor.Controls[b.Boxid.ToString()] as BoxPane;
                    if (Pan.Location != new Point((int)Math.Round(b.Position.X * Scale), (int)Math.Round(b.Position.Y * Scale))) Pan.Location = new Point((int)Math.Round(b.Position.X * Scale), (int)Math.Round(b.Position.Y * Scale));
                    if (Pan.Size != new Size((int)Math.Round(b.Size.Width * Scale), (int)Math.Round(b.Size.Height * Scale))) Pan.Size = new Size((int)Math.Round(b.Size.Width * Scale), (int)Math.Round(b.Size.Height * Scale));
                }
                else
                {
                    Pan = new BoxPane(b);
                    if (this.Controls.ContainsKey(b.Boxid.ToString())) this.Controls.RemoveByKey(b.Boxid.ToString());
                    Pan.Name = b.Boxid.ToString();
                    Pan.BackColor = b.col;
                    Pan.MouseMove += new MouseEventHandler(this.Box_Drag);
                    Pan.MouseClick += new MouseEventHandler(this.OpenBoxMenuRC);
                    Pan.MouseHover += new EventHandler(this.Rotate);
                    Pan.Location = new Point((int)Math.Round(b.Position.X * Scale), (int)Math.Round(b.Position.Y * Scale));
                    Pan.Size = new Size((int)Math.Round(b.Size.Width * Scale), (int)Math.Round(b.Size.Height * Scale));

                    Floor.Controls.Add(Pan);
                }
                Pan.BringToFront();
            }

            foreach (Door door in garage.doors)
            {
                if (!Floor.Controls.ContainsKey($"door_{door.ID}"))
                {
                    DoorPane Pan = new DoorPane(door);
                    Pan.Name = $"door_{door.ID}";
                    Pan.BackColor = Color.Black;
                    if (door.location.Y == 0 || door.location.Y == garage.Width) Pan.Size = new Size((int)Math.Round(door.radius * Scale), 4);
                    else Pan.Size = new Size(4, (int)Math.Round(door.radius * Scale));
                    if (door.location.Y == garage.Width) Pan.Location = new Point((int)Math.Round(door.location.X * Scale), (int)Math.Round(door.location.Y * Scale) - 4);
                    else if (door.location.X == garage.Length) Pan.Location = new Point((int)Math.Round(door.location.X * Scale) - 4, (int)Math.Round(door.location.Y * Scale));
                    else Pan.Location = new Point((int)Math.Round(door.location.X * Scale), (int)Math.Round(door.location.Y * Scale));
                    Floor.Controls.Add(Pan);
                    Pan.BringToFront();
                }
                else Floor.Controls[$"door_{door.ID}"].BringToFront();
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
                Math.Abs(Col_Pan.BackColor.R - 255) > 5 &&
                Math.Abs(Col_Pan.BackColor.G - 127) > 5 && 
                Math.Abs(Col_Pan.BackColor.B - 80) > 5)
            {
                double weight;
                Size BoxSize;
                try
                {
                    weight = double.Parse(Weight_Txt.Text);
                    BoxSize = new Size(int.Parse(Length_Txt.Text), int.Parse(Width_Txt.Text));
                }
                catch (NullReferenceException)
                {
                    Err_Lbl.Show();
                    return;
                }

                if (weight != 0 && BoxSize.Width > 0 && BoxSize.Height > 0 && BoxSize.Width < garage.Length && BoxSize.Height < garage.Width)
                {
                    Box NewBox = new Box(Box_Queue.Count() + garage.BoxCount, Name_Txt.Text, weight, BoxSize, garage.bufferWidth, Col_Pan.BackColor);
                    Box_Queue.Add(NewBox);
                    DrawQueue();
                }
                else
                {
                    Err_Lbl.Show();
                    return;
                }

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
            Col_Pan.BackColor = Regex.Match(Colour_Txt.Text,
                "#([a-f]|[A-F]|[0-9]){6}").Length == Colour_Txt.Text.Length ? 
                ColorTranslator.FromHtml(Colour_Txt.Text) : Regex.Match(Colour_Txt.Text, "(((25[0-5]|2[0-4][0-9])|1?[0-9]?[0-9]), ){2}((25[0-5]|2[0-4][0-9])|1?[0-9]?[0-9])").Length == Colour_Txt.Text.Length ? 
                RGBString(Colour_Txt.Text): Color.FromName(Colour_Txt.Text);
        }

        private void Rand_Col_Btn_Click(object sender, EventArgs e)
        {
            Col_Pan.BackColor = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
        }

        private void Box_Drag(object sender, MouseEventArgs e)
        {
            BoxPane Pan = sender as BoxPane;
            Pan.box.ResetBuffer();

            if (Box_Queue_Group.Contains(Pan))
            {
                Box_Queue_Group.Controls.Remove(Pan);
                Pan.Location = new Point(Box_Queue_Group.Location.X + Pan.Location.X, Box_Queue_Group.Location.Y + Pan.Location.Y);
                this.Controls.Add(Pan);
                Pan.BringToFront();
            }

            if (e.Button == MouseButtons.Right) OpenBoxMenuRC(sender, e);
            Rotate(Pan, e);

            if (e.Button == MouseButtons.Left)
            {
                Pan.Location = new Point(e.X + Pan.Location.X, e.Y + Pan.Location.Y);
            }
            else if (Cursor.Position.X > FloorView.Location.X && Cursor.Position.X < FloorView.Location.X + FloorView.Size.Width &&
                Cursor.Position.Y > FloorView.Location.Y && Cursor.Position.Y < FloorView.Location.Y + FloorView.Size.Height)
            {
                Box_Queue.Remove(Pan.box);
                Point OldPos;
                if (!FloorView.Controls["Floor"].Controls.Contains(Pan))
                {
                    Point NewLoc = new Point((int)Math.Round((Pan.Location.X - FloorView.Location.X - FloorView.Controls["Floor"].Location.X) / Scale), (int)Math.Round((Pan.Location.Y - FloorView.Location.Y) / Scale));
                    if (Pan.Location.X + Pan.Size.Width > FloorView.Controls["Floor"].Size.Width) NewLoc.X = garage.Length - Pan.box.Size.Width;
                    if (Pan.Location.Y + Pan.Size.Height > FloorView.Controls["Floor"].Size.Height) NewLoc.Y = garage.Width - Pan.box.Size.Height;
                    if (!garage.Boxes.Contains(Pan.box)) garage.AddBox(Pan.box, NewLoc);
                    Pan.box.buffer.Position = new Point(NewLoc.X - garage.bufferWidth, NewLoc.Y - garage.bufferWidth);
                    Draw();
                }
                else
                {
                    Point NewLoc = new Point((int)Math.Round(Pan.Location.X / Scale), (int)Math.Round(Pan.Location.Y / Scale));
                    if (Pan.Location.X + Pan.Size.Width > FloorView.Controls["Floor"].Size.Width) NewLoc.X = garage.Length - Pan.box.Size.Width;
                    if (Pan.Location.Y + Pan.Size.Height > FloorView.Controls["Floor"].Size.Height) NewLoc.Y = garage.Width - Pan.box.Size.Height;
                    Pan.box.buffer.Position = new Point(NewLoc.X - garage.bufferWidth, NewLoc.Y - garage.bufferWidth);
                    OldPos = Pan.box.Position;
                    Pan.box.Position = NewLoc;
                    if (OldPos != NewLoc) Draw();
                }
            }
            else if (Cursor.Position.X > Box_Queue_Group.Location.X && Cursor.Position.X < Box_Queue_Group.Location.X + Box_Queue_Group.Size.Width &&
                Cursor.Position.Y > Box_Queue_Group.Location.Y && Cursor.Position.Y < Box_Queue_Group.Location.Y + Box_Queue_Group.Size.Height)
            {
                if (!Box_Queue.Contains(Pan.box))
                {
                    Box_Queue.Add(Pan.box);
                }
                this.Controls.Remove(Pan);
                Draw();
            }
            else
            {
                this.Controls.Remove(Pan);
                Draw();
            }
        }

        private void OpenBoxMenuRC(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) Forms.Box_Menu.FormShow(sender, e);
        }

        private void OrgGarageBtn_Click(object sender, EventArgs e)
        {
            FailOrg1.Visible = false;
            FailOrg2.Visible = false;
            if (this.IncBoxQueueCheck.Checked)
            {
                try
                {
                    garage.Organise(Box_Queue);
                    Box_Queue.Clear();
                }
                catch (IncorrectPlacementException)
                {
                    garage.Boxes.RemoveAll((x) => Box_Queue.Contains(x));
                    FailOrg1.Visible = true;
                    FailOrg2.Visible = true;
                }
            }
            else
            {
                try
                {
                    garage.Organise();
                }
                catch (IncorrectPlacementException)
                {
                    FailOrg1.Visible = true;
                    FailOrg2.Visible = true;
                }
            }
            Draw();
        }

        private Color RGBString(string ColourString)
        {
            string[] Cols = ColourString.Split(',').Select(x => x.Replace(" ", "")).ToArray();
            return Color.FromArgb(int.Parse(Cols[0]), int.Parse(Cols[1]), int.Parse(Cols[2]));
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchError.Visible = false;
            if (FloorView.Controls.ContainsKey("Floor"))
            {
                int BID = garage.SearchBoxes(SearchBar.Text);
                Panel Floor = FloorView.Controls["Floor"] as Panel;
                if (Floor.Controls.ContainsKey(BID.ToString()))
                {
                    BoxPane FoundBox = Floor.Controls[BID.ToString()] as BoxPane;
                    Task.Run(() => FlashBox(FoundBox));
                }
                else
                {
                    SearchError.Text = "there is no item which matches that search";
                    SearchError.Visible = true;
                }
            }
            else
            {
                SearchError.Text = "There is no garage loaded";
                SearchError.Visible = true;
            }
        }

        private void FlashBox(BoxPane BX)
        {
            Color Original = BX.BackColor;
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

            for (int i = 0; i < 5; i++)
            {
                BX.BackColor = Inverted;
                Thread.Sleep(300);
                BX.BackColor = Original;
                Thread.Sleep(300);
            }
        }

        public void RemovePane(Box box)
        {
            FloorView.Controls["Floor"].Controls.RemoveByKey(box.Boxid.ToString());
            FloorView.Controls["Floor"].Controls.RemoveByKey($"BuffPan{box.Boxid}");
            if (Box_Queue.Contains(box))
            {
                Box_Queue.Remove(box);
                DrawQueue();
            }
            
            //FloorView.Controls["Floor"].Controls.Remove(bp);
        }

        [DllImport("user32.dll")]
        private static extern short GetKeyState(Keys key); // had to find this on the internet, worlds best hidden function

        private void Rotate(object sender, EventArgs e)
        {
            BoxPane Pan = sender as BoxPane;

            if (keyAllow && int.Parse(GetKeyState(Keys.R).ToString()) < 0)
            {
                Pan.box.Size = new Size(Pan.box.Size.Height, Pan.box.Size.Width);
                Pan.box.buffer.Size = new Size(Pan.box.buffer.Size.Height, Pan.box.buffer.Size.Width);
                Pan.Size = new Size(Pan.Size.Height, Pan.Size.Width);
                Draw();
                keyAllow = false;
                KeyPressTimeOut.Start();
            }
        }

        private void ClearQueueButton_Click(object sender, EventArgs e)
        {
            Box_Queue.Clear();
            DrawQueue();
        }

        public void Reset()
        {
            FloorView.Controls.Clear();
            Box_Queue.Clear();
        }
    }
}
