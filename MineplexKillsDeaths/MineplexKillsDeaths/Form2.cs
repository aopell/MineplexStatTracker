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
using MineplexStatTracker.Properties;

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
            comboBox1.SelectedItem = Settings.Default.Theme;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                //Default
                Settings.Default.Theme = "Default";
                button2.Enabled = false;
                panel1.BackColor = DefaultBackColor;
                panel2.BackColor = DefaultForeColor;
            }
            else if(comboBox1.SelectedIndex == 1)
            {
                //Nathan
                Settings.Default.Theme = "Nathan";
                button2.Enabled = false;
                Settings.Default.BackColor = Color.Yellow;
                Settings.Default.TextColor = Color.Red;
                panel1.BackColor = Settings.Default.BackColor;
                panel2.BackColor = Settings.Default.TextColor;
            }
            else if(comboBox1.SelectedIndex == 2)
            {
                //Custom
                Settings.Default.Theme = "Custom";
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Pick a background color");
            colorDialog1.ShowDialog();
            Settings.Default.BackColor = colorDialog1.Color;
            MessageBox.Show("Pick a text color");
            colorDialog1.ShowDialog();
            Settings.Default.TextColor = colorDialog1.Color;
            panel1.BackColor = Settings.Default.BackColor;
            panel2.BackColor = Settings.Default.TextColor;
        }
    }
}
