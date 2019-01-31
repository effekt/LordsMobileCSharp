using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using WindowsInput.Native;
using System.Runtime.InteropServices;

namespace LordsMobile
{
    class Controller
    {
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern short VkKeyScan(char ch);
        private IntPtr hwnd;

        public Controller(IntPtr hwnd)
        {
            this.hwnd = hwnd;
        }


        //this allows virtual mouse event creation and win32 api calls
        //[DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]

        //creating virtual mouse events here
        //public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        static extern bool PostMessage(IntPtr hwnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        private const uint WM_KEYDOWN = 0x0100;
        private const uint WM_KEYUP = 0x0101;
        private const uint WM_SETTEXT = 0x000C;
        private const uint WM_CHAR = 0x102;
        private const uint WM_MOUSEMOVE = 0x0200;
        private const uint WM_LBUTTONDOWN = 0x0201;
        private const uint WM_LBUTTONUP = 0x0202;

        public static IntPtr MakeLParam(int wLow, int wHigh)
        {
            return (IntPtr)((wHigh << 16) | (wLow & 0xffff));
        }

        public bool vClick(Point p)
        {
            int x = p.X, y = p.Y;
            if (x == -1 || y == -1)
                return false;
            SendMessage(this.hwnd, WM_LBUTTONDOWN, 0x0001, MakeLParam(x, y));
            SendMessage(this.hwnd, WM_LBUTTONUP, 0x0000, MakeLParam(x, y));
            Thread.Sleep(1500);
            return true;
        }


        public void vDrag(Point p1, Point p2, bool turf = true)
        {
            int dx = (p2.X - p1.X) / 40;
            int dy = (p2.Y - p1.Y) / 40;
            int x = 0, y = 0;
            SendMessage(this.hwnd, WM_LBUTTONDOWN, 0x0001, MakeLParam(p1.X, p1.Y));
            for (int i = 1; i < 41; i++)
            {
                x = p1.X + (i * dx);
                y = p1.Y + (i * dy);
                SendMessage(this.hwnd, WM_MOUSEMOVE, 0x0001, MakeLParam(x, y));
                Thread.Sleep(50);
            }
            Thread.Sleep(375);
            SendMessage(this.hwnd, WM_LBUTTONUP, 0x0000, MakeLParam(x, y));
        }

        public void vMoveUp(bool turf = true)
        {
            int y = turf ? 175 : 225;
            vDrag(Statics.GAME_MID, new Point(Statics.GAME_MID.X, Statics.GAME_MID.Y + y));
        }

        public void vMoveDown(bool turf = true)
        {
            int y = turf ? 175 : 225;
            vDrag(Statics.GAME_MID, new Point(Statics.GAME_MID.X, Statics.GAME_MID.Y - y));
        }

        public void vMoveLeft(bool turf = true)
        {
            int x = turf ? 200 : 350;
            vDrag(Statics.GAME_MID, new Point(Statics.GAME_MID.X + x, Statics.GAME_MID.Y));
        }

        public void vMoveRight(bool turf = true)
        {
            int x = turf ? 200 : 350;
            vDrag(Statics.GAME_MID, new Point(Statics.GAME_MID.X - x, Statics.GAME_MID.Y));
        }

        public void vDragMouse(Point p1, Point p2)
        {
            vDrag(p1, p2);
        }

        public void vPressEsc()
        {
            IntPtr rv = SendMessage(this.hwnd, WM_KEYDOWN, (int)VirtualKeyCode.ESCAPE, (IntPtr)0x00010001);
            //IntPtr rv = SendMessage(hdl, WM_CHAR, (int)VirtualKeyCode.VK_L, (IntPtr)0);
            rv = SendMessage(this.hwnd, WM_KEYUP, (int)VirtualKeyCode.ESCAPE, (IntPtr)0);
            Debug.WriteLine(rv);
            Thread.Sleep(100);
        }

        public void vType(string toType)
        {
            char[] chars = toType.ToCharArray();
            VirtualKeyCode vk;
            for (int i = 0; i < chars.Length; i++)
            {
                vk = (WindowsInput.Native.VirtualKeyCode)VkKeyScan(chars[i]);
                Debug.WriteLine(vk);
                SendMessage(this.hwnd, WM_KEYDOWN, (int)vk, IntPtr.Zero);
                SendMessage(this.hwnd, WM_KEYUP, (int)vk, IntPtr.Zero);
                Thread.Sleep(350);
            }
        }

        public void clickNumpad(int num)
        {
            switch (num)
            {
                case 1: vClick(Statics.NumPad.ONE); break;
                case 2: vClick(Statics.NumPad.TWO); break;
                case 3: vClick(Statics.NumPad.THREE); break;
                case 4: vClick(Statics.NumPad.FOUR); break;
                case 5: vClick(Statics.NumPad.FIVE); break;
                case 6: vClick(Statics.NumPad.SIX); break;
                case 7: vClick(Statics.NumPad.SEVEN); break;
                case 8: vClick(Statics.NumPad.EIGHT); break;
                case 9: vClick(Statics.NumPad.NINE); break;
                case 0: vClick(Statics.NumPad.ZERO); break;
                case -1: vClick(Statics.NumPad.CONFIRM); break;
            }
        }
    }
}
