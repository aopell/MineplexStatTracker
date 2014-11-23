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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string logPath;
        int lastCheckedLine = 0;
        int kills = 0;
        int deaths = 0;
        float kdr = 0;
        public static string user;
        public static bool hide = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();

            this.Text = Application.ProductName + " " + Application.ProductVersion;

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Mineplex Stats") || Properties.Settings.Default.Username == "")
            {
                Directory.CreateDirectory((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Mineplex Stats"));
                Form2 f2 = new Form2();
                f2.ShowDialog();
            }

            user = Properties.Settings.Default.Username;
            hide = Properties.Settings.Default.HideWindow;

            logPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\logs\\latest.log";

            stream = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            reader = new StreamReader(stream);
            
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                lastCheckedLine++;
            }

            timer1.Enabled = true;
        }

        FileStream stream;
        StreamReader reader;

        private void timer1_Tick(object sender, EventArgs e)
        {
            stream = new FileStream(logPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            reader = new StreamReader(stream);

            List<string> fileState = new List<string>();

            while (!reader.EndOfStream)
            {
                string s = reader.ReadLine();
                fileState.Add(s);
            }

            for (int i = lastCheckedLine + 1; i < fileState.Count() - 1; i++)
            {
                string s = fileState[i];

                if (s.ToLower().Contains("killed by " + user.ToLower()) || s.ToLower().Contains("you killed") || s.ToLower().Contains("was painted by " + user.ToLower()))
                {
                    kills++;
                    killList.Items.Add(s.Substring(s.IndexOf("[CHAT]") + 7));
                    killLabel.Text = kills.ToString();
                }
                else if (s.ToLower().Contains(user.ToLower() + " killed by") || s.ToLower().Contains("killed you with") || s.ToLower().Contains("you were killed") || s.ToLower().Contains(user.ToLower() + " was painted"))
                {
                    deaths++;
                    deathList.Items.Add(s.Substring(s.IndexOf("[CHAT]") + 7));
                    deathLabel.Text = deaths.ToString();
                }
                else if (s.ToLower().Contains("game -"))
                {
                    gameLabel.Text = fileState[i].Substring(s.IndexOf("Game -") + 7);
                }
                else if (s.ToLower().Contains("search for: r"))
                {
                    reset();
                }
                else if (s.ToLower().Contains("search for: l"))
                {
                    string filename = DateTime.Now.ToString("MM-dd-yy-hh-mm-ss") + "-" + gameLabel.Text + ".log";
                    List<string> toWrite = new List<string>();
                    toWrite.Add(DateTime.Now.ToString("MM/dd/yy hh:mm:ss"));
                    toWrite.Add("");
                    toWrite.Add("Game: " + gameLabel.Text);
                    toWrite.Add("");
                    toWrite.Add("Kills: " + kills);
                    toWrite.Add("Deaths: " + deaths);
                    toWrite.Add("Kill/Death Ratio: " + kdr);
                    toWrite.Add("");
                    toWrite.Add("Kill Log:");
                    toWrite.Add("");
                    foreach (string kill in killList.Items)
                    {
                        toWrite.Add(kill);
                    }
                    toWrite.Add("");
                    toWrite.Add("Death Log:");
                    toWrite.Add("");
                    foreach (string death in deathList.Items)
                    {
                        toWrite.Add(death);
                    }
                    if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Mineplex Stats"))
                    {
                        Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Mineplex Stats");
                    }

                    File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Mineplex Stats\\" + filename, toWrite);
                    notifyIcon1.ShowBalloonTip(5000, "Saved Log File", "Saved in My Documents > Mineplex Stats > " + filename, ToolTipIcon.Info);
                    reset();
                }
                else if (s.ToLower().Contains("1st place -"))
                {
                    if (s.Contains(user.ToLower()))
                    {
                        rankLabel.Text = "Result: 1st Place";
                    }
                }
                else if (s.ToLower().Contains("2nd place -"))
                {
                    if (s.Contains(user.ToLower()))
                    {
                        rankLabel.Text = "Result: 2nd Place";
                    }
                }
                else if (s.ToLower().Contains("3rd place -"))
                {
                    if (s.Contains(user.ToLower()))
                    {
                        rankLabel.Text = "Result: 3rd Place";
                    }
                }
                else if (s.ToLower().Contains("team> you joined") && !s.ToLower().Contains("chasers"))
                {
                    this.WindowState = FormWindowState.Normal;
                    timer1.Enabled = false;
                    timer2.Enabled = true;
                    this.TopMost = true;

                    teamLabel.Text = s.Substring(s.IndexOf("joined") + 7);
                }

                lastCheckedLine++;

            }

            if (deaths > 0)
            {
                kdr = (float)Decimal.Divide(kills, deaths);
                kdrLabel.Text = kdr.ToString();
            }
            else
            {
                kdrLabel.Text = "DIV/0!";
            }

            reader.Close();
            stream.Close();

        }

        public void reset()
        {
            kills = 0;
            deaths = 0;
            kdr = 1;
            killLabel.Text = "0";
            deathLabel.Text = "0";
            kdrLabel.Text = "DIV/0!";
            killList.Items.Clear();
            deathList.Items.Clear();
            rankLabel.Text = "Rank: Unknown";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string filename = DateTime.Now.ToString("MM-dd-yy-hh-mm-ss") + "-" + gameLabel.Text + ".log";
            List<string> toWrite = new List<string>();
            toWrite.Add(DateTime.Now.ToString("MM/dd/yy hh:mm:ss"));
            toWrite.Add("");
            toWrite.Add("Game: " + gameLabel.Text);
            toWrite.Add("Team: " + teamLabel.Text);
            toWrite.Add("");
            toWrite.Add("Kills: " + kills);
            toWrite.Add("Deaths: " + deaths);
            toWrite.Add("Kill/Death Ratio: " + kdr);
            toWrite.Add(rankLabel.Text);
            toWrite.Add("");
            toWrite.Add("Kill Log:");
            toWrite.Add("");
            foreach (string kill in killList.Items)
            {
                toWrite.Add(kill);
            }
            toWrite.Add("");
            toWrite.Add("Death Log:");
            toWrite.Add("");
            foreach (string death in deathList.Items)
            {
                toWrite.Add(death);
            }
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Mineplex Stats"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Mineplex Stats");
            }

            File.WriteAllLines(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Mineplex Stats\\" + filename, toWrite);
            notifyIcon1.ShowBalloonTip(5000, "Saved Log File", "Saved in My Documents > Mineplex Stats > " + filename, ToolTipIcon.Info);
            reset();
        } 

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            this.TopMost = false;
            if(hide)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            timer2.Enabled = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.Focus();
            this.TopMost = true;
        }

        private void Form1_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            AboutBox1 a = new AboutBox1();
            a.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
