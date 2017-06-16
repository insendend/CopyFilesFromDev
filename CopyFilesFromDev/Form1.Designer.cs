namespace CopyFilesFromDev
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
            this.l_timecaption = new System.Windows.Forms.Label();
            this.l_time = new System.Windows.Forms.Label();
            this.lb_copiedfiles = new System.Windows.Forms.ListBox();
            this.l_count = new System.Windows.Forms.Label();
            this.lb_foundfiles = new System.Windows.Forms.ListBox();
            this.l_attachinfo = new System.Windows.Forms.Label();
            this.but_copy = new System.Windows.Forms.Button();
            this.l_helpinfo = new System.Windows.Forms.Label();
            this.l_timerinfo1 = new System.Windows.Forms.Label();
            this.l_timerinfo2 = new System.Windows.Forms.Label();
            this.timer_timeleft = new System.Windows.Forms.Timer(this.components);
            this.timer_timework = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // l_timecaption
            // 
            this.l_timecaption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.l_timecaption.AutoSize = true;
            this.l_timecaption.Location = new System.Drawing.Point(533, 389);
            this.l_timecaption.Name = "l_timecaption";
            this.l_timecaption.Size = new System.Drawing.Size(67, 13);
            this.l_timecaption.TabIndex = 0;
            this.l_timecaption.Text = "time_caption";
            this.l_timecaption.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // l_time
            // 
            this.l_time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.l_time.AutoSize = true;
            this.l_time.Location = new System.Drawing.Point(677, 389);
            this.l_time.Name = "l_time";
            this.l_time.Size = new System.Drawing.Size(26, 13);
            this.l_time.TabIndex = 1;
            this.l_time.Text = "time";
            this.l_time.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // lb_copiedfiles
            // 
            this.lb_copiedfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_copiedfiles.FormattingEnabled = true;
            this.lb_copiedfiles.Location = new System.Drawing.Point(476, 57);
            this.lb_copiedfiles.Name = "lb_copiedfiles";
            this.lb_copiedfiles.Size = new System.Drawing.Size(236, 316);
            this.lb_copiedfiles.TabIndex = 2;
            this.lb_copiedfiles.Visible = false;
            this.lb_copiedfiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // l_count
            // 
            this.l_count.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.l_count.AutoSize = true;
            this.l_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_count.Location = new System.Drawing.Point(473, 39);
            this.l_count.Name = "l_count";
            this.l_count.Size = new System.Drawing.Size(66, 15);
            this.l_count.TabIndex = 3;
            this.l_count.Text = "count_files";
            this.l_count.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // lb_foundfiles
            // 
            this.lb_foundfiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lb_foundfiles.FormattingEnabled = true;
            this.lb_foundfiles.HorizontalScrollbar = true;
            this.lb_foundfiles.Location = new System.Drawing.Point(12, 57);
            this.lb_foundfiles.Name = "lb_foundfiles";
            this.lb_foundfiles.Size = new System.Drawing.Size(164, 238);
            this.lb_foundfiles.TabIndex = 4;
            this.lb_foundfiles.Visible = false;
            this.lb_foundfiles.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // l_attachinfo
            // 
            this.l_attachinfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_attachinfo.Location = new System.Drawing.Point(12, 9);
            this.l_attachinfo.Name = "l_attachinfo";
            this.l_attachinfo.Size = new System.Drawing.Size(254, 32);
            this.l_attachinfo.TabIndex = 5;
            this.l_attachinfo.Text = "attach_msg";
            this.l_attachinfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // but_copy
            // 
            this.but_copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.but_copy.Location = new System.Drawing.Point(12, 357);
            this.but_copy.Name = "but_copy";
            this.but_copy.Size = new System.Drawing.Size(164, 42);
            this.but_copy.TabIndex = 6;
            this.but_copy.Text = "copy";
            this.but_copy.UseVisualStyleBackColor = true;
            this.but_copy.Visible = false;
            this.but_copy.Click += new System.EventHandler(this.button1_Click);
            this.but_copy.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // l_helpinfo
            // 
            this.l_helpinfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.l_helpinfo.Location = new System.Drawing.Point(12, 309);
            this.l_helpinfo.Name = "l_helpinfo";
            this.l_helpinfo.Size = new System.Drawing.Size(191, 45);
            this.l_helpinfo.TabIndex = 7;
            this.l_helpinfo.Text = "helpinfo";
            this.l_helpinfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // l_timerinfo1
            // 
            this.l_timerinfo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.l_timerinfo1.Location = new System.Drawing.Point(199, 57);
            this.l_timerinfo1.Name = "l_timerinfo1";
            this.l_timerinfo1.Size = new System.Drawing.Size(236, 46);
            this.l_timerinfo1.TabIndex = 8;
            this.l_timerinfo1.Text = "info_msg";
            this.l_timerinfo1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // l_timerinfo2
            // 
            this.l_timerinfo2.AutoSize = true;
            this.l_timerinfo2.Location = new System.Drawing.Point(199, 103);
            this.l_timerinfo2.Name = "l_timerinfo2";
            this.l_timerinfo2.Size = new System.Drawing.Size(40, 13);
            this.l_timerinfo2.TabIndex = 9;
            this.l_timerinfo2.Text = "timeleft";
            this.l_timerinfo2.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            // 
            // timer_timeleft
            // 
            this.timer_timeleft.Interval = 1000;
            this.timer_timeleft.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer_timework
            // 
            this.timer_timework.Enabled = true;
            this.timer_timework.Interval = 1000;
            this.timer_timework.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 411);
            this.Controls.Add(this.l_timerinfo2);
            this.Controls.Add(this.l_timerinfo1);
            this.Controls.Add(this.l_helpinfo);
            this.Controls.Add(this.but_copy);
            this.Controls.Add(this.l_attachinfo);
            this.Controls.Add(this.lb_foundfiles);
            this.Controls.Add(this.l_count);
            this.Controls.Add(this.lb_copiedfiles);
            this.Controls.Add(this.l_time);
            this.Controls.Add(this.l_timecaption);
            this.MinimumSize = new System.Drawing.Size(650, 420);
            this.Name = "Form1";
            this.Text = "Copy Files From Device";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label l_timecaption;
        private System.Windows.Forms.Label l_time;
        private System.Windows.Forms.ListBox lb_copiedfiles;
        private System.Windows.Forms.Label l_count;
        private System.Windows.Forms.ListBox lb_foundfiles;
        private System.Windows.Forms.Label l_attachinfo;
        private System.Windows.Forms.Button but_copy;
        private System.Windows.Forms.Label l_helpinfo;
        private System.Windows.Forms.Label l_timerinfo1;
        private System.Windows.Forms.Label l_timerinfo2;
        private System.Windows.Forms.Timer timer_timeleft;
        private System.Windows.Forms.Timer timer_timework;
    }
}

