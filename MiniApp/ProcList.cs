using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniApp
{
    public partial class ProcList : Form
    {
        private Form1 frm;
        public ProcList()
        {
            InitializeComponent();
        }

        public ProcList(Form1 frm) 
        {
            InitializeComponent();
            this.frm = frm;
            this.TopMost = frm.TopMost;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            Process[] processes = Process.GetProcesses();

            foreach (var item in processes)
            {
                if (!String.IsNullOrWhiteSpace(item.MainWindowTitle))
                {
                    listBox1.Items.Add(item.MainWindowHandle + " " + item.MainWindowTitle);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(listBox1.SelectedItem != null)
            {
                this.frm.SetPointer((IntPtr)Convert.ToInt32(listBox1.SelectedItem.ToString().Split(' ')[0]));
                this.Close();
            }
        }
    }
}
