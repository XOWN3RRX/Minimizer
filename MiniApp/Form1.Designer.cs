namespace MiniApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.stoppedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findProcessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.topToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshRateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.x9ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transpareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointer0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopCtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stoppedToolStripMenuItem,
            this.findProcessToolStripMenuItem,
            this.topToolStripMenuItem,
            this.refreshRateToolStripMenuItem,
            this.x9ToolStripMenuItem,
            this.transpareToolStripMenuItem,
            this.activateToolStripMenuItem,
            this.stopCtrlSToolStripMenuItem,
            this.pointer0ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 224);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(315, 324);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            this.pictureBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDoubleClick);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            // 
            // stoppedToolStripMenuItem
            // 
            this.stoppedToolStripMenuItem.Image = global::Minimizer.Properties.Resources.start_48;
            this.stoppedToolStripMenuItem.Name = "stoppedToolStripMenuItem";
            this.stoppedToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.stoppedToolStripMenuItem.Text = "Stopped";
            this.stoppedToolStripMenuItem.Click += new System.EventHandler(this.stoppedToolStripMenuItem_Click);
            // 
            // findProcessToolStripMenuItem
            // 
            this.findProcessToolStripMenuItem.Image = global::Minimizer.Properties.Resources.search_2_64;
            this.findProcessToolStripMenuItem.Name = "findProcessToolStripMenuItem";
            this.findProcessToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.findProcessToolStripMenuItem.Text = "Find Process";
            this.findProcessToolStripMenuItem.MouseEnter += new System.EventHandler(this.findProcessToolStripMenuItem_MouseEnter);
            // 
            // topToolStripMenuItem
            // 
            this.topToolStripMenuItem.Image = global::Minimizer.Properties.Resources.pin_64;
            this.topToolStripMenuItem.Name = "topToolStripMenuItem";
            this.topToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.topToolStripMenuItem.Text = "Top";
            this.topToolStripMenuItem.Click += new System.EventHandler(this.topToolStripMenuItem_Click_1);
            // 
            // refreshRateToolStripMenuItem
            // 
            this.refreshRateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6});
            this.refreshRateToolStripMenuItem.Image = global::Minimizer.Properties.Resources.recurring_appointment_64;
            this.refreshRateToolStripMenuItem.Name = "refreshRateToolStripMenuItem";
            this.refreshRateToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.refreshRateToolStripMenuItem.Text = "Refresh rate";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = global::Minimizer.Properties.Resources._1_filled_64;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.ShowShortcutKeys = false;
            this.toolStripMenuItem7.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem7.Text = "25";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::Minimizer.Properties.Resources._2_filled_64;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem2.Text = "33";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::Minimizer.Properties.Resources._3_filled_64;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem3.Text = "50";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::Minimizer.Properties.Resources._4_filled_64;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem4.Text = "100";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::Minimizer.Properties.Resources._5_filled_64;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem5.Text = "250";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = global::Minimizer.Properties.Resources._6_filled_64;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(92, 22);
            this.toolStripMenuItem6.Text = "500";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // x9ToolStripMenuItem
            // 
            this.x9ToolStripMenuItem.Image = global::Minimizer.Properties.Resources.resize_64;
            this.x9ToolStripMenuItem.Name = "x9ToolStripMenuItem";
            this.x9ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.x9ToolStripMenuItem.Text = "16x9";
            this.x9ToolStripMenuItem.Click += new System.EventHandler(this.x9ToolStripMenuItem_Click);
            // 
            // transpareToolStripMenuItem
            // 
            this.transpareToolStripMenuItem.Image = global::Minimizer.Properties.Resources.border_color_64;
            this.transpareToolStripMenuItem.Name = "transpareToolStripMenuItem";
            this.transpareToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.transpareToolStripMenuItem.Text = "Transparent";
            this.transpareToolStripMenuItem.Click += new System.EventHandler(this.transpareToolStripMenuItem_Click);
            // 
            // pointer0ToolStripMenuItem
            // 
            this.pointer0ToolStripMenuItem.Enabled = false;
            this.pointer0ToolStripMenuItem.Image = global::Minimizer.Properties.Resources.hand_cursor_64;
            this.pointer0ToolStripMenuItem.Name = "pointer0ToolStripMenuItem";
            this.pointer0ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.pointer0ToolStripMenuItem.Text = "Pointer : 0";
            // 
            // stopCtrlSToolStripMenuItem
            // 
            this.stopCtrlSToolStripMenuItem.Image = global::Minimizer.Properties.Resources.stop_64;
            this.stopCtrlSToolStripMenuItem.Name = "stopCtrlSToolStripMenuItem";
            this.stopCtrlSToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.stopCtrlSToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.stopCtrlSToolStripMenuItem.Text = "Stop";
            this.stopCtrlSToolStripMenuItem.Click += new System.EventHandler(this.stopCtrlSToolStripMenuItem_Click);
            // 
            // activateToolStripMenuItem
            // 
            this.activateToolStripMenuItem.Image = global::Minimizer.Properties.Resources.eye_2_24;
            this.activateToolStripMenuItem.Name = "activateToolStripMenuItem";
            this.activateToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.activateToolStripMenuItem.Text = "Activate";
            this.activateToolStripMenuItem.Click += new System.EventHandler(this.activateToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Green;
            this.ClientSize = new System.Drawing.Size(315, 324);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Minimizer by Lorin Cucu (v1)";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.LocationChanged += new System.EventHandler(this.Form1_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stoppedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findProcessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem topToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointer0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshRateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem x9ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transpareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopCtrlSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activateToolStripMenuItem;
    }
}

