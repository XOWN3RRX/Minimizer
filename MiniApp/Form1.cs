using Minimizer;
using Minimizer.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MiniApp
{
    public partial class Form1 : Form
    {
        private List<ToolStripMenuItem> lst = new List<ToolStripMenuItem>();
        public IntPtr handler;
        private List<string> procs = new List<string>();
        int currentTime = DateTime.Now.Second;


        public Form1()
        {
            InitializeComponent();
            this.pictureBox1.BackColor = Color.FromArgb(255, 0, 1, 2);
            SetStyle(ControlStyles.DoubleBuffer, false);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Opaque, true);
            findProcessToolStripMenuItem.DropDownItemClicked += FindProcessToolStripMenuItem_DropDownItemClicked;
            findProcessToolStripMenuItem.DropDown.ItemAdded += DropDown_ItemAdded;
        }

        private void DropDown_ItemAdded(object sender, ToolStripItemEventArgs e)
        {
            e.Item.MouseEnter += Form1_MouseMove;
        }

        private async void Form1_MouseMove(object sender, EventArgs e)
        {
            var r = (sender as ToolStripItem);
            await Wind.PrintWindow(pictureBox1, (IntPtr)Convert.ToInt32(r.Text.Split(' ')[0]));

            if(currentTime + 1 < DateTime.Now.Second)
            {
                GC.Collect();
                currentTime = DateTime.Now.Second;
            }
        }

        private void FindProcessToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            this.handler = (IntPtr)Convert.ToInt32(e.ClickedItem.Text.Split(' ')[0]);
            this.pointer0ToolStripMenuItem.Text = "Pointer : " + this.handler.ToString();
            this.pictureBox1.Image = null;
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            await Wind.PrintWindow(pictureBox1, handler);
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormMove.ReleaseCapture();
                FormMove.SendMessage(this.Handle, FormMove.WM_NCLBUTTONDOWN, FormMove.HT_CAPTION, 0);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(PointToScreen(e.Location));
            }
            else if (e.Button == MouseButtons.Middle)
            {
                if (handler != IntPtr.Zero)
                {
                    FormActivate.ActivateWindow(handler);
                }
            }
        }

        private void topToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!topToolStripMenuItem.Checked)
            {
                topToolStripMenuItem.Checked = true;
                this.TopMost = true;
            }
            else
            {
                topToolStripMenuItem.Checked = false;
                this.TopMost = false;
            }

            Settings.Default.Top = topToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        public void SetPointer(IntPtr pointer)
        {
            this.handler = pointer;
            this.pointer0ToolStripMenuItem.Text = "Pointer : " + this.handler.ToString();
        }

        private void stoppedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.handler == IntPtr.Zero)
            {
                MessageBox.Show("Null pointer reference! Please select one application to minimizer.");
            }
            else
            {
                if (stoppedToolStripMenuItem.Text == "Stopped")
                {
                    stoppedToolStripMenuItem.Text = "Running";
                    stoppedToolStripMenuItem.Checked = true;
                    this.timer1.Start();
                }
                else
                {
                    Stop();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lst.AddRange(new ToolStripMenuItem[] { toolStripMenuItem2, toolStripMenuItem3, toolStripMenuItem4, toolStripMenuItem5, toolStripMenuItem6, toolStripMenuItem7 });

            for (int i = 0; i < lst.Count; i++)
            {
                if (lst[i].Text == Settings.Default.Refresh)
                {
                    lst[i].Checked = true;
                    timer1.Interval = Convert.ToInt32(Settings.Default.Refresh);
                }
            }

            if (Settings.Default.Top)
            {
                this.TopMost = true;
                topToolStripMenuItem.Checked = true;
            }

            this.Width = Settings.Default.Width;
            this.Height = Settings.Default.Height;

            this.Location = new Point(Settings.Default.X, Settings.Default.Y);

            if (Settings.Default.Landscape)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                x9ToolStripMenuItem.Checked = true;
            }

            if (Settings.Default.Transparent)
            {
                TransparentColor(false);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem tool = (sender as ToolStripMenuItem);
            string currentRefresh = tool.Text;

            for (int i = 0; i < lst.Count; i++)
            {
                lst[i].Checked = false;
                if (lst[i].Text == currentRefresh)
                {
                    lst[i].Checked = true;
                    Settings.Default.Refresh = currentRefresh;
                    Settings.Default.Save();
                    timer1.Interval = Convert.ToInt32(currentRefresh);
                }
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            Settings.Default.Width = this.Width;
            Settings.Default.Height = this.Height;
            Settings.Default.Save();
        }

        private void x9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.pictureBox1.SizeMode == PictureBoxSizeMode.StretchImage)
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                x9ToolStripMenuItem.Checked = true;
            }
            else
            {
                this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                x9ToolStripMenuItem.Checked = false;
            }

            Settings.Default.Landscape = x9ToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void transpareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransparentColor(transpareToolStripMenuItem.Checked);
            Settings.Default.Transparent = transpareToolStripMenuItem.Checked;
            Settings.Default.Save();
        }

        private void TransparentColor(bool enabled)
        {
            if (enabled)
            {
                transpareToolStripMenuItem.Checked = false;
                this.BackColor = Color.Green;
                this.TransparencyKey = Color.Black;
                this.Invalidate();
            }
            else
            {
                transpareToolStripMenuItem.Checked = true;
                this.TransparencyKey = Color.FromArgb(255, 0, 1, 2);
                this.BackColor = Color.FromArgb(255, 0, 1, 2);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
            {
                Stop();
            }
        }

        private void Stop()
        {
            stoppedToolStripMenuItem.Text = "Stopped";
            this.timer1.Stop();
            stoppedToolStripMenuItem.Checked = false;
            this.pictureBox1.Image = null;
            transpareToolStripMenuItem.Checked = false;
            this.BackColor = Color.Green;
            this.TransparencyKey = Color.Black;
            this.Invalidate();
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            Settings.Default.X = this.Location.X;
            Settings.Default.Y = this.Location.Y;
            Settings.Default.Save();
        }

        private void stopCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (handler != IntPtr.Zero)
            {
                FormActivate.ActivateWindow(handler);
            }
        }

        private void findProcessToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            findProcessToolStripMenuItem.DropDownItems.Clear();

            Process[] processes = Process.GetProcesses();

            procs.Clear();

            foreach (var item in processes)
            {
                if (!String.IsNullOrWhiteSpace(item.MainWindowTitle))
                {
                    procs.Add(item.MainWindowHandle + " " + item.MainWindowTitle);

                }
            }

            procs.Sort();

            foreach (var item in procs)
            {
                findProcessToolStripMenuItem.DropDownItems.Add(item);
            }
        }
    }
}
