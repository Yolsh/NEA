namespace Technical_Solution
{
    partial class LoadMenu
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Load_Btn = new System.Windows.Forms.Button();
            this.New_Btn = new System.Windows.Forms.Button();
            this.New_Inputs = new System.Windows.Forms.GroupBox();
            this.Load_New_Btn = new System.Windows.Forms.Button();
            this.Incorrect_Warn = new System.Windows.Forms.Label();
            this.No_Doors = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Check_Btn = new System.Windows.Forms.Button();
            this.Incorrect_Info_Lab1 = new System.Windows.Forms.Label();
            this.Create_Btn = new System.Windows.Forms.Button();
            this.Min_Spacing = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._Width = new System.Windows.Forms.TextBox();
            this._Length = new System.Windows.Forms.TextBox();
            this.Garage_Name = new System.Windows.Forms.TextBox();
            this.Load_File_Box = new System.Windows.Forms.GroupBox();
            this.Find_File = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.File_Name_Txt = new System.Windows.Forms.TextBox();
            this.File_Err = new System.Windows.Forms.Label();
            this.Doors_In_Group = new System.Windows.Forms.Panel();
            this.Incorrect_Info_Label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.New_Inputs.SuspendLayout();
            this.Load_File_Box.SuspendLayout();
            this.Doors_In_Group.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Coral;
            this.groupBox1.Controls.Add(this.Load_Btn);
            this.groupBox1.Controls.Add(this.New_Btn);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 426);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Load_Btn
            // 
            this.Load_Btn.BackColor = System.Drawing.Color.Coral;
            this.Load_Btn.Location = new System.Drawing.Point(6, 48);
            this.Load_Btn.Name = "Load_Btn";
            this.Load_Btn.Size = new System.Drawing.Size(75, 23);
            this.Load_Btn.TabIndex = 1;
            this.Load_Btn.Text = "Load";
            this.Load_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Load_Btn.UseVisualStyleBackColor = false;
            this.Load_Btn.Click += new System.EventHandler(this.Load_Btn_Click);
            // 
            // New_Btn
            // 
            this.New_Btn.BackColor = System.Drawing.Color.Coral;
            this.New_Btn.Location = new System.Drawing.Point(6, 19);
            this.New_Btn.Name = "New_Btn";
            this.New_Btn.Size = new System.Drawing.Size(75, 23);
            this.New_Btn.TabIndex = 0;
            this.New_Btn.Text = "New";
            this.New_Btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.New_Btn.UseVisualStyleBackColor = false;
            this.New_Btn.Click += new System.EventHandler(this.New_Btn_Click);
            // 
            // New_Inputs
            // 
            this.New_Inputs.Controls.Add(this.Doors_In_Group);
            this.New_Inputs.Controls.Add(this.Load_New_Btn);
            this.New_Inputs.Controls.Add(this.Incorrect_Warn);
            this.New_Inputs.Controls.Add(this.No_Doors);
            this.New_Inputs.Controls.Add(this.label5);
            this.New_Inputs.Controls.Add(this.Create_Btn);
            this.New_Inputs.Controls.Add(this.Min_Spacing);
            this.New_Inputs.Controls.Add(this.label4);
            this.New_Inputs.Controls.Add(this.label3);
            this.New_Inputs.Controls.Add(this.label2);
            this.New_Inputs.Controls.Add(this.label1);
            this.New_Inputs.Controls.Add(this._Width);
            this.New_Inputs.Controls.Add(this._Length);
            this.New_Inputs.Controls.Add(this.Garage_Name);
            this.New_Inputs.Location = new System.Drawing.Point(167, 12);
            this.New_Inputs.Name = "New_Inputs";
            this.New_Inputs.Size = new System.Drawing.Size(621, 426);
            this.New_Inputs.TabIndex = 1;
            this.New_Inputs.TabStop = false;
            this.New_Inputs.Text = "Garage Creator";
            this.New_Inputs.Visible = false;
            // 
            // Load_New_Btn
            // 
            this.Load_New_Btn.Location = new System.Drawing.Point(7, 267);
            this.Load_New_Btn.Name = "Load_New_Btn";
            this.Load_New_Btn.Size = new System.Drawing.Size(75, 23);
            this.Load_New_Btn.TabIndex = 13;
            this.Load_New_Btn.Text = "Load";
            this.Load_New_Btn.UseVisualStyleBackColor = true;
            this.Load_New_Btn.Visible = false;
            this.Load_New_Btn.Click += new System.EventHandler(this.Load_New_Btn_Click);
            // 
            // Incorrect_Warn
            // 
            this.Incorrect_Warn.AutoSize = true;
            this.Incorrect_Warn.ForeColor = System.Drawing.Color.Crimson;
            this.Incorrect_Warn.Location = new System.Drawing.Point(6, 251);
            this.Incorrect_Warn.Name = "Incorrect_Warn";
            this.Incorrect_Warn.Size = new System.Drawing.Size(10, 13);
            this.Incorrect_Warn.TabIndex = 12;
            this.Incorrect_Warn.Text = " ";
            this.Incorrect_Warn.Visible = false;
            // 
            // No_Doors
            // 
            this.No_Doors.Location = new System.Drawing.Point(104, 182);
            this.No_Doors.Name = "No_Doors";
            this.No_Doors.Size = new System.Drawing.Size(100, 20);
            this.No_Doors.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Num Doors:";
            // 
            // Check_Btn
            // 
            this.Check_Btn.Location = new System.Drawing.Point(26, 5);
            this.Check_Btn.Name = "Check_Btn";
            this.Check_Btn.Size = new System.Drawing.Size(75, 23);
            this.Check_Btn.TabIndex = 14;
            this.Check_Btn.Text = "Check";
            this.Check_Btn.UseVisualStyleBackColor = true;
            this.Check_Btn.Click += new System.EventHandler(this.Check_Btn_Click_1);
            // 
            // Incorrect_Info_Lab1
            // 
            this.Incorrect_Info_Lab1.AutoSize = true;
            this.Incorrect_Info_Lab1.ForeColor = System.Drawing.Color.Crimson;
            this.Incorrect_Info_Lab1.Location = new System.Drawing.Point(23, 45);
            this.Incorrect_Info_Lab1.Name = "Incorrect_Info_Lab1";
            this.Incorrect_Info_Lab1.Size = new System.Drawing.Size(128, 13);
            this.Incorrect_Info_Lab1.TabIndex = 13;
            this.Incorrect_Info_Lab1.Text = "Some of the info provided";
            this.Incorrect_Info_Lab1.Visible = false;
            // 
            // Create_Btn
            // 
            this.Create_Btn.Location = new System.Drawing.Point(6, 225);
            this.Create_Btn.Name = "Create_Btn";
            this.Create_Btn.Size = new System.Drawing.Size(75, 23);
            this.Create_Btn.TabIndex = 8;
            this.Create_Btn.Text = "Create";
            this.Create_Btn.UseVisualStyleBackColor = true;
            this.Create_Btn.Click += new System.EventHandler(this.Create_Btn_Click);
            // 
            // Min_Spacing
            // 
            this.Min_Spacing.Location = new System.Drawing.Point(104, 139);
            this.Min_Spacing.Name = "Min_Spacing";
            this.Min_Spacing.Size = new System.Drawing.Size(100, 20);
            this.Min_Spacing.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Min Spacing (cm):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Width (cm):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Length (cm):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Garage Name:";
            // 
            // _Width
            // 
            this._Width.Location = new System.Drawing.Point(104, 96);
            this._Width.Name = "_Width";
            this._Width.Size = new System.Drawing.Size(100, 20);
            this._Width.TabIndex = 2;
            // 
            // _Length
            // 
            this._Length.Location = new System.Drawing.Point(104, 57);
            this._Length.Name = "_Length";
            this._Length.Size = new System.Drawing.Size(100, 20);
            this._Length.TabIndex = 1;
            // 
            // Garage_Name
            // 
            this.Garage_Name.Location = new System.Drawing.Point(104, 21);
            this.Garage_Name.Name = "Garage_Name";
            this.Garage_Name.Size = new System.Drawing.Size(100, 20);
            this.Garage_Name.TabIndex = 0;
            // 
            // Load_File_Box
            // 
            this.Load_File_Box.Controls.Add(this.Find_File);
            this.Load_File_Box.Controls.Add(this.label6);
            this.Load_File_Box.Controls.Add(this.File_Name_Txt);
            this.Load_File_Box.Controls.Add(this.File_Err);
            this.Load_File_Box.Location = new System.Drawing.Point(167, 12);
            this.Load_File_Box.Name = "Load_File_Box";
            this.Load_File_Box.Size = new System.Drawing.Size(621, 426);
            this.Load_File_Box.TabIndex = 14;
            this.Load_File_Box.TabStop = false;
            this.Load_File_Box.Text = "Load Garage";
            this.Load_File_Box.Visible = false;
            // 
            // Find_File
            // 
            this.Find_File.Location = new System.Drawing.Point(21, 83);
            this.Find_File.Name = "Find_File";
            this.Find_File.Size = new System.Drawing.Size(75, 23);
            this.Find_File.TabIndex = 4;
            this.Find_File.Text = "Find File";
            this.Find_File.UseVisualStyleBackColor = true;
            this.Find_File.Click += new System.EventHandler(this.Find_File_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "File Name:";
            // 
            // File_Name_Txt
            // 
            this.File_Name_Txt.Location = new System.Drawing.Point(88, 45);
            this.File_Name_Txt.Name = "File_Name_Txt";
            this.File_Name_Txt.Size = new System.Drawing.Size(100, 20);
            this.File_Name_Txt.TabIndex = 0;
            // 
            // File_Err
            // 
            this.File_Err.AutoSize = true;
            this.File_Err.ForeColor = System.Drawing.Color.Crimson;
            this.File_Err.Location = new System.Drawing.Point(19, 115);
            this.File_Err.Name = "File_Err";
            this.File_Err.Size = new System.Drawing.Size(109, 13);
            this.File_Err.TabIndex = 3;
            this.File_Err.Text = "File Couldn\'t be found";
            this.File_Err.Visible = false;
            // 
            // Doors_In_Group
            // 
            this.Doors_In_Group.AutoScroll = true;
            this.Doors_In_Group.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Doors_In_Group.Controls.Add(this.Check_Btn);
            this.Doors_In_Group.Controls.Add(this.Incorrect_Info_Label2);
            this.Doors_In_Group.Controls.Add(this.Incorrect_Info_Lab1);
            this.Doors_In_Group.Location = new System.Drawing.Point(339, 19);
            this.Doors_In_Group.Name = "Doors_In_Group";
            this.Doors_In_Group.Size = new System.Drawing.Size(255, 401);
            this.Doors_In_Group.TabIndex = 14;
            this.Doors_In_Group.Tag = "";
            this.Doors_In_Group.Visible = false;
            // 
            // Incorrect_Info_Label2
            // 
            this.Incorrect_Info_Label2.AutoSize = true;
            this.Incorrect_Info_Label2.ForeColor = System.Drawing.Color.Crimson;
            this.Incorrect_Info_Label2.Location = new System.Drawing.Point(23, 64);
            this.Incorrect_Info_Label2.Name = "Incorrect_Info_Label2";
            this.Incorrect_Info_Label2.Size = new System.Drawing.Size(129, 13);
            this.Incorrect_Info_Label2.TabIndex = 15;
            this.Incorrect_Info_Label2.Text = "is not in the correct format";
            this.Incorrect_Info_Label2.Visible = false;
            // 
            // LoadMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.New_Inputs);
            this.Controls.Add(this.Load_File_Box);
            this.Name = "LoadMenu";
            this.Text = "LoadMenu";
            this.groupBox1.ResumeLayout(false);
            this.New_Inputs.ResumeLayout(false);
            this.New_Inputs.PerformLayout();
            this.Load_File_Box.ResumeLayout(false);
            this.Load_File_Box.PerformLayout();
            this.Doors_In_Group.ResumeLayout(false);
            this.Doors_In_Group.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button New_Btn;
        private System.Windows.Forms.GroupBox New_Inputs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _Width;
        private System.Windows.Forms.TextBox _Length;
        private System.Windows.Forms.TextBox Garage_Name;
        private System.Windows.Forms.TextBox Min_Spacing;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Create_Btn;
        private System.Windows.Forms.TextBox No_Doors;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Incorrect_Warn;
        private System.Windows.Forms.Label Incorrect_Info_Lab1;
        private System.Windows.Forms.Button Check_Btn;
        private System.Windows.Forms.Button Load_New_Btn;
        private System.Windows.Forms.Button Load_Btn;
        private System.Windows.Forms.GroupBox Load_File_Box;
        private System.Windows.Forms.Button Find_File;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox File_Name_Txt;
        private System.Windows.Forms.Label File_Err;
        private System.Windows.Forms.Panel Doors_In_Group;
        private System.Windows.Forms.Label Incorrect_Info_Label2;
    }
}