using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PingMonitor.UI
{
    public static class ListViewExtensions
    {
        #region LVCOLUMN
        [StructLayout(LayoutKind.Sequential)]
        private struct LVCOLUMN
        {
            public int mask;
            public int cx;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;
            public IntPtr hbm;
            public int cchTextMax;
            public int fmt;
            public int iSubItem;
            public int iImage;
            public int iOrder;
        }
        #endregion

        #region Constants
        private const int HDI_FORMAT = 0x4;
        private const int HDF_SORTUP = 0x400;
        private const int HDF_SORTDOWN = 0x200;
        private const int LVM_GETHEADER = 0x101f;
        private const int HDM_GETITEM = 0x120b;
        private const int HDM_SETITEM = 0x120c;
        #endregion

        #region DllImports
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern IntPtr SendMessageLVCOLUMN(IntPtr hWnd, int Msg, IntPtr wParam, ref LVCOLUMN lPLVCOLUMN);
        #endregion

        public static void SetSortIcon(this ListView ListViewControl, int ColumnIndex, System.Windows.Forms.SortOrder Order)
        {
            IntPtr ColumnHeader = SendMessage(ListViewControl.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);

            for (int ColumnNumber = 0; ColumnNumber <= ListViewControl.Columns.Count - 1; ColumnNumber++)
            {
                IntPtr ColumnPtr = new IntPtr(ColumnNumber);
                LVCOLUMN lvColumn = new LVCOLUMN
                {
                    mask = HDI_FORMAT
                };
                SendMessageLVCOLUMN(ColumnHeader, HDM_GETITEM, ColumnPtr, ref lvColumn);

                if (!(Order == SortOrder.None) && ColumnNumber == ColumnIndex)
                {
                    switch (Order)
                    {
                        case SortOrder.Ascending:
                            lvColumn.fmt &= ~HDF_SORTDOWN;
                            lvColumn.fmt |= HDF_SORTUP;
                            break;
                        case SortOrder.Descending:
                            lvColumn.fmt &= ~HDF_SORTUP;
                            lvColumn.fmt |= HDF_SORTDOWN;
                            break;
                    }
                }
                else
                {
                    lvColumn.fmt &= ~HDF_SORTDOWN & ~HDF_SORTUP;
                }

                SendMessageLVCOLUMN(ColumnHeader, HDM_SETITEM, ColumnPtr, ref lvColumn);
            }
        }

    }
}
