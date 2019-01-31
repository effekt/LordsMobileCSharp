using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace LordsMobile
{
    class MEmuManager
    {
        public static string[] instances;
        public static Process[] processes;
        private static String installPath = "C:\\Program Files (x86)\\Nox\\bin";
        private static List<List<string>> vms = new List<List<string>>();
        private static List<string> allowedVMs = new List<string>();
        private static int runningVMs = 0;
        private static int lastVM = 0;

        const int SW_RESTORE = 9;
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr handle);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool ShowWindow(IntPtr handle, int nCmdShow);
        [System.Runtime.InteropServices.DllImport("User32.dll")]
        private static extern bool IsIconic(IntPtr handle);
        [System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public MEmuManager()
        {
        }

        public static int getRunningAmount()
        {
            return runningVMs;
        }

        public static void getVMs()
        {
            string[] dirs;
            try
            {
                dirs = Directory.GetDirectories("C:\\Program Files (x86)\\Nox\\bin\\BignoxVMS");
            } catch(Exception ex)
            {
                dirs = Directory.GetDirectories("D:\\Program Files\\Nox\\bin\\BignoxVMS");
                MEmuManager.installPath = "D:\\Program Files\\Nox\\bin";
            }
            foreach (String dir in dirs)
            {
                string d = dir.Split('\\')[dir.Split('\\').Length - 1];
                MEmuManager.vms.Add(new List<string>() { d == "nox" ? "Nox_0" : d });
            }
        }

        public static IntPtr getHandle(int vm)
        {
            return processes[vm].MainWindowHandle;
        }

        private static int startVM(string vm)
        {
            int vmInd = Array.IndexOf(MEmuManager.instances, null);
            string noxNum = vm.Split('_')[1];

            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = installPath + "\\nox.exe",
                    Arguments = "-clone:" + vm + " \"-title:MaggotBot" + noxNum + "\"",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            do
            {
                System.Threading.Thread.Sleep(1000);
                Process[] p = Process.GetProcesses();
                foreach (Process pr in p)
                {
                    if (pr.MainWindowTitle == "MaggotBot" + noxNum)
                        processes[vmInd] = pr;
                }
            } while (processes[vmInd] == null);
            Thread.Sleep(500);
            Debug.WriteLine("Process Found: " + processes[vmInd].MainWindowTitle);
            resizeWindow(vmInd);
            Thread.Sleep(500);
            instances[vmInd] = vm;

            return vmInd;
        }

        public static void resizeWindow(int vmInd)
        {
            MoveWindow(processes[vmInd].MainWindowHandle, 0, 0, Statics.GAME_WIDTH, Statics.GAME_HEIGHT, true);
        }

        public static int startVMs()
        {
            int p = 0;
            int vmsLeft = Settings.maxVMs - MEmuManager.runningVMs;
            if (MEmuManager.runningVMs < Settings.maxVMs && MEmuManager.runningVMs < MEmuManager.allowedVMs.Count)
            {
                if (MEmuManager.lastVM < MEmuManager.allowedVMs.Count)
                {
                    p = MEmuManager.startVM(MEmuManager.allowedVMs[MEmuManager.lastVM]);
                    MEmuManager.lastVM++;
                    MEmuManager.runningVMs++;
                }
                else
                {
                    MEmuManager.lastVM = 0;
                    p = MEmuManager.startVM(MEmuManager.allowedVMs[MEmuManager.lastVM]);
                    MEmuManager.lastVM++;
                    MEmuManager.runningVMs++;
                }
            }
            return p;
        }

        public static List<List<string>> getMEmuIDs()
        {
            return MEmuManager.vms;
        }

        public static void setAllowedVMs(string vm)
        {
            MEmuManager.allowedVMs.Add(vm);
        }

        public static List<string> getAllowedVMs()
        {
            return MEmuManager.allowedVMs;
        }

        public static void setMaxInstances(int numInstances)
        {
            MEmuManager.instances = new string[numInstances];
            MEmuManager.processes = new Process[numInstances];
            for (int i = 0; i < MEmuManager.instances.Length; i++)
            {
                MEmuManager.instances[i] = null;
                MEmuManager.processes[i] = null;
            }
            Settings.maxVMs = numInstances;
        }

        public static void killVM(int vm)
        {
            Process proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = installPath + "\\nox.exe",
                    Arguments = "-clone:" + MEmuManager.instances[vm],
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            MEmuManager.instances[vm] = null;
            MEmuManager.processes[vm] = null;
            proc.Start();
            MEmuManager.runningVMs--;
        }

        public static void killAll()
        {
            for (int vm = 0; vm < processes.Length; vm++)
            {
                MEmuManager.killVM(vm);
            }
        }

        public static void bringToFront(int vm)
        {
            Process process = MEmuManager.processes[vm];
            IntPtr handle = process.MainWindowHandle;
            if (IsIconic(handle))
            {
                ShowWindow(handle, SW_RESTORE);
            }
            SetForegroundWindow(handle);
        }
    }
}
