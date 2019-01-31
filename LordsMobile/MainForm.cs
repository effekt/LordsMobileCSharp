using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using WindowsInput.Native;
using WindowsInput;
using LordsMobile.Scripts;
using Emgu.CV;
using Emgu.CV.Structure;

namespace LordsMobile
{
    public partial class MainForm : Form
    {
        Thread theBot;
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        const int MYACTION_HOTKEY_ID = 1;

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);


        public MainForm()
        {
            RegisterHotKey(this.Handle, MYACTION_HOTKEY_ID, 6, (int)Keys.F12);
            new DB();
            MEmuManager.getVMs();
            InitializeComponent();
            lstMEmuProfiles.View = View.Details;
            lstMEmuProfiles.CheckBoxes = true;
            foreach (List<string> vm in MEmuManager.getMEmuIDs())
            {
                ListViewItem item = new ListViewItem(new[] { "", vm[0] });
                item.Checked = true;
                this.lstMEmuProfiles.Items.Add(item);
                this.lstProfiles.Items.Add(vm[0]);
            }
            ttpInstances.SetToolTip(this.lblNoInstances, Strings.noOfInstancesToolTip);
            ttpInstances.SetToolTip(this.txtNoInstances, Strings.noOfInstancesToolTip);
            ttpInstances.SetToolTip(this.lblTimeOnAccount, Strings.amtOfTimeToolTip);
            ttpInstances.SetToolTip(this.txtTimeOnAccount, Strings.amtOfTimeToolTip);
        }

        private void lstProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(lstProfiles.SelectedIndex);
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lstMEmuProfiles.Items)
            {
                if (item.Checked)
                    MEmuManager.setAllowedVMs(item.SubItems[1].Text);
            }
            MEmuManager.setMaxInstances(int.Parse(txtNoInstances.Text));
            Settings.duration = int.Parse(this.txtTimeOnAccount.Text);
            Settings.hiveCoordK = this.txtKCoord.Text;
            Settings.hiveCoordX = this.txtXCoord.Text;
            Settings.hiveCoordY = this.txtYCoord.Text;
            Settings.namePrefix = this.txtAccountName.Text;
            Settings.guildName = this.txtGuildName.Text;
            Settings.maxVMs = int.Parse(this.txtNoInstances.Text);
            if (Settings.maxVMs > MEmuManager.getAllowedVMs().Count)
                Settings.maxVMs = MEmuManager.getAllowedVMs().Count;
            Settings.maxArchers = int.Parse(this.txtArchers.Text);
            Settings.maxGrunts = int.Parse(this.txtGrunts.Text);
            Settings.maxCataphracts = int.Parse(this.txtCataphracts.Text);
            Settings.maxBallistas = int.Parse(this.txtBallistas.Text);
            theBot = new Thread(Bot.start);
            theBot.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bitmap bmp = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics gr = Graphics.FromImage(bmp);
            gr.CopyFromScreen(0, 0, 0, 0, bmp.Size);

            Image<Bgr, Byte> imageCV = new Image<Bgr, Byte>(bmp);
            Image<Gray, Byte>frame = imageCV.Convert<Gray, byte>();
            frame = frame.ThresholdBinary(new Gray(150), new Gray(255.0));
            imageCV.Dispose();
            gr.Dispose();
            Image<Gray, Byte> tmp = Emgu.CV.CvInvoke.Imread(Assets.Etc.Close).ToImage<Gray, Byte>();
            using (Image<Gray, float> imgMatch = frame.MatchTemplate(tmp, Emgu.CV.CvEnum.TemplateMatchingType.CcoeffNormed))
            {
                double[] minValues, maxValues;
                Point[] minLocations, maxLocations;
                imgMatch.MinMax(out minValues, out maxValues, out minLocations, out maxLocations);
                imgMatch.Dispose();
                if (maxValues[0] >= 0.65)
                {
                    Rectangle match = new Rectangle(maxLocations[0], tmp.Size);
                    frame.Draw(match, new Gray(255), 25);
                    frame.Save("C:\\temp\\" + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString() + ".jpg");
                }
                else
                    frame.Save("C:\\temp\\" + DateTimeOffset.UtcNow.ToUnixTimeSeconds().ToString() + ".jpg");
            }
            tmp.Dispose();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        private void button2_Click(object sender, EventArgs e)
        {
            Process[] p = Process.GetProcesses();
            Process theP = null;
            foreach (Process pr in p)
            {
                if (pr.MainWindowTitle == "MaggotBot0")
                {
                    theP = pr;
                    break;
                }
            }
            Debug.WriteLine(theP.MainWindowTitle);
            MoveWindow(theP.MainWindowHandle, 0, 0, Statics.GAME_WIDTH, Statics.GAME_HEIGHT, true);

            //Controller.vClick(theP.MainWindowHandle, Vision.testMatch(Assets.Tutorial.TapGo, 0.45));
            //Vision.testMatch(Assets.Tutorial.TapGo, 0.45);


            //Controller.vClick(theP.MainWindowHandle, Vision.matchTemplate(theP.MainWindowHandle, Assets.MEmu.Lords2, 0.6));

            //while (!Tutorial.hasTutorial() && Vision.matchTemplate(hdl, Assets.Etc.Close, 0.8).X == -1 && Vision.matchTemplate(hdl, Assets.Etc.Oracle, 0.55).X == -1)
            //{
            //    Thread.Sleep(1500);
            //}
            //Debug.WriteLine("found");
            //Thread.Sleep(1500);
            //Thread t;
            //t = new Thread(() => Tutorial.doTutorial(theP.MainWindowHandle, new Vision()));
            //t.Start();

            //Controller.vPressEsc(theP.MainWindowHandle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Controller.moveUp();
            //Controller.moveRight();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Controller.moveRight(checkBox1.Checked);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Controller.moveDown(checkBox1.Checked);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //Controller.moveLeft(checkBox1.Checked);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Controller.moveUp(checkBox1.Checked);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312 && m.WParam.ToInt32() == MYACTION_HOTKEY_ID)
            {
                //Bot.stop();
                //theBot.Join();
                Bot.stop();
                theBot.Abort();
                //MEmuManager.killAll();
                //MEmuManager.instances = null;
                //MEmuManager.processes = null;
            }
            base.WndProc(ref m);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Random rnd = new Random();
            Settings.duration = int.Parse(this.txtTimeOnAccount.Text);
            Settings.hiveCoordK = this.txtKCoord.Text;
            Settings.hiveCoordX = this.txtXCoord.Text;
            Settings.hiveCoordY = this.txtYCoord.Text;
            Settings.namePrefix = this.txtAccountName.Text;
            Settings.guildName = this.txtGuildName.Text;
            Settings.maxArchers = int.Parse(this.txtArchers.Text);
            Settings.maxGrunts = int.Parse(this.txtGrunts.Text);
            Settings.maxCataphracts = int.Parse(this.txtCataphracts.Text);
            Settings.maxBallistas = int.Parse(this.txtBallistas.Text);
            
        }
    }
}
