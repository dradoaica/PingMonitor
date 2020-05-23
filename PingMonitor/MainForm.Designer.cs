namespace PingMonitor.UI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnMinimize = new System.Windows.Forms.Button();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.rightClickMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showHideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtServerAdress = new System.Windows.Forms.TextBox();
            this.txtPingInterval = new System.Windows.Forms.TextBox();
            this.lbServerAdress = new System.Windows.Forms.Label();
            this.lbPingInterval = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtNumberOfPingsToMonitor = new System.Windows.Forms.TextBox();
            this.txtNumberOfPingIssues = new System.Windows.Forms.TextBox();
            this.txtMaxRoundtripTime = new System.Windows.Forms.TextBox();
            this.lbNumberOfPingsToMonitor = new System.Windows.Forms.Label();
            this.lbMaxRoundtripTime = new System.Windows.Forms.Label();
            this.lbNumberOfPingIssues = new System.Windows.Forms.Label();
            this.cbStartMonitoring = new System.Windows.Forms.CheckBox();
            this.rightClickMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMinimize
            // 
            this.btnMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimize.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnMinimize.Image = ((System.Drawing.Image)(resources.GetObject("btnMinimize.Image")));
            this.btnMinimize.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMinimize.Location = new System.Drawing.Point(260, 186);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(75, 27);
            this.btnMinimize.TabIndex = 12;
            this.btnMinimize.Text = "&Minimize";
            this.btnMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnMinimize.UseVisualStyleBackColor = true;
            this.btnMinimize.Click += new System.EventHandler(this.OnShowHide);
            // 
            // trayIcon
            // 
            this.trayIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.trayIcon.ContextMenuStrip = this.rightClickMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "PingMonitor";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseDoubleClick);
            // 
            // rightClickMenu
            // 
            this.rightClickMenu.BackColor = System.Drawing.SystemColors.Menu;
            this.rightClickMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.rightClickMenu.Name = "rightClickMenu";
            this.rightClickMenu.ShowImageMargin = false;
            this.rightClickMenu.Size = new System.Drawing.Size(111, 48);
            // 
            // showHideToolStripMenuItem
            // 
            this.showHideToolStripMenuItem.Name = "showHideToolStripMenuItem";
            this.showHideToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.showHideToolStripMenuItem.Text = "Show/Hide";
            this.showHideToolStripMenuItem.Click += new System.EventHandler(this.OpenHideToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // txtServerAdress
            // 
            this.txtServerAdress.Location = new System.Drawing.Point(173, 19);
            this.txtServerAdress.Name = "txtServerAdress";
            this.txtServerAdress.Size = new System.Drawing.Size(162, 22);
            this.txtServerAdress.TabIndex = 1;
            // 
            // txtPingInterval
            // 
            this.txtPingInterval.Location = new System.Drawing.Point(173, 47);
            this.txtPingInterval.Name = "txtPingInterval";
            this.txtPingInterval.Size = new System.Drawing.Size(162, 22);
            this.txtPingInterval.TabIndex = 3;
            // 
            // lbServerAdress
            // 
            this.lbServerAdress.AutoSize = true;
            this.lbServerAdress.Location = new System.Drawing.Point(12, 25);
            this.lbServerAdress.Name = "lbServerAdress";
            this.lbServerAdress.Size = new System.Drawing.Size(80, 13);
            this.lbServerAdress.TabIndex = 0;
            this.lbServerAdress.Text = "Server adress :";
            // 
            // lbPingInterval
            // 
            this.lbPingInterval.AutoSize = true;
            this.lbPingInterval.Location = new System.Drawing.Point(12, 50);
            this.lbPingInterval.Name = "lbPingInterval";
            this.lbPingInterval.Size = new System.Drawing.Size(102, 13);
            this.lbPingInterval.TabIndex = 2;
            this.lbPingInterval.Text = "Ping interval (sec) :";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnStart.Location = new System.Drawing.Point(179, 186);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 27);
            this.btnStart.TabIndex = 11;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // txtNumberOfPingsToMonitor
            // 
            this.txtNumberOfPingsToMonitor.Location = new System.Drawing.Point(173, 74);
            this.txtNumberOfPingsToMonitor.Name = "txtNumberOfPingsToMonitor";
            this.txtNumberOfPingsToMonitor.Size = new System.Drawing.Size(162, 22);
            this.txtNumberOfPingsToMonitor.TabIndex = 5;
            // 
            // txtNumberOfPingIssues
            // 
            this.txtNumberOfPingIssues.Location = new System.Drawing.Point(173, 102);
            this.txtNumberOfPingIssues.Name = "txtNumberOfPingIssues";
            this.txtNumberOfPingIssues.Size = new System.Drawing.Size(162, 22);
            this.txtNumberOfPingIssues.TabIndex = 7;
            // 
            // txtMaxRoundtripTime
            // 
            this.txtMaxRoundtripTime.Location = new System.Drawing.Point(173, 130);
            this.txtMaxRoundtripTime.Name = "txtMaxRoundtripTime";
            this.txtMaxRoundtripTime.Size = new System.Drawing.Size(162, 22);
            this.txtMaxRoundtripTime.TabIndex = 9;
            // 
            // lbNumberOfPingsToMonitor
            // 
            this.lbNumberOfPingsToMonitor.AutoSize = true;
            this.lbNumberOfPingsToMonitor.Location = new System.Drawing.Point(12, 77);
            this.lbNumberOfPingsToMonitor.Name = "lbNumberOfPingsToMonitor";
            this.lbNumberOfPingsToMonitor.Size = new System.Drawing.Size(158, 13);
            this.lbNumberOfPingsToMonitor.TabIndex = 4;
            this.lbNumberOfPingsToMonitor.Text = "Number of pings to monitor :";
            // 
            // lbMaxRoundtripTime
            // 
            this.lbMaxRoundtripTime.AutoSize = true;
            this.lbMaxRoundtripTime.Location = new System.Drawing.Point(12, 133);
            this.lbMaxRoundtripTime.Name = "lbMaxRoundtripTime";
            this.lbMaxRoundtripTime.Size = new System.Drawing.Size(135, 13);
            this.lbMaxRoundtripTime.TabIndex = 8;
            this.lbMaxRoundtripTime.Text = "Max roundtrip time (ms) :";
            // 
            // lbNumberOfPingIssues
            // 
            this.lbNumberOfPingIssues.AutoSize = true;
            this.lbNumberOfPingIssues.Location = new System.Drawing.Point(12, 105);
            this.lbNumberOfPingIssues.Name = "lbNumberOfPingIssues";
            this.lbNumberOfPingIssues.Size = new System.Drawing.Size(129, 13);
            this.lbNumberOfPingIssues.TabIndex = 6;
            this.lbNumberOfPingIssues.Text = "Number of ping issues :";
            // 
            // cbStartMonitoring
            // 
            this.cbStartMonitoring.AutoSize = true;
            this.cbStartMonitoring.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStartMonitoring.Location = new System.Drawing.Point(167, 158);
            this.cbStartMonitoring.Name = "cbStartMonitoring";
            this.cbStartMonitoring.Size = new System.Drawing.Size(168, 17);
            this.cbStartMonitoring.TabIndex = 10;
            this.cbStartMonitoring.Text = "Start monitoring on startup";
            this.cbStartMonitoring.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnMinimize;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(347, 225);
            this.Controls.Add(this.lbNumberOfPingIssues);
            this.Controls.Add(this.cbStartMonitoring);
            this.Controls.Add(this.lbMaxRoundtripTime);
            this.Controls.Add(this.lbNumberOfPingsToMonitor);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.txtMaxRoundtripTime);
            this.Controls.Add(this.txtNumberOfPingsToMonitor);
            this.Controls.Add(this.lbServerAdress);
            this.Controls.Add(this.txtNumberOfPingIssues);
            this.Controls.Add(this.lbPingInterval);
            this.Controls.Add(this.txtPingInterval);
            this.Controls.Add(this.txtServerAdress);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ping Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.rightClickMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnMinimize;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.TextBox txtServerAdress;
        private System.Windows.Forms.TextBox txtPingInterval;
        private System.Windows.Forms.Label lbServerAdress;
        private System.Windows.Forms.Label lbPingInterval;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ToolStripMenuItem showHideToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip rightClickMenu;
        private System.Windows.Forms.TextBox txtNumberOfPingsToMonitor;
        private System.Windows.Forms.TextBox txtNumberOfPingIssues;
        private System.Windows.Forms.TextBox txtMaxRoundtripTime;
        private System.Windows.Forms.Label lbNumberOfPingsToMonitor;
        private System.Windows.Forms.Label lbMaxRoundtripTime;
        private System.Windows.Forms.Label lbNumberOfPingIssues;
        private System.Windows.Forms.CheckBox cbStartMonitoring;
    }
}

