using log4net;
using log4net.Config;
using PingMonitor.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.NetworkInformation;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace PingMonitor.UI
{
    public partial class MainForm : Form
    {
        private static readonly ILog Log = LogManager.GetLogger("PingMonitor");
        private bool inMonitoring = false;
        private bool isRed = false;
        private System.Threading.Timer timer;
        private readonly AppSettings appSettings = new AppSettings();
        private readonly Icon red = new Icon(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources\\red.ico"));
        private readonly Icon green = new Icon(Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "Resources\\green.ico"));
        private Queue<long> pingResults;

        #region Constructor
        public MainForm()
        {
            XmlConfigurator.Configure();
            InitializeComponent();
            trayIcon.Text = Constants.APP_NAME;
        }
        #endregion

        #region WndProc
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == PingMonitor.WM_ACTIVATEAPP && m.WParam.ToInt32() == PingMonitor.ProgramId)
            {
                ShowHide();
            }
            else
            {
                base.WndProc(ref m);
            }
        }
        #endregion

        #region ShowHide
        private void ShowHide()
        {
            if (Visible)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }

        private void OnShowHide(object sender, EventArgs e)
        {
            ShowHide();
        }
        #endregion

        #region Exit
        private bool CanExit()
        {
            string message = string.Format("Do you really want to exit {0}?", Constants.APP_NAME);
            if (MessageBox.Show(message, Constants.APP_NAME, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }

        private void OnBeforeExit()
        {
            trayIcon.Visible = false;
        }
        #endregion

        #region ButtonClicks
        private void TrayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowHide();
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (!inMonitoring)
            {
                Ping pingSender = new Ping();
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    PingReply check = pingSender.Send(txtServerAdress.Text);
                    if (Regex.IsMatch(txtPingInterval.Text, "[1-9]\\d{0,5}") && Regex.IsMatch(txtNumberOfPingsToMonitor.Text, "[1-9]\\d{0,5}") &&
                        Regex.IsMatch(txtNumberOfPingIssues.Text, "[1-9]\\d{0,5}") && Regex.IsMatch(txtMaxRoundtripTime.Text, "[1-9]\\d{0,5}"))
                    {
                        pingResults = new Queue<long>(Convert.ToInt32(txtNumberOfPingsToMonitor.Text));
                        timer = new System.Threading.Timer(new TimerCallback(DoSomething), null, 0, Convert.ToInt32(txtPingInterval.Text) * 1000);
                        inMonitoring = true;
                        Log.Info(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "|INFO|||Monitoring \"" + txtServerAdress.Text + "\"");
                        txtServerAdress.Enabled = false;
                        txtPingInterval.Enabled = false;
                        txtNumberOfPingsToMonitor.Enabled = false;
                        txtNumberOfPingIssues.Enabled = false;
                        txtMaxRoundtripTime.Enabled = false;
                        btnStart.Text = "Stop";
                    }
                    else
                    {
                        Show();
                        MessageBox.Show("Insert number between 1 and 999999");
                    }
                }
                catch (Exception ex)
                {
                    Log.Error(DateTime.Now.ToString("dd.MM.yyyy HH:mm") + "|ERROR|Exception||" + ex.ToString().Replace("\r\n", ""));
                    Show();
                    MessageBox.Show("No internet connection or invalid server address");
                }
                finally
                {
                    Cursor.Current = Cursors.Default;
                }
            }
            else
            {
                timer.Change(Timeout.Infinite, Timeout.Infinite);
                inMonitoring = false;
                txtServerAdress.Enabled = true;
                txtPingInterval.Enabled = true;
                txtNumberOfPingsToMonitor.Enabled = true;
                txtNumberOfPingIssues.Enabled = true;
                txtMaxRoundtripTime.Enabled = true;
                btnStart.Text = "Start";
            }
        }

        private void DoSomething(object obj)
        {
            DateTime dt = DateTime.Now;
            string adress = txtServerAdress.Text;
            Ping pingSender = new Ping();
            string data = "<<<--create 32 bytes buffer-->>>";
            byte[] buffer = Encoding.ASCII.GetBytes(data);
            int timeout = 2000;
            PingOptions options = new PingOptions(64, true);
            try
            {
                PingReply reply = pingSender.Send(adress, timeout, buffer, options);
                if (pingResults.Count >= Convert.ToInt32(txtNumberOfPingsToMonitor.Text))
                {
                    pingResults.Dequeue();
                }

                if (reply.RoundtripTime >= Convert.ToInt64(txtMaxRoundtripTime.Text))
                {
                    Log.Debug(dt.ToString("dd.MM.yyyy HH:mm:ss") + "|DEBUG|Failure|" + reply.RoundtripTime + "|");
                    Log.Info(dt.ToString("dd.MM.yyyy HH:mm:ss") + "|INFO|Failure|" + reply.RoundtripTime + "|");
                }
                else if (reply.Status == IPStatus.TimedOut)
                {
                    Log.Debug(dt.ToString("dd.MM.yyyy HH:mm:ss") + "|DEBUG|Timeout|" + reply.RoundtripTime + "|");
                    Log.Info(dt.ToString("dd.MM.yyyy HH:mm:ss") + "|INFO|Timeout|" + reply.RoundtripTime + "|");
                }
                else
                {
                    Log.Debug(dt.ToString("dd.MM.yyyy HH:mm:ss") + "|DEBUG|Success|" + reply.RoundtripTime + "|");
                }

                pingResults.Enqueue(reply.RoundtripTime);
                ProcessPingResults();
            }
            catch (Exception ex)
            {
                Log.Error(dt.ToString("dd.MM.yyyy HH:mm:ss") + "|ERROR|Exception||" + ex.ToString().Replace("\r\n", ""));
            }
        }

        private void ProcessPingResults()
        {
            int count = 0;
            foreach (long pingResult in pingResults)
            {
                if (pingResult >= Convert.ToInt64(txtMaxRoundtripTime.Text) || pingResult == 0)
                {
                    count++;
                }
            }
            if (count >= Convert.ToInt32(txtNumberOfPingIssues.Text) && isRed == false)
            {
                trayIcon.Icon = red;
                trayIcon.ShowBalloonTip(100, "Warning:", "connection problems", ToolTipIcon.Warning);
                isRed = true;
                Log.Info(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "|INFO|Red >=" + txtMaxRoundtripTime.Text + "||");
            }
            if (count < Convert.ToInt32(txtNumberOfPingIssues.Text) && isRed == true)
            {
                trayIcon.Icon = green;
                isRed = false;
                Log.Info(DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss") + "|INFO|Green <" + txtMaxRoundtripTime.Text + "||");
            }
        }
        #endregion

        #region MainFormEvents
        private void MainForm_Load(object sender, EventArgs e)
        {
            txtServerAdress.DataBindings.Add(new Binding("Text", appSettings, "ServerAdress", true, DataSourceUpdateMode.OnPropertyChanged));
            txtPingInterval.DataBindings.Add(new Binding("Text", appSettings, "PingInterval", true, DataSourceUpdateMode.OnPropertyChanged));
            txtNumberOfPingsToMonitor.DataBindings.Add(new Binding("Text", appSettings, "NumberOfPingsToMonitor", true, DataSourceUpdateMode.OnPropertyChanged));
            txtNumberOfPingIssues.DataBindings.Add(new Binding("Text", appSettings, "NumberOfPingIssues", true, DataSourceUpdateMode.OnPropertyChanged));
            txtMaxRoundtripTime.DataBindings.Add(new Binding("Text", appSettings, "MaxRoundtripTime", true, DataSourceUpdateMode.OnPropertyChanged));
            cbStartMonitoring.DataBindings.Add(new Binding("Checked", appSettings, "StartMonitoringOnStartup", true, DataSourceUpdateMode.OnPropertyChanged));
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (cbStartMonitoring.Checked)
            {
                Hide();
                BtnStart_Click(null, null);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                bool canExit = CanExit();
                if (canExit)
                {
                    OnBeforeExit();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                OnBeforeExit();
            }

            appSettings.Save();
        }
        #endregion

        #region RightClikMenuOptions
        private void OpenHideToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHide();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
    }
}
