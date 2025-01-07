using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using Newtonsoft.Json;

namespace Technical_Solution
{
    public partial class LoadMenu : Form
    {
        Garage NewGarage;
        private string GarageName;
        private int GLength;
        private int GWidth;
        private int MinSpacing;

        public LoadMenu()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.LoadMenu_Res);
        }

        private void New_Btn_Click(object sender, EventArgs e)
        {
            Load_File_Box.Hide();
            New_Inputs.Show();
        }

        private void LoadMenu_Res(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        private void Create_Btn_Click(object sender, EventArgs e)
        {
            Incorrect_Warn.Hide();
            if (Garage_Name.Text != "" &&
                Regex.IsMatch(_Length.Text, "[1-9]+[0-9]*") &&
                Regex.IsMatch(_Width.Text, "[1-9]+[0-9]*") &&
                Regex.IsMatch(Min_Spacing.Text, "[1-9]+[0-9]*") && 
                Regex.IsMatch(No_Doors.Text, "[1-9]+[0-9]*") &&
                _Length.Text != "" && _Width.Text != "" && Min_Spacing.Text != "" && No_Doors.Text != "")
            {
                GarageName = Garage_Name.Text;
                GLength = int.Parse(_Length.Text);
                GWidth = int.Parse(_Width.Text);
                MinSpacing = int.Parse(Min_Spacing.Text);
                CreateDoorForm(int.Parse(No_Doors.Text));
                Doors_In_Group.Show();
            }
            else
            {
                Incorrect_Warn.Show();
            }
        }

        private void Check_Btn_Click_1(object sender, EventArgs e)
        {
            Incorrect_Info_Lab1.Hide();
            Incorrect_Info_Label2.Hide();
            bool correct = true;
            int count = 0;
            foreach (GroupBox gb in Doors_In_Group.Controls.OfType<GroupBox>())
            {
                if (correct == false) break;
                List<int> DoorVals = new List<int>();

                foreach (TextBox tb in gb.Controls.OfType<TextBox>())
                {
                    if (tb.Text == "" || Regex.IsMatch(tb.Text, "[0-9]+") == false)
                    {
                        correct = false;
                        break;
                    }
                    DoorVals.Add(int.Parse(tb.Text));
                }

                foreach (ComboBox cb in gb.Controls.OfType<ComboBox>())
                {
                    if (cb.SelectedIndex == -1)
                    {
                        correct = false;
                        break;
                    }
                    DoorVals.Add(cb.SelectedIndex);
                }

                if (!correct) break;

                if (count == 0)
                {
                    switch (DoorVals[2])
                    {
                        case 0:
                            NewGarage = new Garage(0, 0, GarageName, GLength, GWidth, MinSpacing, DoorVals[0], DoorVals[1], Door.Wall.Top);
                            break;
                        case 1:
                            NewGarage = new Garage(0, 0, GarageName, GLength, GWidth, MinSpacing, DoorVals[0], DoorVals[1], Door.Wall.Bottom);
                            break;
                        case 2:
                            NewGarage = new Garage(0, 0, GarageName, GLength, GWidth, MinSpacing, DoorVals[0], DoorVals[1], Door.Wall.Left);
                            break;
                        case 3:
                            NewGarage = new Garage(0, 0, GarageName, GLength, GWidth, MinSpacing, DoorVals[0], DoorVals[1], Door.Wall.Right);
                            break;
                    }
                }
                else
                {
                    try
                    {
                        switch (DoorVals[2])
                        {
                            case 0:
                                NewGarage.AddDoor(DoorVals[0], DoorVals[1], Door.Wall.Top);
                                break;
                            case 1:
                                NewGarage.AddDoor(DoorVals[0], DoorVals[1], Door.Wall.Bottom);
                                break;
                            case 2:
                                NewGarage.AddDoor(DoorVals[0], DoorVals[1], Door.Wall.Left);
                                break;
                            case 3:
                                NewGarage.AddDoor(DoorVals[0], DoorVals[1], Door.Wall.Right);
                                break;
                        }
                    }
                    catch (IncorrectPlacementException)
                    {
                        correct = false;
                        break;
                    }
                }
                count++;
            }
            if (!correct)
            {
                Incorrect_Info_Lab1.Show();
                Incorrect_Info_Label2.Show();
            }
            else Load_New_Btn.Show();
        }

        private void CreateDoorForm(int numDoors)
        {
            List<GroupBox> gbs = new List<GroupBox>();
            string[] existingGbs = Doors_In_Group.Controls.OfType<GroupBox>().Select(x => x.Name).ToArray();
            foreach (string key in existingGbs) Doors_In_Group.Controls.RemoveByKey(key);

            for (int i = 0; i < numDoors; i++)
            {
                GroupBox groupBox = new GroupBox();

                groupBox.Name = $"Door_{i}";
                groupBox.Text = $"Door {i+1}";
                groupBox.Location = new Point(10, 20 + i*150);
                groupBox.Size = new Size(200, 150);

                Label Door_Width_Lab = new Label();
                Label Door_Wall_Lab = new Label();
                Label Door_Dist_Lab = new Label();

                TextBox Door_Width_Txt = new TextBox();
                Door_Width_Txt.Name = $"Door_Width_Txt_{i}";
                ComboBox Door_Wall_Cb = new ComboBox();
                Door_Wall_Cb.Name = $"Door_Wall_Cb_{i}";
                TextBox Door_Dist_Txt = new TextBox();
                Door_Dist_Txt.Name = $"Door_Dist_Txt_{i}";

                Door_Width_Lab.Text = "Door Width:";
                Door_Wall_Lab.Text = "Wall of Door:";
                Door_Dist_Lab.Text = "Distance:";

                Door_Width_Txt.Size = new Size(60, 20);
                Door_Wall_Cb.Size = new Size(60, 21);
                Door_Dist_Txt.Size = new Size(60, 20);
                Door_Width_Lab.Size = new Size(70, 20);
                Door_Wall_Lab.Size = new Size(70, 20);
                Door_Dist_Lab.Size = new Size(70, 20);

                Door_Wall_Cb.Items.Add("Top");
                Door_Wall_Cb.Items.Add("Bottom");
                Door_Wall_Cb.Items.Add("Left");
                Door_Wall_Cb.Items.Add("Right");

                Door_Width_Lab.Location = new Point(10, 20);
                Door_Width_Txt.Location = new Point(80, 20);
                Door_Wall_Lab.Location = new Point(10, 50);
                Door_Wall_Cb.Location = new Point(80, 50);
                Door_Dist_Lab.Location = new Point(10, 80);
                Door_Dist_Txt.Location = new Point(80, 80);

                groupBox.Controls.Add(Door_Width_Lab);
                groupBox.Controls.Add(Door_Wall_Lab);
                groupBox.Controls.Add(Door_Dist_Lab);
                groupBox.Controls.Add(Door_Width_Txt);
                groupBox.Controls.Add(Door_Wall_Cb);
                groupBox.Controls.Add(Door_Dist_Txt);

                Doors_In_Group.Controls.Add(groupBox);
            }

            int offset = 20 + numDoors * 150;
            Check_Btn.Location = new Point(10, offset);

            Incorrect_Info_Lab1.Location = new Point(10, offset + 25);
            Incorrect_Info_Label2.Location = new Point(10, offset + 38);
        }

        private void Load_New_Btn_Click(object sender, EventArgs e)
        {
            Forms.MainWindow.garage = NewGarage;
            Forms.MainWindow.Reset();
            Forms.MainWindow.Draw();
            this.Hide();
        }

        private void Load_Btn_Click(object sender, EventArgs e)
        {
            New_Inputs.Hide();
            Load_File_Box.Show();
        }

        private void Find_File_Click(object sender, EventArgs e)
        {
            string save = "";
            if (File.Exists($"{File_Name_Txt.Text}.json"))
            {
                using (StreamReader sr = new StreamReader($"{File_Name_Txt.Text}.json"))
                {
                    while (!sr.EndOfStream)
                    {
                        save += sr.ReadLine();
                    }
                    sr.Close();
                }
            }
            else
            {
                File_Err.Show();
                return;
            }

            try
            {
                Forms.JSONContainer collected = JsonConvert.DeserializeObject<Forms.JSONContainer>(save);
                Forms.MainWindow.garage = collected.garage;
                Forms.MainWindow.Box_Queue = collected.Box_Queue;
            }
            catch (JsonException)
            {
                MessageBox.Show("Youre save can no longer be loaded to load a new file go to File > Load and either create a new garage or load an existing one");
                return;
            }

            using (FileStream fileStream = File.Open("LastOpened.txt", FileMode.Create))
            {
                using (StreamWriter sr = new StreamWriter(fileStream))
                {
                    sr.Write($"{File_Name_Txt.Text}.json");
                    sr.Close();
                }
            }

            Forms.MainWindow.Draw(); 
            this.Hide();
        }
    }
}
