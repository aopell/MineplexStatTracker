namespace MineplexStatTracker
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
            this.killList = new System.Windows.Forms.ListBox();
            this.deathList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.killLabel = new System.Windows.Forms.Label();
            this.kdrLabel = new System.Windows.Forms.Label();
            this.deathLabel = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gameLabel = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.rankLabel = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.teamLabel = new System.Windows.Forms.Label();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // killList
            // 
            this.killList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.killList.FormattingEnabled = true;
            this.killList.Location = new System.Drawing.Point(12, 231);
            this.killList.Name = "killList";
            this.killList.Size = new System.Drawing.Size(462, 342);
            this.killList.TabIndex = 0;
            // 
            // deathList
            // 
            this.deathList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deathList.FormattingEnabled = true;
            this.deathList.Location = new System.Drawing.Point(480, 231);
            this.deathList.Name = "deathList";
            this.deathList.Size = new System.Drawing.Size(467, 342);
            this.deathList.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Minecraft", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(199, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 33);
            this.label1.TabIndex = 2;
            this.label1.Text = "Kills";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Minecraft", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(667, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 33);
            this.label2.TabIndex = 3;
            this.label2.Text = "Deaths";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Minecraft", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Goldenrod;
            this.label3.Location = new System.Drawing.Point(5, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(953, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "Kill/Death Ratio";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Minecraft", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(154, 579);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(212, 41);
            this.button1.TabIndex = 5;
            this.button1.Text = "Reset Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // killLabel
            // 
            this.killLabel.Font = new System.Drawing.Font("Minecraft", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.killLabel.Location = new System.Drawing.Point(151, 129);
            this.killLabel.Name = "killLabel";
            this.killLabel.Size = new System.Drawing.Size(180, 47);
            this.killLabel.TabIndex = 6;
            this.killLabel.Text = "0";
            this.killLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // kdrLabel
            // 
            this.kdrLabel.Font = new System.Drawing.Font("Minecraft", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kdrLabel.Location = new System.Drawing.Point(386, 129);
            this.kdrLabel.Name = "kdrLabel";
            this.kdrLabel.Size = new System.Drawing.Size(180, 47);
            this.kdrLabel.TabIndex = 7;
            this.kdrLabel.Text = "DIV/0!";
            this.kdrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // deathLabel
            // 
            this.deathLabel.Font = new System.Drawing.Font("Minecraft", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deathLabel.Location = new System.Drawing.Point(644, 129);
            this.deathLabel.Name = "deathLabel";
            this.deathLabel.Size = new System.Drawing.Size(180, 47);
            this.deathLabel.TabIndex = 8;
            this.deathLabel.Text = "0";
            this.deathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // gameLabel
            // 
            this.gameLabel.Font = new System.Drawing.Font("Minecraft", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.gameLabel.Location = new System.Drawing.Point(12, 1);
            this.gameLabel.Name = "gameLabel";
            this.gameLabel.Size = new System.Drawing.Size(935, 44);
            this.gameLabel.TabIndex = 9;
            this.gameLabel.Text = "UnknownGame";
            this.gameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Minecraft", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(590, 579);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(212, 41);
            this.button2.TabIndex = 10;
            this.button2.Text = "Log Data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rankLabel
            // 
            this.rankLabel.Font = new System.Drawing.Font("Minecraft", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rankLabel.ForeColor = System.Drawing.Color.DarkViolet;
            this.rankLabel.Location = new System.Drawing.Point(12, 181);
            this.rankLabel.Name = "rankLabel";
            this.rankLabel.Size = new System.Drawing.Size(935, 34);
            this.rankLabel.TabIndex = 11;
            this.rankLabel.Text = "Result: Unknown";
            this.rankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Minecraft", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(372, 579);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(212, 41);
            this.button3.TabIndex = 12;
            this.button3.Text = "Settings";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // teamLabel
            // 
            this.teamLabel.Font = new System.Drawing.Font("Minecraft", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.teamLabel.ForeColor = System.Drawing.Color.DarkOrange;
            this.teamLabel.Location = new System.Drawing.Point(12, 42);
            this.teamLabel.Name = "teamLabel";
            this.teamLabel.Size = new System.Drawing.Size(935, 33);
            this.teamLabel.TabIndex = 13;
            this.teamLabel.Text = "UnknownTeam";
            this.teamLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer2
            // 
            this.timer2.Interval = 7500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Minecraft", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(831, 9);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(116, 30);
            this.button4.TabIndex = 14;
            this.button4.Text = "Hide Window";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(959, 632);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.teamLabel);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.rankLabel);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gameLabel);
            this.Controls.Add(this.deathLabel);
            this.Controls.Add(this.kdrLabel);
            this.Controls.Add(this.killLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deathList);
            this.Controls.Add(this.killList);
            this.Controls.Add(this.label3);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Mineplex Kills/Deaths Counter";
            this.HelpButtonClicked += new System.ComponentModel.CancelEventHandler(this.Form1_HelpButtonClicked);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox killList;
        private System.Windows.Forms.ListBox deathList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label killLabel;
        private System.Windows.Forms.Label kdrLabel;
        private System.Windows.Forms.Label deathLabel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label gameLabel;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label rankLabel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label teamLabel;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Button button4;
    }
}

