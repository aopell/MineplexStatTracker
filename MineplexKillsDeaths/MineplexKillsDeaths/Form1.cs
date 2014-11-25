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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string logPath;
        string logDir;
        int lastCheckedLine = 0;
        int kills = 0;
        int deaths = 0;
        float kdr = 0;
        public static string user;
        public static bool hide = true;

        private void Form1_Load(object sender, EventArgs e)
        {
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
            logDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\.minecraft\\logs";

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
                    if (Settings.Default.HideWindow)
                    {
                        this.WindowState = FormWindowState.Normal;
                        timer1.Enabled = false;
                        timer2.Enabled = true;
                        this.TopMost = true;
                    }
                    else
                    {
                        if (Settings.Default.ForceAction)
                        {
                            notifyIcon2.Visible = true;
                            notifyIcon2.ShowBalloonTip(10000, "Reset or Log?", "Click this message to log statistics.\nStats will be reset if you do not click this message.", ToolTipIcon.Warning);
                        }

                        notifyIcon1.ShowBalloonTip(10000, "Game Stats", String.Format("Game: {0}\nTeam: {1}\nKills: {2}\nDeaths: {3}\nK/D Ratio: {4}", gameLabel.Text, teamLabel.Text, killLabel.Text, deathLabel.Text, kdrLabel.Text), ToolTipIcon.Info);
                    }

                    lastCheckedLine = 0;

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
            if (Settings.Default.HideWindow)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            timer2.Enabled = false;
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
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
            Settings.Default.Save();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (Settings.Default.Theme == "Default")
            {
                this.BackColor = DefaultBackColor;
                label1.ForeColor = Color.Green;
                label2.ForeColor = Color.Red;
                label3.ForeColor = Color.Goldenrod;
                gameLabel.ForeColor = SystemColors.HotTrack;
                teamLabel.ForeColor = Color.DarkOrange;
                killLabel.ForeColor = DefaultForeColor;
                deathLabel.ForeColor = DefaultForeColor;
                kdrLabel.ForeColor = DefaultForeColor;
                rankLabel.ForeColor = Color.DarkViolet;
                killList.BackColor = SystemColors.Window;
                deathList.BackColor = SystemColors.Window;
                killList.ForeColor = DefaultForeColor;
                deathList.ForeColor = DefaultForeColor;
                foreach (Control c in Controls)
                {
                    if (c.GetType() == typeof(Button))
                    {
                        c.ForeColor = SystemColors.WindowText;
                        c.BackColor = DefaultBackColor;
                    }
                }
            }
            else if (Settings.Default.Theme == "NathanWorse")
            {
                this.BackColor = Color.Yellow;
                label1.ForeColor = Color.Red;
                label2.ForeColor = Color.Red;
                label3.ForeColor = Color.Red;
                gameLabel.ForeColor = Color.Red;
                teamLabel.ForeColor = Color.Red;
                killLabel.ForeColor = Color.Red;
                deathLabel.ForeColor = Color.Red;
                kdrLabel.ForeColor = Color.Red;
                rankLabel.ForeColor = Color.Red;
                killList.ForeColor = Color.Red;
                deathList.ForeColor = Color.Red;
                killList.BackColor = Color.Yellow;
                deathList.BackColor = Color.Yellow;
                foreach (Control c in Controls)
                {
                    if (c.GetType() == typeof(Button))
                    {
                        c.ForeColor = Color.Red;
                        c.BackColor = Color.Yellow;
                    }
                }

            }
            else if (Settings.Default.Theme == "NathanBetter")
            {
                this.BackColor = Color.Red;
                label1.ForeColor = Color.Yellow;
                label2.ForeColor = Color.Yellow;
                label3.ForeColor = Color.Yellow;
                gameLabel.ForeColor = Color.Yellow;
                teamLabel.ForeColor = Color.Yellow;
                killLabel.ForeColor = Color.Yellow;
                deathLabel.ForeColor = Color.Yellow;
                kdrLabel.ForeColor = Color.Yellow;
                rankLabel.ForeColor = Color.Yellow;
                killList.ForeColor = Color.Yellow;
                deathList.ForeColor = Color.Yellow;
                killList.BackColor = Color.Red;
                deathList.BackColor = Color.Red;
                foreach (Control c in Controls)
                {
                    if (c.GetType() == typeof(Button))
                    {
                        c.ForeColor = Color.Yellow;
                        c.BackColor = Color.Red;
                    }
                }

            }
            else if (Settings.Default.Theme == "Custom" || Settings.Default.Theme == "Windows3.1" || Settings.Default.Theme == "SkyBlueText" || Settings.Default.Theme == "CommandPrompt")
            {
                this.BackColor = Settings.Default.BackColor;
                label1.ForeColor = Settings.Default.TextColor;
                label2.ForeColor = Settings.Default.TextColor;
                label3.ForeColor = Settings.Default.TextColor;
                gameLabel.ForeColor = Settings.Default.TextColor;
                teamLabel.ForeColor = Settings.Default.TextColor;
                killLabel.ForeColor = Settings.Default.TextColor;
                deathLabel.ForeColor = Settings.Default.TextColor;
                kdrLabel.ForeColor = Settings.Default.TextColor;
                rankLabel.ForeColor = Settings.Default.TextColor;
                killList.ForeColor = Settings.Default.TextColor;
                deathList.ForeColor = Settings.Default.TextColor;
                killList.BackColor = Settings.Default.BackColor;
                deathList.BackColor = Settings.Default.BackColor;
                foreach (Control c in Controls)
                {
                    if (c.GetType() == typeof(Button))
                    {
                        c.ForeColor = Settings.Default.TextColor;
                        c.BackColor = Settings.Default.BackColor;
                    }
                }
            }
        }

        private void Form1_Enter(object sender, EventArgs e)
        {
        }

        private void deathList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (deathList.SelectedIndices.Count > 0)
            {
                deathList.Items.RemoveAt(deathList.SelectedIndex);
                deaths--;
            }
        }

        private void killList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (killList.SelectedIndices.Count > 0)
            {
                killList.Items.RemoveAt(killList.SelectedIndex);
                kills--;
            }
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {

        }

        private void notifyIcon1_BalloonTipClosed(object sender, EventArgs e)
        {

        }

        bool clicked = false;

        private void notifyIcon2_BalloonTipClicked(object sender, EventArgs e)
        {
            clicked = true;
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
            clicked = false;
        }

        private void notifyIcon2_BalloonTipClosed(object sender, EventArgs e)
        {
            if (!clicked)
            {
                notifyIcon1.ShowBalloonTip(5000, "Reset Stats", "Game stats were reset.", ToolTipIcon.Info);
                reset();
            }
        }
    }
}
