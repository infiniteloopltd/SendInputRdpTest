using System.Runtime.InteropServices;
using System.Windows.Forms;
using Timer = System.Threading.Timer;

namespace SendInputRdpTester
{
    public partial class Form1 : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        // Import the necessary functions from user32.dll
        [DllImport("user32.dll")]
        public static extern uint SendInput(uint nInputs, INPUT[] pInputs, int cbSize);

        // Structure for input event
        [StructLayout(LayoutKind.Sequential)]
        public struct INPUT
        {
            public int type;
            public InputUnion u;
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct InputUnion
        {
            [FieldOffset(0)]
            public MOUSEINPUT mi;
            [FieldOffset(0)]
            public KEYBDINPUT ki;
            [FieldOffset(0)]
            public HARDWAREINPUT hi;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MOUSEINPUT
        {
            public int dx;
            public int dy;
            public uint mouseData;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KEYBDINPUT
        {
            public ushort wVk;
            public ushort wScan;
            public uint dwFlags;
            public uint time;
            public IntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
        }

        // Key event flags
        const int KEYEVENTF_KEYDOWN = 0x0000;
        const int KEYEVENTF_KEYUP = 0x0002;

        private System.Windows.Forms.Timer timer = new();
        public Form1()
        {
            InitializeComponent();
        }

        const byte VK_A = 0x41;

      


        private void Form1_Load(object sender, EventArgs e)
        {
            Text = "SendInput version";
            timer.Interval = 1000;
            timer.Tick += (o, args) =>
            {
                textBox1.Focus();
                // SendKeys.Send(GetLetter().ToString());
                var random = new Random();

                // Generate a random letter (ASCII code for A-Z is 65-90)
                var randomKeyCode = (byte)random.Next(65, 91); // Generating a random number between 65 (inclusive) and 91 (exclusive)

                #region error
                /*
                 See the end of this message for details on invoking 
                   just-in-time (JIT) debugging instead of this dialog box.
                   
                   ************** Exception Text **************
                   System.ComponentModel.Win32Exception (5): Access is denied.
                      at System.Windows.Forms.SendKeys.SendInput(ReadOnlySpan`1 oldKeyboardState, SKEvent[] previousEvents)
                      at System.Windows.Forms.SendKeys.Send(String keys, Control control, Boolean wait)
                      at System.Windows.Forms.SendKeys.Send(String keys)
                      at SendInputRdpTester.Form1.<Form1_Load>b__2_0(Object o, EventArgs args) in C:\Projects\SendInputRdpTester\Form1.cs:line 19
                      at System.Windows.Forms.Timer.OnTick(EventArgs e)
                      at System.Windows.Forms.Timer.TimerNativeWindow.WndProc(Message& m)
                      at System.Windows.Forms.NativeWindow.Callback(IntPtr hWnd, WM msg, IntPtr wparam, IntPtr lparam)
                   ************** Loaded Assemblies **************
                   System.Private.CoreLib
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Private.CoreLib.dll
                   ----------------------------------------
                   SendInputRdpTester
                       Assembly Version: 1.0.0.0
                       Win32 Version: 1.0.0.0
                       CodeBase: file:///C:/Utilities/SendInputRdpTest/bin/Debug/net6.0-windows/SendInputRdpTester.dll
                   ----------------------------------------
                   System.Runtime
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Runtime.dll
                   ----------------------------------------
                   System.Windows.Forms
                       Assembly Version: 6.0.2.0
                       Win32 Version: 6.0.2523.51916
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.WindowsDesktop.App/6.0.25/System.Windows.Forms.dll
                   ----------------------------------------
                   System.ComponentModel.Primitives
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.ComponentModel.Primitives.dll
                   ----------------------------------------
                   System.Windows.Forms.Primitives
                       Assembly Version: 6.0.2.0
                       Win32 Version: 6.0.2523.51916
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.WindowsDesktop.App/6.0.25/System.Windows.Forms.Primitives.dll
                   ----------------------------------------
                   System.Runtime.InteropServices
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Runtime.InteropServices.dll
                   ----------------------------------------
                   System.Drawing.Primitives
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Drawing.Primitives.dll
                   ----------------------------------------
                   System.Collections.Specialized
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Collections.Specialized.dll
                   ----------------------------------------
                   System.Threading
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Threading.dll
                   ----------------------------------------
                   System.Diagnostics.TraceSource
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Diagnostics.TraceSource.dll
                   ----------------------------------------
                   System.Collections
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Collections.dll
                   ----------------------------------------
                   System.Drawing.Common
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.WindowsDesktop.App/6.0.25/System.Drawing.Common.dll
                   ----------------------------------------
                   Microsoft.Win32.Primitives
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/Microsoft.Win32.Primitives.dll
                   ----------------------------------------
                   System.ComponentModel.EventBasedAsync
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.ComponentModel.EventBasedAsync.dll
                   ----------------------------------------
                   System.Threading.Thread
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Threading.Thread.dll
                   ----------------------------------------
                   Accessibility
                       Assembly Version: 4.0.0.0
                       Win32 Version: 6.0.2523.51916
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.WindowsDesktop.App/6.0.25/Accessibility.dll
                   ----------------------------------------
                   System.Numerics.Vectors
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Numerics.Vectors.dll
                   ----------------------------------------
                   Microsoft.Win32.SystemEvents
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.WindowsDesktop.App/6.0.25/Microsoft.Win32.SystemEvents.dll
                   ----------------------------------------
                   System.Collections.NonGeneric
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Collections.NonGeneric.dll
                   ----------------------------------------
                   System.ComponentModel.TypeConverter
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.ComponentModel.TypeConverter.dll
                   ----------------------------------------
                   System.Configuration.ConfigurationManager
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.WindowsDesktop.App/6.0.25/System.Configuration.ConfigurationManager.dll
                   ----------------------------------------
                   System.Runtime.InteropServices.RuntimeInformation
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Runtime.InteropServices.RuntimeInformation.dll
                   ----------------------------------------
                   System.Private.Uri
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Private.Uri.dll
                   ----------------------------------------
                   System.Xml.ReaderWriter
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Xml.ReaderWriter.dll
                   ----------------------------------------
                   System.Private.Xml
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Private.Xml.dll
                   ----------------------------------------
                   System.Net.WebClient
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Net.WebClient.dll
                   ----------------------------------------
                   System.Memory
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Memory.dll
                   ----------------------------------------
                   System.Text.Encoding.Extensions
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Text.Encoding.Extensions.dll
                   ----------------------------------------
                   System.Collections.Concurrent
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Collections.Concurrent.dll
                   ----------------------------------------
                   System.ComponentModel
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.ComponentModel.dll
                   ----------------------------------------
                   System.Runtime.CompilerServices.Unsafe
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Runtime.CompilerServices.Unsafe.dll
                   ----------------------------------------
                   System.Runtime.Loader
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Runtime.Loader.dll
                   ----------------------------------------
                   System.Diagnostics.StackTrace
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Diagnostics.StackTrace.dll
                   ----------------------------------------
                   System.Reflection.Metadata
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Reflection.Metadata.dll
                   ----------------------------------------
                   System.Collections.Immutable
                       Assembly Version: 6.0.0.0
                       Win32 Version: 6.0.2523.51912
                       CodeBase: file:///C:/Program%20Files/dotnet/shared/Microsoft.NETCore.App/6.0.25/System.Collections.Immutable.dll
                   ----------------------------------------
                   
                   ************** JIT Debugging **************
                   
                   
                   
                  
                 */
                #endregion

                INPUT[] inputs = new INPUT[2];

                inputs[0] = new INPUT();
                inputs[0].type = 1; // INPUT_KEYBOARD

                inputs[0].u.ki.wVk = (ushort)randomKeyCode;
                inputs[0].u.ki.wScan = 0;
                inputs[0].u.ki.dwFlags = KEYEVENTF_KEYDOWN;
                inputs[0].u.ki.time = 0;
                inputs[0].u.ki.dwExtraInfo = IntPtr.Zero;

                inputs[1] = new INPUT();
                inputs[1].type = 1; // INPUT_KEYBOARD
                inputs[1].u.ki.wVk = (ushort)randomKeyCode;
                inputs[1].u.ki.wScan = 0;
                inputs[1].u.ki.dwFlags = KEYEVENTF_KEYUP;
                inputs[1].u.ki.time = 0;
                inputs[1].u.ki.dwExtraInfo = IntPtr.Zero;

                SendInput(2, inputs, Marshal.SizeOf(typeof(INPUT)));
            };
            timer.Start();
        }

        public static char GetLetter()
        {
            string chars = "$%#@!*abcdefghijklmnopqrstuvwxyz1234567890?;:ABCDEFGHIJKLMNOPQRSTUVWXYZ^&";
            Random rand = new Random();
            int num = rand.Next(0, chars.Length);
            return chars[num];
        }
    }
}