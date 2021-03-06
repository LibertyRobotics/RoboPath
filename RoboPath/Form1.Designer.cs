﻿namespace RoboPath
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openPathToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.waypointSaveDirectory = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.addSubsytem = new System.Windows.Forms.Button();
            this.waypointOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.runSubsystemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runnableSubsytemsList = new System.Windows.Forms.ListBox();
            this.lb_listBox = new System.Windows.Forms.Label();
            this.btn_RemoveSubsystem = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.waypointOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1187, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newPathToolStripMenuItem,
            this.savePathToolStripMenuItem,
            this.openPathToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newPathToolStripMenuItem
            // 
            this.newPathToolStripMenuItem.Name = "newPathToolStripMenuItem";
            this.newPathToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newPathToolStripMenuItem.Text = "New Path";
            this.newPathToolStripMenuItem.Click += new System.EventHandler(this.NewPathToolStripMenuItem_Click);
            // 
            // savePathToolStripMenuItem
            // 
            this.savePathToolStripMenuItem.Name = "savePathToolStripMenuItem";
            this.savePathToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.savePathToolStripMenuItem.Text = "Save Path";
            this.savePathToolStripMenuItem.Click += new System.EventHandler(this.SavePathToolStripMenuItem_Click);
            // 
            // openPathToolStripMenuItem
            // 
            this.openPathToolStripMenuItem.Name = "openPathToolStripMenuItem";
            this.openPathToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.openPathToolStripMenuItem.Text = "Open Path";
            this.openPathToolStripMenuItem.Click += new System.EventHandler(this.OpenPathToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(12, 877);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 82);
            this.button1.TabIndex = 2;
            this.button1.Text = "Add Waypoints";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(221, 877);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(203, 82);
            this.button2.TabIndex = 3;
            this.button2.Text = "Remove Waypoints";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(430, 907);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 22);
            this.label1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // addSubsytem
            // 
            this.addSubsytem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSubsytem.Location = new System.Drawing.Point(1033, 877);
            this.addSubsytem.Name = "addSubsytem";
            this.addSubsytem.Size = new System.Drawing.Size(142, 80);
            this.addSubsytem.TabIndex = 5;
            this.addSubsytem.Text = "Add Subsytem";
            this.addSubsytem.UseVisualStyleBackColor = true;
            this.addSubsytem.Click += new System.EventHandler(this.TestAddSubystem_Click);
            // 
            // waypointOptions
            // 
            this.waypointOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runSubsystemToolStripMenuItem});
            this.waypointOptions.Name = "waypointOptions";
            this.waypointOptions.Size = new System.Drawing.Size(156, 26);
            // 
            // runSubsystemToolStripMenuItem
            // 
            this.runSubsystemToolStripMenuItem.Name = "runSubsystemToolStripMenuItem";
            this.runSubsystemToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.runSubsystemToolStripMenuItem.Text = "Run Subsystem";
            this.runSubsystemToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.RunSubsystemToolStripMenuItem_DropDownItemClicked);
            // 
            // runnableSubsytemsList
            // 
            this.runnableSubsytemsList.FormattingEnabled = true;
            this.runnableSubsytemsList.Location = new System.Drawing.Point(858, 56);
            this.runnableSubsytemsList.Name = "runnableSubsytemsList";
            this.runnableSubsytemsList.Size = new System.Drawing.Size(317, 810);
            this.runnableSubsytemsList.TabIndex = 7;
            // 
            // lb_listBox
            // 
            this.lb_listBox.AutoSize = true;
            this.lb_listBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_listBox.Location = new System.Drawing.Point(854, 33);
            this.lb_listBox.Name = "lb_listBox";
            this.lb_listBox.Size = new System.Drawing.Size(171, 19);
            this.lb_listBox.TabIndex = 8;
            this.lb_listBox.Text = "Runnable Subsytems";
            // 
            // btn_RemoveSubsystem
            // 
            this.btn_RemoveSubsystem.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RemoveSubsystem.Location = new System.Drawing.Point(858, 879);
            this.btn_RemoveSubsystem.Name = "btn_RemoveSubsystem";
            this.btn_RemoveSubsystem.Size = new System.Drawing.Size(142, 80);
            this.btn_RemoveSubsystem.TabIndex = 9;
            this.btn_RemoveSubsystem.Text = "Remove Subsytem";
            this.btn_RemoveSubsystem.UseVisualStyleBackColor = true;
            this.btn_RemoveSubsystem.Click += new System.EventHandler(this.Btn_RemoveSubsystem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = ".\\Resources\\FTC SKYSTONE 2019-2020.png";
            this.pictureBox1.Location = new System.Drawing.Point(12, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(840, 842);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBox1_Paint);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 971);
            this.Controls.Add(this.btn_RemoveSubsystem);
            this.Controls.Add(this.lb_listBox);
            this.Controls.Add(this.runnableSubsytemsList);
            this.Controls.Add(this.addSubsytem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "RoboPath";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.waypointOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openPathToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog waypointSaveDirectory;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button addSubsytem;
        private System.Windows.Forms.ContextMenuStrip waypointOptions;
        public System.Windows.Forms.ToolStripMenuItem runSubsystemToolStripMenuItem;
        private System.Windows.Forms.Label lb_listBox;
        public System.Windows.Forms.ListBox runnableSubsytemsList;
        private System.Windows.Forms.Button btn_RemoveSubsystem;
    }
}

