using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.Structure;
using Tesseract;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace LordsMobile
{
    class Vision
    {
        private Image<Gray, Byte> frame;
        private Image<Bgr, Byte> scr;
        private TesseractEngine tess = new TesseractEngine("./tessdata", "eng", EngineMode.Default);
        private IntPtr hwnd;



        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);
        [DllImport("user32.dll")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, int nFlags);

        public Bitmap PrintWindow()
        {
            RECT rc;
            GetWindowRect(hwnd, out rc);

            Bitmap bmp = new Bitmap(rc.Width, rc.Height, PixelFormat.Format32bppRgb);
            Graphics gfxBmp = Graphics.FromImage(bmp);
            IntPtr hdcBitmap = gfxBmp.GetHdc();

            PrintWindow(hwnd, hdcBitmap, 0);

            gfxBmp.ReleaseHdc(hdcBitmap);
            gfxBmp.Dispose();

            return bmp;
        }

        public Vision(IntPtr hwnd)
        {
            this.hwnd = hwnd;
        }




        private void captureScreen()
        {
            if (frame != null)
                frame.Dispose();

            if (scr != null)
                scr.Dispose();

            Bitmap printscreen = PrintWindow();
            Image<Bgr, Byte> imageCV = new Image<Bgr, Byte>(printscreen);
            scr = imageCV;
            frame = imageCV.Convert<Gray, byte>();
            frame = frame.ThresholdBinary(new Gray(150), new Gray(255.0));
            imageCV.Dispose();
            printscreen.Dispose();
        }

        public Point matchTemplate(string template = null, double threshold = 0.35, bool max = false)
        {
            captureScreen();
            Image<Gray, Byte> tmp = Emgu.CV.CvInvoke.Imread(template).ToImage<Gray, Byte>();
            using (Image<Gray, float> imgMatch = frame.MatchTemplate(tmp, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                imgMatch.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                
                imgMatch.Dispose();
                int hX = tmp.Width / 2, hY = tmp.Height / 2;
                tmp.Dispose();
                if (max)
                    return new Point(maxLocations[0].X + hX, maxLocations[0].Y + hY);
                if (maxValues[0] >= threshold)
                {
                    return new Point(maxLocations[0].X + hX, maxLocations[0].Y + hY);
                }
            }
            if (tmp != null)
                tmp.Dispose();
            return new Point(-1, -1);
        }

        public string readText(Rectangle r, bool asInt = false)
        {
            captureScreen();
            frame.ROI = r;

            Page p = tess.Process(frame.Bitmap, PageSegMode.Auto);
            string res = p.GetText();
            p.Dispose();
            if (asInt)
            {
                return new String(res.Where(Char.IsDigit).ToArray());
            }
            return res;
        }

        public void saveScreen()
        {
            captureScreen();
            frame.Save("C:\\temp\\" + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString() + ".jpg");
        }

        //public Point testMatch(string template, double threshold = 0.35)
        //{
        //    captureScreen();
        //    Image<Gray, Byte> tmp = Emgu.CV.CvInvoke.Imread(template).ToImage<Gray, Byte>();
        //    using (Image<Gray, float> imgMatch = frame.MatchTemplate(tmp, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
        //    {
        //        double[] minValues, maxValues;
        //        Point[] minLocations, maxLocations;
        //        imgMatch.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
        //        imgMatch.Dispose();
        //        if (maxValues[0] >= threshold)
        //        {
        //            Rectangle match = new Rectangle(maxLocations[0], tmp.Size);
        //            frame.Draw(match, new Gray(255), 25);
        //            frame.Save("C:\\temp\\" + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString() + ".jpg");
        //            return new Point(maxLocations[0].X + tmp.Width / 2, maxLocations[0].Y + tmp.Height / 2);
        //        } else
        //            frame.Save("C:\\temp\\" + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString() + ".jpg");
        //    }
        //    tmp.Dispose();
        //    return new Point(-1, -1);
        //}
    }
}


[StructLayout(LayoutKind.Sequential)]
public struct RECT
{
    private int _Left;
    private int _Top;
    private int _Right;
    private int _Bottom;

    public RECT(RECT Rectangle) : this(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom)
    {
    }
    public RECT(int Left, int Top, int Right, int Bottom)
    {
        _Left = Left;
        _Top = Top;
        _Right = Right;
        _Bottom = Bottom;
    }

    public int X
    {
        get { return _Left; }
        set { _Left = value; }
    }
    public int Y
    {
        get { return _Top; }
        set { _Top = value; }
    }
    public int Left
    {
        get { return _Left; }
        set { _Left = value; }
    }
    public int Top
    {
        get { return _Top; }
        set { _Top = value; }
    }
    public int Right
    {
        get { return _Right; }
        set { _Right = value; }
    }
    public int Bottom
    {
        get { return _Bottom; }
        set { _Bottom = value; }
    }
    public int Height
    {
        get { return _Bottom - _Top; }
        set { _Bottom = value + _Top; }
    }
    public int Width
    {
        get { return _Right - _Left; }
        set { _Right = value + _Left; }
    }
    public Point Location
    {
        get { return new Point(Left, Top); }
        set
        {
            _Left = value.X;
            _Top = value.Y;
        }
    }
    public Size Size
    {
        get { return new Size(Width, Height); }
        set
        {
            _Right = value.Width + _Left;
            _Bottom = value.Height + _Top;
        }
    }

    public static implicit operator Rectangle(RECT Rectangle)
    {
        return new Rectangle(Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height);
    }
    public static implicit operator RECT(Rectangle Rectangle)
    {
        return new RECT(Rectangle.Left, Rectangle.Top, Rectangle.Right, Rectangle.Bottom);
    }
    public static bool operator ==(RECT Rectangle1, RECT Rectangle2)
    {
        return Rectangle1.Equals(Rectangle2);
    }
    public static bool operator !=(RECT Rectangle1, RECT Rectangle2)
    {
        return !Rectangle1.Equals(Rectangle2);
    }

    public override string ToString()
    {
        return "{Left: " + _Left + "; " + "Top: " + _Top + "; Right: " + _Right + "; Bottom: " + _Bottom + "}";
    }

    public override int GetHashCode()
    {
        return ToString().GetHashCode();
    }

    public bool Equals(RECT Rectangle)
    {
        return Rectangle.Left == _Left && Rectangle.Top == _Top && Rectangle.Right == _Right && Rectangle.Bottom == _Bottom;
    }

    public override bool Equals(object Object)
    {
        if (Object is RECT)
        {
            return Equals((RECT)Object);
        }
        else if (Object is Rectangle)
        {
            return Equals(new RECT((Rectangle)Object));
        }

        return false;
    }
}
