﻿using System.Windows.Forms;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OrganBox = new System.Windows.Forms.GroupBox();
            this.OrgGarageBtn = new System.Windows.Forms.Button();
            this.IncBoxQueueCheck = new System.Windows.Forms.CheckBox();
            this.Add_Box_Group.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.OrganBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // FloorView
            // 
            this.FloorView.Location = new System.Drawing.Point(18, 42);
            this.FloorView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FloorView.Name = "FloorView";
            this.FloorView.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.FloorView.Size = new System.Drawing.Size(1808, 918);
            this.FloorView.TabIndex = 0;
            this.FloorView.TabStop = false;
            this.FloorView.Text = "Floorplan";
            // 
            // Box_Queue_Group
            // 
            this.Box_Queue_Group.Location = new System.Drawing.Point(1834, 42);
            this.Box_Queue_Group.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Box_Queue_Group.Name = "Box_Queue_Group";
            this.Box_Queue_Group.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Box_Queue_Group.Size = new System.Drawing.Size(368, 918);
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
            this.Add_Box_Group.Location = new System.Drawing.Point(18, 969);
            this.Add_Box_Group.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Add_Box_Group.Name = "Add_Box_Group";
            this.Add_Box_Group.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Add_Box_Group.Size = new System.Drawing.Size(466, 298);
            this.Add_Box_Group.TabIndex = 2;
            this.Add_Box_Group.TabStop = false;
            this.Add_Box_Group.Text = "Add Box To Queue";
            // 
            // Err_Lbl
            // 
            this.Err_Lbl.AutoSize = true;
            this.Err_Lbl.ForeColor = System.Drawing.Color.Crimson;
            this.Err_Lbl.Location = new System.Drawing.Point(9, 254);
            this.Err_Lbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Err_Lbl.Name = "Err_Lbl";
            this.Err_Lbl.Size = new System.Drawing.Size(189, 20);
            this.Err_Lbl.TabIndex = 13;
            this.Err_Lbl.Text = "Some Fields are incorrect";
            this.Err_Lbl.Visible = false;
            // 
            // Add_Btn
            // 
            this.Add_Btn.Location = new System.Drawing.Point(328, 254);
            this.Add_Btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Add_Btn.Name = "Add_Btn";
            this.Add_Btn.Size = new System.Drawing.Size(129, 35);
            this.Add_Btn.TabIndex = 12;
            this.Add_Btn.Text = "Add To Queue";
            this.Add_Btn.UseVisualStyleBackColor = true;
            this.Add_Btn.Click += new System.EventHandler(this.Add_Btn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 195);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "Colour:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 154);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Width:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 114);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Length:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 74);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Weight:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Col_Pan
            // 
            this.Col_Pan.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Col_Pan.Location = new System.Drawing.Point(117, 198);
            this.Col_Pan.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Col_Pan.Name = "Col_Pan";
            this.Col_Pan.Size = new System.Drawing.Size(18, 22);
            this.Col_Pan.TabIndex = 6;
            // 
            // Rand_Col_Btn
            // 
            this.Rand_Col_Btn.Location = new System.Drawing.Point(303, 189);
            this.Rand_Col_Btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Rand_Col_Btn.Name = "Rand_Col_Btn";
            this.Rand_Col_Btn.Size = new System.Drawing.Size(87, 31);
            this.Rand_Col_Btn.TabIndex = 5;
            this.Rand_Col_Btn.Text = "Random";
            this.Rand_Col_Btn.UseVisualStyleBackColor = true;
            this.Rand_Col_Btn.Click += new System.EventHandler(this.Rand_Col_Btn_Click);
            // 
            // Colour_Txt
            // 
            this.Colour_Txt.Location = new System.Drawing.Point(144, 189);
            this.Colour_Txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Colour_Txt.Name = "Colour_Txt";
            this.Colour_Txt.Size = new System.Drawing.Size(148, 26);
            this.Colour_Txt.TabIndex = 4;
            this.Colour_Txt.TextChanged += new System.EventHandler(this.Colour_Txt_TextChanged);
            // 
            // Width_Txt
            // 
            this.Width_Txt.Location = new System.Drawing.Point(144, 149);
            this.Width_Txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Width_Txt.Name = "Width_Txt";
            this.Width_Txt.Size = new System.Drawing.Size(148, 26);
            this.Width_Txt.TabIndex = 3;
            // 
            // Length_Txt
            // 
            this.Length_Txt.Location = new System.Drawing.Point(144, 109);
            this.Length_Txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Length_Txt.Name = "Length_Txt";
            this.Length_Txt.Size = new System.Drawing.Size(148, 26);
            this.Length_Txt.TabIndex = 2;
            // 
            // Weight_Txt
            // 
            this.Weight_Txt.Location = new System.Drawing.Point(144, 69);
            this.Weight_Txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Weight_Txt.Name = "Weight_Txt";
            this.Weight_Txt.Size = new System.Drawing.Size(148, 26);
            this.Weight_Txt.TabIndex = 1;
            // 
            // Name_Txt
            // 
            this.Name_Txt.Location = new System.Drawing.Point(144, 29);
            this.Name_Txt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name_Txt.Name = "Name_Txt";
            this.Name_Txt.Size = new System.Drawing.Size(148, 26);
            this.Name_Txt.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(6, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(2202, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(153, 34);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(153, 34);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // OrganBox
            // 
            this.OrganBox.Controls.Add(this.IncBoxQueueCheck);
            this.OrganBox.Controls.Add(this.OrgGarageBtn);
            this.OrganBox.Location = new System.Drawing.Point(491, 969);
            this.OrganBox.Name = "OrganBox";
            this.OrganBox.Size = new System.Drawing.Size(233, 298);
            this.OrganBox.TabIndex = 4;
            this.OrganBox.TabStop = false;
            this.OrganBox.Text = "Organise Garage";
            // 
            // OrgGarageBtn
            // 
            this.OrgGarageBtn.Location = new System.Drawing.Point(6, 254);
            this.OrgGarageBtn.Name = "OrgGarageBtn";
            this.OrgGarageBtn.Size = new System.Drawing.Size(152, 36);
            this.OrgGarageBtn.TabIndex = 0;
            this.OrgGarageBtn.Text = "Organise Garage";
            this.OrgGarageBtn.UseVisualStyleBackColor = true;
            this.OrgGarageBtn.Click += new System.EventHandler(this.OrgGarageBtn_Click);
            // 
            // IncBoxQueueCheck
            // 
            this.IncBoxQueueCheck.AutoSize = true;
            this.IncBoxQueueCheck.Location = new System.Drawing.Point(23, 33);
            this.IncBoxQueueCheck.Name = "IncBoxQueueCheck";
            this.IncBoxQueueCheck.Size = new System.Drawing.Size(203, 24);
            this.IncBoxQueueCheck.TabIndex = 1;
            this.IncBoxQueueCheck.Text = "Include Boxes in Queue";
            this.IncBoxQueueCheck.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1924, 1050);
            this.Controls.Add(this.OrganBox);
            this.Controls.Add(this.Add_Box_Group);
            this.Controls.Add(this.Box_Queue_Group);
            this.Controls.Add(this.FloorView);
            this.Controls.Add(this.menuStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Text = "Form1";
            this.Add_Box_Group.ResumeLayout(false);
            this.Add_Box_Group.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.OrganBox.ResumeLayout(false);
            this.OrganBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox FloorView;
        private System.Windows.Forms.GroupBox Box_Queue_Group;
        private System.Windows.Forms.GroupBox Add_Box_Group;
        private System.Windows.Forms.MenuStrip menuStrip1;
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
    }
}