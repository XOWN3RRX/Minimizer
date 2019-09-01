using GreenshotPlugin.Core;
using GreenshotPlugin.UnmanagedHelpers;
using Minimizer;
using Minimizer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MiniApp
{
    public partial class Form1 : Form
    {
        private List<ToolStripMenuItem> lst = new List<ToolStripMenuItem>();
        public IntPtr handler;
        private IntPtr _thumbnailHandle = IntPtr.Zero;
        private DWM_THUMBNAIL_PROPERTIES dwm_THUMBNAIL_PROPERTIES;
        private WindowDetails window;
        private WindowDetails oldWindow;

        private const int offsetWidth = 16;
        private const int offsetHeight = 39;
        private const int maxStringText = 30;

        public Form1()
        {
            InitializeComponent();

            this.TransparencyKey = Color.FromArgb(255, 2, 3, 4);
            this.BackColor = Color.FromArgb(255, 2, 3, 4);

            findProcessToolStripMenuItem.DropDownItemClicked += FindProcessToolStripMenuItem_DropDownItemClicked;
            findProcessToolStripMenuItem.DropDownClosed += FindProcessToolStripMenuItem_DropDownClosed;
        }

        private void FindProcessToolStripMenuItem_DropDownClosed(object sender, EventArgs e)
        {
            UnregisterThumbnail();

            if (oldWindow != null)
            {
                window = new WindowDetails(oldWindow.Handle);
                ShowThumbnail();
            }
        }

        private void FindProcessToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (window != null)
            {
                pointer0ToolStripMenuItem.Image = window.DisplayIcon;

                if (window.Text.Length > maxStringText)
                {
                    pointer0ToolStripMenuItem.Text = window.Text.Substring(0, maxStringText);
                }
                else
                {
                    pointer0ToolStripMenuItem.Text = window.Text;
                }

                oldWindow = new WindowDetails(window.Handle);

                UnregisterThumbnail();
                window = oldWindow;
                ShowThumbnail();
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

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Settings.Default.Top)
            {
                this.TopMost = true;
                topToolStripMenuItem.Checked = true;
            }

            this.Width = Settings.Default.Width;
            this.Height = Settings.Default.Height;

            dwm_THUMBNAIL_PROPERTIES = new DWM_THUMBNAIL_PROPERTIES
            {
                Opacity = byte.MaxValue,
                Visible = true,
                SourceClientAreaOnly = false,
            };

            if (Settings.Default.Landscape)
            {
                x9ToolStripMenuItem.Checked = true;
                dwm_THUMBNAIL_PROPERTIES.Destination = GetLandscapeRect();
            }
            else
            {
                dwm_THUMBNAIL_PROPERTIES.Destination = new RECT(0, 0, this.Width - offsetWidth, this.Height - offsetHeight);
            }
        }

        private RECT GetLandscapeRect()
        {
            int width_rect = this.Width - offsetWidth;
            int height_rect = this.Height - offsetHeight;

            int delta1 = width_rect / 16;
            int delta2 = height_rect / 9;

            if (delta1 < delta2)
            {
                height_rect = delta1 * 9;
            }
            else
            {
                width_rect = delta2 * 16;
            }

            int x = ((this.Width - offsetWidth) - width_rect) / 2;
            int y = ((this.Height - offsetHeight) - height_rect) / 2;

            return new RECT(x, y, width_rect + x, height_rect + y);
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            ChangeSizeRECT();

            if (_thumbnailHandle != IntPtr.Zero)
            {
                ShowThumbnail();
            }

            Settings.Default.Width = this.Width;
            Settings.Default.Height = this.Height;
            Settings.Default.Save();
        }

        private void x9ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            item.Checked = !item.Checked;

            Settings.Default.Landscape = item.Checked;
            Settings.Default.Save();

            ChangeSizeRECT();
            ShowThumbnail();
        }

        private void ChangeSizeRECT()
        {
            if (Settings.Default.Landscape)
            {
                dwm_THUMBNAIL_PROPERTIES.Destination = GetLandscapeRect();
            }
            else
            {
                if (this.FormBorderStyle == FormBorderStyle.Sizable)
                {
                    dwm_THUMBNAIL_PROPERTIES.Destination = new RECT(0, 0, this.Width - offsetWidth, this.Height - offsetHeight);
                }
                else
                {
                    dwm_THUMBNAIL_PROPERTIES.Destination = new RECT(0, 0, this.Width, this.Height);
                }
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
            UnregisterThumbnail();
        }

        private void activateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActivateForm();
        }

        private void ActivateForm()
        {
            if (_thumbnailHandle != IntPtr.Zero && window != null)
            {
                window.ToForeground();
            }
        }

        private void findProcessToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            AddCaptureWindowMenuItems(sender as ToolStripMenuItem);
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.Sizable)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                ChangeSizeRECT();
                ShowThumbnail();
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                ChangeSizeRECT();
                ShowThumbnail();
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormMove.ReleaseCapture();
                FormMove.SendMessage(this.Handle, FormMove.WM_NCLBUTTONDOWN, FormMove.HT_CAPTION, 0);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(PointToScreen(e.Location));
            }
            else if (e.Button == MouseButtons.Middle)
            {
                ActivateForm();
            }
        }

        public void AddCaptureWindowMenuItems(ToolStripMenuItem menuItem)
        {
            menuItem.DropDownItems.Clear();
            bool flag = DWM.IsDwmEnabled();
            foreach (WindowDetails windowDetails in WindowDetails.GetTopLevelWindows())
            {
                string text = windowDetails.Text;
                if (text != null)
                {
                    if (text.Length > 50)
                    {
                        text = text.Substring(0, Math.Min(text.Length, 50));
                    }
                    ToolStripItem toolStripItem = menuItem.DropDownItems.Add(text);
                    toolStripItem.Tag = windowDetails;
                    toolStripItem.Image = windowDetails.DisplayIcon;
                    if (flag)
                    {
                        toolStripItem.MouseEnter += ShowThumbnailOnEnter;
                    }
                }
            }
        }

        private void ShowThumbnailOnEnter(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            if (toolStripMenuItem != null)
            {
                window = toolStripMenuItem.Tag as WindowDetails;

                handler = window.Handle;

                ShowThumbnail();
            }
        }

        public void ShowThumbnail()
        {
            this.UnregisterThumbnail();
            DWM.DwmRegisterThumbnail(base.Handle, window.Handle, out this._thumbnailHandle);
            if (this._thumbnailHandle != IntPtr.Zero)
            {
                SIZE size;
                DWM.DwmQueryThumbnailSourceSize(this._thumbnailHandle, out size);

                DWM.DwmUpdateThumbnailProperties(this._thumbnailHandle, ref dwm_THUMBNAIL_PROPERTIES);

                if (!base.Visible)
                {
                    base.Show();
                }

                User32.SetWindowPos(base.Handle, this.Handle, 0, 0, 0, 0, WindowPos.SWP_NOACTIVATE | WindowPos.SWP_NOMOVE | WindowPos.SWP_NOSIZE);
            }
        }

        private void UnregisterThumbnail()
        {
            if (this._thumbnailHandle != IntPtr.Zero)
            {
                DWM.DwmUnregisterThumbnail(this._thumbnailHandle);
                this._thumbnailHandle = IntPtr.Zero;
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UnregisterThumbnail();
            pointer0ToolStripMenuItem.Text = "Undefined";
            pointer0ToolStripMenuItem.Image = Minimizer.Properties.Resources.hand_cursor_64;
            handler = IntPtr.Zero;
        }
    }
}
