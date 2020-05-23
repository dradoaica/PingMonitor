using PingMonitor.Core;
using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace PingMonitor.UI
{
    internal static class PingMonitor
    {
        #region Dll Imports
        public const int HWND_BROADCAST = 0xFFFF;

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
        #endregion Dll Imports

        public static readonly int ProgramId = 26;//some number to uniquely identify this application
        public static readonly int WM_ACTIVATEAPP = RegisterWindowMessage("WM_ACTIVATEAPP");

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            using (Mutex mutex = new Mutex(true, Constants.APP_NAME, out bool createdNew))
            {
                if (createdNew)
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new MainForm());
                }
                else
                {
                    Process current = Process.GetCurrentProcess();
                    string processName = current.ProcessName;
                    if (processName.EndsWith("vshost"))
                    {
                        processName = processName.Replace(".vshost", "");
                    }

                    foreach (Process process in Process.GetProcessesByName(processName))
                    {
                        if (process.Id != current.Id)
                        {
                            IntPtr handle = process.MainWindowHandle;
                            if (handle == IntPtr.Zero)
                            {
                                PostMessage((IntPtr)HWND_BROADCAST, WM_ACTIVATEAPP, new IntPtr(ProgramId), IntPtr.Zero);
                            }
                            else
                            {
                                SetForegroundWindow(handle);
                            }

                            break;
                        }
                    }
                }
            }
        }
    }
}