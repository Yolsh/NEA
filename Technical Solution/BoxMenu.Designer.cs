namespace Technical_Solution
{
    partial class BoxMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Add_Box_Group = new System.Windows.Forms.GroupBox();
            this.Err_Lbl = new System.Windows.Forms.Label();
            this.Edit_Btn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Col_Pan = new System.Windows.Forms.Panel();
            this.Rand_Col_Btn = new System.Windows.Forms.Button();
            this.Colour_Txt = new System.Windows.Forms.TextBox();
            this.Width_Txt = new System.Windows.Forms.TextBox();
            this.Length_Txt = new System.Windows.Forms.TextBox();
            this.Weight_Txt = new System.Windows.Forms.TextBox();
            this.Name_Txt = new System.Windows.Forms.TextBox();
            this.ContentsList = new System.Windows.Forms.GroupBox();
            this.AddContentsBox = new System.Windows.Forms.GroupBox();
            this.AddContBtn = new System.Windows.Forms.Button();
            this.AddContTxt = new System.Windows.Forms.TextBox();
            this.RemoveBox = new System.Windows.Forms.Button();
            this.Add_Box_Group.SuspendLayout();
            this.AddContentsBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // Add_Box_Group
            // 
            this.Add_Box_Group.Controls.Add(this.RemoveBox);
            this.Add_Box_Group.Controls.Add(this.Err_Lbl);
            this.Add_Box_Group.Controls.Add(this.Edit_Btn);
            this.Add_Box_Group.Controls.Add(this.label5);
            this.Add_Box_Group.Controls.Add(this.label4);
            this.Add_Box_Group.Controls.Add(this.label3);
            this.Add_Box_Group.Controls.Add(this.label2);
            this.Add_Box_Group.Controls.Add(this.label1);
            this.Add_Box_Group.Controls.Add(this.Col_Pan);
            this.Add_Box_Group.Controls.Add(this.Rand_Col_Btn);
            this.Add_Box_Group.Controls.Add(this.Colour_Txt);
            this.Add_Box_Group.Controls.Add(this.Width_Txt);
            this.Add_Box_Group.Controls.Add(this.Length_Txt);
            this.Add_Box_Group.Controls.Add(this.Weight_Txt);
            this.Add_Box_Group.Controls.Add(this.Name_Txt);
            this.Add_Box_Group.Location = new System.Drawing.Point(12, 12);
            this.Add_Box_Group.Name = "Add_Box_Group";
            this.Add_Box_Group.Size = new System.Drawing.Size(311, 196);
            this.Add_Box_Group.TabIndex = 3;
            this.Add_Box_Group.TabStop = false;
            this.Add_Box_Group.Text = "Edit Box Data";
            // 
            // Err_Lbl
            // 
            this.Err_Lbl.AutoSize = true;
            this.Err_Lbl.ForeColor = System.Drawing.Color.Crimson;
            this.Err_Lbl.Location = new System.Drawing.Point(6, 165);
            this.Err_Lbl.Name = "Err_Lbl";
            this.Err_Lbl.Size = new System.Drawing.Size(126, 13);
            this.Err_Lbl.TabIndex = 13;
            this.Err_Lbl.Text = "Some Fields are incorrect";
            this.Err_Lbl.Visible = false;
            // 
            // Edit_Btn
            // 
            this.Edit_Btn.Location = new System.Drawing.Point(243, 165);
            this.Edit_Btn.Name = "Edit_Btn";
            this.Edit_Btn.Size = new System.Drawing.Size(62, 23);
            this.Edit_Btn.TabIndex = 12;
            this.Edit_Btn.Text = "Edit Box";
            this.Edit_Btn.UseVisualStyleBackColor = true;
            this.Edit_Btn.Click += new System.EventHandler(this.Edit_Btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Colour:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Length:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Weight:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Col_Pan
            // 
            this.Col_Pan.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Col_Pan.Location = new System.Drawing.Point(78, 129);
            this.Col_Pan.Name = "Col_Pan";
            this.Col_Pan.Size = new System.Drawing.Size(12, 14);
            this.Col_Pan.TabIndex = 6;
            // 
            // Rand_Col_Btn
            // 
            this.Rand_Col_Btn.Location = new System.Drawing.Point(202, 123);
            this.Rand_Col_Btn.Name = "Rand_Col_Btn";
            this.Rand_Col_Btn.Size = new System.Drawing.Size(58, 20);
            this.Rand_Col_Btn.TabIndex = 5;
            this.Rand_Col_Btn.Text = "Random";
            this.Rand_Col_Btn.UseVisualStyleBackColor = true;
            // 
            // Colour_Txt
            // 
            this.Colour_Txt.Location = new System.Drawing.Point(96, 123);
            this.Colour_Txt.Name = "Colour_Txt";
            this.Colour_Txt.Size = new System.Drawing.Size(100, 20);
            this.Colour_Txt.TabIndex = 4;
            // 
            // Width_Txt
            // 
            this.Width_Txt.Location = new System.Drawing.Point(96, 97);
            this.Width_Txt.Name = "Width_Txt";
            this.Width_Txt.Size = new System.Drawing.Size(100, 20);
            this.Width_Txt.TabIndex = 3;
            // 
            // Length_Txt
            // 
            this.Length_Txt.Location = new System.Drawing.Point(96, 71);
            this.Length_Txt.Name = "Length_Txt";
            this.Length_Txt.Size = new System.Drawing.Size(100, 20);
            this.Length_Txt.TabIndex = 2;
            // 
            // Weight_Txt
            // 
            this.Weight_Txt.Location = new System.Drawing.Point(96, 45);
            this.Weight_Txt.Name = "Weight_Txt";
            this.Weight_Txt.Size = new System.Drawing.Size(100, 20);
            this.Weight_Txt.TabIndex = 1;
            // 
            // Name_Txt
            // 
            this.Name_Txt.Location = new System.Drawing.Point(96, 19);
            this.Name_Txt.Name = "Name_Txt";
            this.Name_Txt.Size = new System.Drawing.Size(100, 20);
            this.Name_Txt.TabIndex = 0;
            // 
            // ContentsList
            // 
            this.ContentsList.Location = new System.Drawing.Point(329, 12);
            this.ContentsList.Name = "ContentsList";
            this.ContentsList.Size = new System.Drawing.Size(179, 283);
            this.ContentsList.TabIndex = 4;
            this.ContentsList.TabStop = false;
            this.ContentsList.Text = "List of Box Contents";
            // 
            // AddContentsBox
            // 
            this.AddContentsBox.Controls.Add(this.AddContTxt);
            this.AddContentsBox.Controls.Add(this.AddContBtn);
            this.AddContentsBox.Location = new System.Drawing.Point(12, 214);
            this.AddContentsBox.Name = "AddContentsBox";
            this.AddContentsBox.Size = new System.Drawing.Size(311, 81);
            this.AddContentsBox.TabIndex = 5;
            this.AddContentsBox.TabStop = false;
            this.AddContentsBox.Text = "Add New Contents";
            // 
            // AddContBtn
            // 
            this.AddContBtn.Location = new System.Drawing.Point(230, 34);
            this.AddContBtn.Name = "AddContBtn";
            this.AddContBtn.Size = new System.Drawing.Size(75, 20);
            this.AddContBtn.TabIndex = 0;
            this.AddContBtn.Text = "Add Item";
            this.AddContBtn.UseVisualStyleBackColor = true;
            this.AddContBtn.Click += new System.EventHandler(this.AddContBtn_Click);
            // 
            // AddContTxt
            // 
            this.AddContTxt.Location = new System.Drawing.Point(6, 34);
            this.AddContTxt.Name = "AddContTxt";
            this.AddContTxt.Size = new System.Drawing.Size(218, 20);
            this.AddContTxt.TabIndex = 1;
            // 
            // RemoveBox
            // 
            this.RemoveBox.Location = new System.Drawing.Point(175, 165);
            this.RemoveBox.Name = "RemoveBox";
            this.RemoveBox.Size = new System.Drawing.Size(62, 23);
            this.RemoveBox.TabIndex = 14;
            this.RemoveBox.Text = "Delete";
            this.RemoveBox.UseVisualStyleBackColor = true;
            this.RemoveBox.Click += new System.EventHandler(this.RemoveBox_Click);
            // 
            // BoxMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 307);
            this.Controls.Add(this.AddContentsBox);
            this.Controls.Add(this.ContentsList);
            this.Controls.Add(this.Add_Box_Group);
            this.Name = "BoxMenu";
            this.Text = "BoxMenu";
            this.Load += new System.EventHandler(this.BoxMenu_Load);
            this.Add_Box_Group.ResumeLayout(false);
            this.Add_Box_Group.PerformLayout();
            this.AddContentsBox.ResumeLayout(false);
            this.AddContentsBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Add_Box_Group;
        private System.Windows.Forms.Label Err_Lbl;
        private System.Windows.Forms.Button Edit_Btn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Col_Pan;
        private System.Windows.Forms.Button Rand_Col_Btn;
        private System.Windows.Forms.TextBox Colour_Txt;
        private System.Windows.Forms.TextBox Width_Txt;
        private System.Windows.Forms.TextBox Length_Txt;
        private System.Windows.Forms.TextBox Weight_Txt;
        private System.Windows.Forms.TextBox Name_Txt;
        private System.Windows.Forms.GroupBox ContentsList;
        private System.Windows.Forms.GroupBox AddContentsBox;
        private System.Windows.Forms.TextBox AddContTxt;
        private System.Windows.Forms.Button AddContBtn;
        private System.Windows.Forms.Button RemoveBox;
    }
}