using System.Windows.Forms;

namespace Technical_Solution
{
    partial class Main
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
            this.FloorView = new System.Windows.Forms.GroupBox();
            this.Debug = new System.Windows.Forms.Label();
            this.Box_Queue_Group = new System.Windows.Forms.GroupBox();
            this.Add_Box_Group = new System.Windows.Forms.GroupBox();
            this.Err_Lbl = new System.Windows.Forms.Label();
            this.Add_Btn = new System.Windows.Forms.Button();
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
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrganBox = new System.Windows.Forms.GroupBox();
            this.IncBoxQueueCheck = new System.Windows.Forms.CheckBox();
            this.OrgGarageBtn = new System.Windows.Forms.Button();
            this.SearchGroupBox = new System.Windows.Forms.GroupBox();
            this.SearchError = new System.Windows.Forms.Label();
            this.SearchButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.SearchBar = new System.Windows.Forms.TextBox();
            this.FailOrg2 = new System.Windows.Forms.Label();
            this.FailOrg1 = new System.Windows.Forms.Label();
            this.FloorView.SuspendLayout();
            this.Add_Box_Group.SuspendLayout();
            this.MenuStrip.SuspendLayout();
            this.OrganBox.SuspendLayout();
            this.SearchGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FloorView
            // 
            this.FloorView.Controls.Add(this.Debug);
            this.FloorView.Location = new System.Drawing.Point(12, 27);
            this.FloorView.Name = "FloorView";
            this.FloorView.Size = new System.Drawing.Size(1205, 597);
            this.FloorView.TabIndex = 0;
            this.FloorView.TabStop = false;
            this.FloorView.Text = "Floorplan";
            // 
            // Debug
            // 
            this.Debug.AutoSize = true;
            this.Debug.Location = new System.Drawing.Point(5, 559);
            this.Debug.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Debug.Name = "Debug";
            this.Debug.Size = new System.Drawing.Size(35, 13);
            this.Debug.TabIndex = 5;
            this.Debug.Text = "label6";
            // 
            // Box_Queue_Group
            // 
            this.Box_Queue_Group.Location = new System.Drawing.Point(1223, 27);
            this.Box_Queue_Group.Name = "Box_Queue_Group";
            this.Box_Queue_Group.Size = new System.Drawing.Size(245, 597);
            this.Box_Queue_Group.TabIndex = 1;
            this.Box_Queue_Group.TabStop = false;
            this.Box_Queue_Group.Text = "Box Queue";
            // 
            // Add_Box_Group
            // 
            this.Add_Box_Group.Controls.Add(this.Err_Lbl);
            this.Add_Box_Group.Controls.Add(this.Add_Btn);
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
            this.Add_Box_Group.Location = new System.Drawing.Point(12, 630);
            this.Add_Box_Group.Name = "Add_Box_Group";
            this.Add_Box_Group.Size = new System.Drawing.Size(311, 194);
            this.Add_Box_Group.TabIndex = 2;
            this.Add_Box_Group.TabStop = false;
            this.Add_Box_Group.Text = "Add Box To Queue";
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
            // Add_Btn
            // 
            this.Add_Btn.Location = new System.Drawing.Point(219, 165);
            this.Add_Btn.Name = "Add_Btn";
            this.Add_Btn.Size = new System.Drawing.Size(86, 23);
            this.Add_Btn.TabIndex = 12;
            this.Add_Btn.Text = "Add To Queue";
            this.Add_Btn.UseVisualStyleBackColor = true;
            this.Add_Btn.Click += new System.EventHandler(this.Add_Btn_Click);
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
            this.Rand_Col_Btn.Click += new System.EventHandler(this.Rand_Col_Btn_Click);
            // 
            // Colour_Txt
            // 
            this.Colour_Txt.Location = new System.Drawing.Point(96, 123);
            this.Colour_Txt.Name = "Colour_Txt";
            this.Colour_Txt.Size = new System.Drawing.Size(100, 20);
            this.Colour_Txt.TabIndex = 4;
            this.Colour_Txt.TextChanged += new System.EventHandler(this.Colour_Txt_TextChanged);
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
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.MenuStrip.Size = new System.Drawing.Size(1468, 24);
            this.MenuStrip.TabIndex = 3;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // OrganBox
            // 
            this.OrganBox.Controls.Add(this.FailOrg1);
            this.OrganBox.Controls.Add(this.FailOrg2);
            this.OrganBox.Controls.Add(this.IncBoxQueueCheck);
            this.OrganBox.Controls.Add(this.OrgGarageBtn);
            this.OrganBox.Location = new System.Drawing.Point(327, 630);
            this.OrganBox.Margin = new System.Windows.Forms.Padding(2);
            this.OrganBox.Name = "OrganBox";
            this.OrganBox.Padding = new System.Windows.Forms.Padding(2);
            this.OrganBox.Size = new System.Drawing.Size(288, 194);
            this.OrganBox.TabIndex = 4;
            this.OrganBox.TabStop = false;
            this.OrganBox.Text = "Organise Garage";
            // 
            // IncBoxQueueCheck
            // 
            this.IncBoxQueueCheck.AutoSize = true;
            this.IncBoxQueueCheck.Location = new System.Drawing.Point(15, 21);
            this.IncBoxQueueCheck.Margin = new System.Windows.Forms.Padding(2);
            this.IncBoxQueueCheck.Name = "IncBoxQueueCheck";
            this.IncBoxQueueCheck.Size = new System.Drawing.Size(139, 17);
            this.IncBoxQueueCheck.TabIndex = 1;
            this.IncBoxQueueCheck.Text = "Include Boxes in Queue";
            this.IncBoxQueueCheck.UseVisualStyleBackColor = true;
            // 
            // OrgGarageBtn
            // 
            this.OrgGarageBtn.Location = new System.Drawing.Point(4, 165);
            this.OrgGarageBtn.Margin = new System.Windows.Forms.Padding(2);
            this.OrgGarageBtn.Name = "OrgGarageBtn";
            this.OrgGarageBtn.Size = new System.Drawing.Size(101, 23);
            this.OrgGarageBtn.TabIndex = 0;
            this.OrgGarageBtn.Text = "Organise Garage";
            this.OrgGarageBtn.UseVisualStyleBackColor = true;
            this.OrgGarageBtn.Click += new System.EventHandler(this.OrgGarageBtn_Click);
            // 
            // SearchGroupBox
            // 
            this.SearchGroupBox.Controls.Add(this.SearchError);
            this.SearchGroupBox.Controls.Add(this.SearchButton);
            this.SearchGroupBox.Controls.Add(this.label6);
            this.SearchGroupBox.Controls.Add(this.SearchBar);
            this.SearchGroupBox.Location = new System.Drawing.Point(620, 637);
            this.SearchGroupBox.Name = "SearchGroupBox";
            this.SearchGroupBox.Size = new System.Drawing.Size(260, 187);
            this.SearchGroupBox.TabIndex = 5;
            this.SearchGroupBox.TabStop = false;
            this.SearchGroupBox.Text = "Search";
            // 
            // SearchError
            // 
            this.SearchError.AutoSize = true;
            this.SearchError.ForeColor = System.Drawing.Color.Crimson;
            this.SearchError.Location = new System.Drawing.Point(6, 146);
            this.SearchError.Name = "SearchError";
            this.SearchError.Size = new System.Drawing.Size(35, 13);
            this.SearchError.TabIndex = 4;
            this.SearchError.Text = "label7";
            this.SearchError.Visible = false;
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(179, 158);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 3;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Item:";
            // 
            // SearchBar
            // 
            this.SearchBar.Location = new System.Drawing.Point(61, 38);
            this.SearchBar.Name = "SearchBar";
            this.SearchBar.Size = new System.Drawing.Size(193, 20);
            this.SearchBar.TabIndex = 0;
            // 
            // FailOrg2
            // 
            this.FailOrg2.AutoSize = true;
            this.FailOrg2.ForeColor = System.Drawing.Color.Crimson;
            this.FailOrg2.Location = new System.Drawing.Point(12, 97);
            this.FailOrg2.Name = "FailOrg2";
            this.FailOrg2.Size = new System.Drawing.Size(241, 13);
            this.FailOrg2.TabIndex = 2;
            this.FailOrg2.Text = "boxes or moving some things in order to make it fit";
            this.FailOrg2.Visible = false;
            // 
            // FailOrg1
            // 
            this.FailOrg1.AutoSize = true;
            this.FailOrg1.ForeColor = System.Drawing.Color.Crimson;
            this.FailOrg1.Location = new System.Drawing.Point(12, 84);
            this.FailOrg1.Name = "FailOrg1";
            this.FailOrg1.Size = new System.Drawing.Size(232, 13);
            this.FailOrg1.TabIndex = 3;
            this.FailOrg1.Text = "sorry but this is not organisable, try rotating your ";
            this.FailOrg1.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1300, 699);
            this.Controls.Add(this.SearchGroupBox);
            this.Controls.Add(this.OrganBox);
            this.Controls.Add(this.Add_Box_Group);
            this.Controls.Add(this.Box_Queue_Group);
            this.Controls.Add(this.FloorView);
            this.Controls.Add(this.MenuStrip);
            this.Name = "Main";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FloorView.ResumeLayout(false);
            this.FloorView.PerformLayout();
            this.Add_Box_Group.ResumeLayout(false);
            this.Add_Box_Group.PerformLayout();
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.OrganBox.ResumeLayout(false);
            this.OrganBox.PerformLayout();
            this.SearchGroupBox.ResumeLayout(false);
            this.SearchGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox FloorView;
        private System.Windows.Forms.GroupBox Box_Queue_Group;
        private System.Windows.Forms.GroupBox Add_Box_Group;
        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
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
        private System.Windows.Forms.Button Add_Btn;
        private System.Windows.Forms.Label Err_Lbl;
        private GroupBox OrganBox;
        private CheckBox IncBoxQueueCheck;
        private Button OrgGarageBtn;
        private Label Debug;
        private GroupBox SearchGroupBox;
        private TextBox SearchBar;
        private Label label6;
        private Button SearchButton;
        private Label SearchError;
        private Label FailOrg1;
        private Label FailOrg2;
    }
}