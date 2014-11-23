using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MineplexStatTracker
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Properties.Settings.Default.Username = textBox1.Text;
                Properties.Settings.Default.HideWindow = checkBox1.Checked;
                Properties.Settings.Default.Save();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter a username!");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.Username;
            checkBox1.Checked = Properties.Settings.Default.HideWindow;
        }
    }
}
