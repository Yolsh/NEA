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

namespace Technical_Solution
{
    public partial class BoxMenu : Form
    {
        private Box ToEdit;

        public BoxMenu()
        {
            InitializeComponent();
            this.FormClosing += new FormClosingEventHandler(this.BoxMenu_Res);
        }

        private void BoxMenu_Res(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        public void FormShow(object sender, MouseEventArgs e)
        {
            this.Show();
            MyPane pan = sender as MyPane;
            ToEdit = pan.box;
            Name_Txt.Text = ToEdit.Name;
            Weight_Txt.Text = ToEdit.Weight.ToString();
            Length_Txt.Text = ToEdit.Size.Width.ToString();
            Width_Txt.Text = ToEdit.Size.Height.ToString();
            Col_Pan.BackColor = pan.BackColor;
            Colour_Txt.Text = pan.BackColor.Name;
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
                Forms.MainWindow.Draw();
                this.Close();
            }
            else Err_Lbl.Show();
        }
    }
}
