using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static MiniApp.Wind;

namespace Minimizer
{
    class DWM
    {
        public static readonly uint DWM_EC_DISABLECOMPOSITION = 0;
        public static readonly uint DWM_EC_ENABLECOMPOSITION = 1;

        // DWM
        [DllImport("dwmapi", SetLastError = true)]
        public static extern int DwmRegisterThumbnail(IntPtr dest, IntPtr src, out IntPtr thumb);
        [DllImport("dwmapi", SetLastError = true)]
        public static extern int DwmUnregisterThumbnail(IntPtr thumb);
        [DllImport("dwmapi", SetLastError = true)]
        public static extern int DwmQueryThumbnailSourceSize(IntPtr thumb, out Size size);

        // Deprecated as of Windows 8 Release Preview
        [DllImport("dwmapi", SetLastError = true)]
        public static extern int DwmIsCompositionEnabled(out bool enabled);
        [DllImport("dwmapi", SetLastError = true)]
        public static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out RECT lpRect, int size);

        // Key to ColorizationColor for DWM
        private const string COLORIZATION_COLOR_KEY = @"SOFTWARE\Microsoft\Windows\DWM";

        /// <summary>
        /// Helper method for an easy DWM check
        /// </summary>
        /// <returns>bool true if DWM is available AND active</returns>
        public static bool IsDwmEnabled()
        {
            // According to: http://technet.microsoft.com/en-us/subscriptions/aa969538%28v=vs.85%29.aspx
            // And: http://msdn.microsoft.com/en-us/library/windows/desktop/aa969510%28v=vs.85%29.aspx
            // DMW is always enabled on Windows 8! So return true and save a check! ;-)
            if (Environment.OSVersion.Version.Major == 6 && Environment.OSVersion.Version.Minor == 2)
            {
                return true;
            }
            if (Environment.OSVersion.Version.Major >= 6)
            {
                bool dwmEnabled;
                DwmIsCompositionEnabled(out dwmEnabled);
                return dwmEnabled;
            }
            return false;
        }

        public static Color ColorizationColor
        {
            get
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(COLORIZATION_COLOR_KEY, false))
                {
                    object dwordValue = key?.GetValue("ColorizationColor");
                    if (dwordValue != null)
                    {
                        return Color.FromArgb((int)dwordValue);
                    }
                }
                return Color.White;
            }
        }
    }
}
