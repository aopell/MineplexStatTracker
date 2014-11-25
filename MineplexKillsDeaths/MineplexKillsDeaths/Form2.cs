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
                Properties.Settings.Default.HideWindow = radioButton2.Checked;
                Settings.Default.ForceAction = checkBox2.Checked;
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
            panel1.BackColor = Settings.Default.BackColor;
            panel2.BackColor = Settings.Default.TextColor;
            textBox1.Text = Properties.Settings.Default.Username;
            radioButton2.Checked = Properties.Settings.Default.HideWindow;
            radioButton1.Checked = !radioButton2.Checked;
            checkBox2.Enabled = !radioButton2.Checked;
            comboBox1.SelectedItem = Settings.Default.Theme;
            checkBox2.Checked = Settings.Default.ForceAction;
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
                //NathanWorse
                Settings.Default.Theme = "NathanWorse";
                button2.Enabled = false;
                Settings.Default.BackColor = Color.Yellow;
                Settings.Default.TextColor = Color.Red;
                panel1.BackColor = Settings.Default.BackColor;
                panel2.BackColor = Settings.Default.TextColor;
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                //NathanBetter
                Settings.Default.Theme = "NathanBetter";
                button2.Enabled = false;
                Settings.Default.BackColor = Color.Red;
                Settings.Default.TextColor = Color.Yellow;
                panel1.BackColor = Settings.Default.BackColor;
                panel2.BackColor = Settings.Default.TextColor;
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                Settings.Default.Theme = "Windows3.1";
                button2.Enabled = false;
                Settings.Default.BackColor = Color.Blue;
                Settings.Default.TextColor = Color.White;
                panel1.BackColor = Settings.Default.BackColor;
                panel2.BackColor = Settings.Default.TextColor;
            }
            else if (comboBox1.SelectedIndex == 4)
            {
                Settings.Default.Theme = "SkyBlueText";
                button2.Enabled = false;
                Settings.Default.TextColor = Color.FromArgb(99, 180, 251);
                Settings.Default.BackColor = Color.White;
                panel1.BackColor = Settings.Default.BackColor;
                panel2.BackColor = Settings.Default.TextColor;
            }
            else if(comboBox1.SelectedIndex == 5)
            {
                Settings.Default.Theme = "CommandPrompt";
                button2.Enabled = false;
                Settings.Default.TextColor = Color.White;
                Settings.Default.BackColor = Color.Black;
                panel1.BackColor = Settings.Default.BackColor;
                panel2.BackColor = Settings.Default.TextColor;
            }
            else if(comboBox1.SelectedIndex == comboBox1.Items.Count - 1)
            {
                //Custom
                Settings.Default.Theme = "Custom";
                button2.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Settings.Default.BackColor;
            MessageBox.Show("Pick a background color");
            colorDialog1.ShowDialog();
            Settings.Default.BackColor = colorDialog1.Color;
            colorDialog1.Color = Settings.Default.TextColor;
            MessageBox.Show("Pick a text color");
            colorDialog1.ShowDialog();
            Settings.Default.TextColor = colorDialog1.Color;
            panel1.BackColor = Settings.Default.BackColor;
            panel2.BackColor = Settings.Default.TextColor;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                checkBox2.Enabled = false;
            }
            else
            {
                checkBox2.Enabled = true;
            }
        }

        private void panel1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
        }
    }
}
