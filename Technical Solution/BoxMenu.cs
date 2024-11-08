using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace Technical_Solution
{
    public partial class BoxMenu : Form
    {
        private Box ToEdit;
        private Random rand;

        public BoxMenu()
        {
            InitializeComponent();
            rand = new Random();
            this.FormClosing += new FormClosingEventHandler(this.BoxMenu_Res);
            this.Rand_Col_Btn.Click += new EventHandler(this.Rand_Col_Btn_Click);
            this.Colour_Txt.TextChanged += new EventHandler(this.Colour_Txt_TextChanged);
        }

        private void BoxMenu_Res(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        public void FormShow(object sender, MouseEventArgs e)
        {
            this.Show();
            BoxPane pan = sender as BoxPane;
            ToEdit = pan.box;
            Name_Txt.Text = ToEdit.Name;
            Weight_Txt.Text = ToEdit.Weight.ToString();
            Length_Txt.Text = ToEdit.Size.Width.ToString();
            Width_Txt.Text = ToEdit.Size.Height.ToString();
            Col_Pan.BackColor = pan.BackColor;
            Colour_Txt.Text = pan.BackColor.Name;
            DrawContents();
        }

        private void DrawContents()
        {
            ContentsList.Controls.Clear();
            int spacing = 30;
            foreach (string Item in ToEdit.Contents)
            {
                Label ItemLbl = new Label();
                ItemLbl.Click += new EventHandler(this.RemoveLabel);
                ItemLbl.Text = Item;
                ItemLbl.Location = new Point(25, spacing);
                spacing += 20;
                ContentsList.Controls.Add(ItemLbl);
            }
        }

        private void Edit_Btn_Click(object sender, EventArgs e)
        {
            if (Name_Txt.Text != "" && Weight_Txt.Text != "" && Length_Txt.Text != "" && Width_Txt.Text != "" && Colour_Txt.Text != "" &&
                Regex.IsMatch(Weight_Txt.Text, "[0-9]*\\.*[0-9]+") &&
                Regex.IsMatch(Length_Txt.Text, "[0-9]+") &&
                Regex.IsMatch(Width_Txt.Text, "[0-9]+"))
            {
                ToEdit.Name = Name_Txt.Text;
                ToEdit.Weight = double.Parse(Weight_Txt.Text);
                ToEdit.Size.Width = int.Parse(Length_Txt.Text);
                ToEdit.Size.Height = int.Parse(Width_Txt.Text);
                ToEdit.col = Col_Pan.BackColor;
                ToEdit.buffer = new BoxBuffer(ToEdit, Forms.MainWindow.garage.bufferWidth);
                Forms.MainWindow.Draw();
                this.Close();
            }
            else Err_Lbl.Show();
        }

        private void AddContBtn_Click(object sender, EventArgs e)
        {
            if (AddContTxt.Text != "") ToEdit.Contents.Add(AddContTxt.Text);
            AddContTxt.Text = "";
            DrawContents();
        }

        private void RemoveLabel(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show($"Delete {(sender as Label).Text}?", "Delete", MessageBoxButtons.YesNo);

            if (dr == DialogResult.Yes)
            {
                Label L = sender as Label;
                ToEdit.Contents.Remove(L.Text);
                DrawContents();
            }
        }

        private void RemoveBox_Click(object sender, EventArgs e)
        {
            Forms.MainWindow.garage.Boxes.Remove(ToEdit);
            Forms.MainWindow.RemovePane(ToEdit);
            Forms.MainWindow.Draw();
            this.Close();
        }

        private void Colour_Txt_TextChanged(object sender, EventArgs e)
        {
            Col_Pan.BackColor = Regex.Match(Colour_Txt.Text,
                "#([a-f]|[A-F]|[0-9]){6}").Length == Colour_Txt.Text.Length ?
                ColorTranslator.FromHtml(Colour_Txt.Text) : Regex.Match(Colour_Txt.Text, "(((25[0-5]|2[0-4][0-9])|1?[0-9]?[0-9]), ){2}((25[0-5]|2[0-4][0-9])|1?[0-9]?[0-9])").Length == Colour_Txt.Text.Length ?
                RGBString(Colour_Txt.Text) : Color.FromName(Colour_Txt.Text);
        }
        private Color RGBString(string ColourString)
        {
            string[] Cols = ColourString.Split(',').Select(x => x.Replace(" ", "")).ToArray();
            return Color.FromArgb(int.Parse(Cols[0]), int.Parse(Cols[1]), int.Parse(Cols[2]));
        }
        private void Rand_Col_Btn_Click(object sender, EventArgs e)
        {
            Col_Pan.BackColor = Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256));
        }
    }
}
