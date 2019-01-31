using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using LordsMobile.Scripts;
using System.Drawing;

namespace LordsMobile
{
    class Bot
    {
        private static bool running = false;
        public static State[] states;
        private static Random rnd = new Random();
        private static Thread[] threads;

        public static void start()
        {
            states = new State[Settings.maxVMs];
            threads = new Thread[Settings.maxVMs];
            running = true;
            while (running)
            {
                int s = Array.IndexOf(states, null);
                if (s != -1)
                {
                    int pId = MEmuManager.startVMs();
                    State st = new State(MEmuManager.getHandle(pId));
                    st.processIndex = pId;
                    states[s] = st;
                    threads[s] = new Thread(() => runBot(ref states[s]));
                    threads[s].Start();
                }
                Thread.Sleep(10000);
            }
        }

        private static void runBot(ref State s)
        {
            Tutorial t = new Tutorial(s);
            while(true && running) { 
                while (s.v.matchTemplate(Assets.MEmu.Lords2, 0.8).X == -1 && s.state == "Loading" && running)
                {
                    MEmuManager.resizeWindow(s.processIndex);
                    Debug.WriteLine("Looking for Lords Mobile");
                    Thread.Sleep(2000);
                }
                if (s.c.vClick(s.v.matchTemplate(Assets.MEmu.Lords2, 0.8)))
                    Thread.Sleep(1000);
                if (s.state == "Loading")
                {
                    s.state = "Launching Lords Mobile";
                    while (!t.hasTutorial() && s.v.matchTemplate(Assets.Etc.Close, 0.8).X == -1 && s.v.matchTemplate(Assets.Etc.Oracle, 0.55).X == -1 && running)
                    {
                        Debug.WriteLine("Stuck Launching");
                        Debug.WriteLine(s.processIndex);
                        MEmuManager.resizeWindow(s.processIndex);
                        Thread.Sleep(1500);
                    }
                    Thread.Sleep(1000);
                    if (t.hasTutorial())
                        t.doTutorial();
                }
                Thread.Sleep(2000);
                s.clearScreen();
                if (s.profile.getAccountNo() == "")
                {
                    Debug.WriteLine("Getting profile.");
                    s.state = "Getting Profile";
                    s.profile.getProfile();
                    s.clearScreen();
                    s.reset();
                    s.screen = 1;
                }
                Debug.WriteLine("Outside profile.");

                s.c.vClick(s.v.matchTemplate(Assets.Development.Free, 0.65));
                s.c.vClick(s.v.matchTemplate(Assets.Development.Help, 0.6));
                if (s.c.vClick(s.v.matchTemplate(Assets.Hud.Help, 0.65)))
                {
                    s.c.vClick(new Point(491, 534));
                    s.clearScreen();
                }

                if (s.v.matchTemplate(Assets.Chest.Collect, 0.65).X != -1)
                {
                    s.c.vClick(Statics.Chest.CHEST);
                    s.c.vClick(Statics.Chest.CLAIM);
                }

                if (s.c.vClick(s.v.matchTemplate(Assets.Hud.ExtraSupplies, 0.75)))
                {
                    s.c.vClick(Statics.Hud.EXTRA_SUPPLIES_COLLECT);
                }

                if (DateTime.Now > s.lastShelterCheck.AddMinutes(5))
                    s.lastShelterCheck = Core.mainChecks(s, s.screen);


                /**
                 *  ~~~   Quest Checks   ~~~
                 * 
                 */
                if (s.c.vClick(s.v.matchTemplate(Assets.Quest.HasCompleted, 0.65)) ||
                    s.c.vClick(s.v.matchTemplate(Assets.Quest.HasQuests, 0.65)))
                {
                    if (s.c.vClick(s.v.matchTemplate(Assets.Quest.Turf, 0.61)))
                    {
                        while (s.c.vClick(s.v.matchTemplate(Assets.Quest.Collect, 0.8)))
                        {
                            Debug.WriteLine("Turf");
                            if (s.v.matchTemplate(Assets.Etc.LevelUpTxt, 0.55).X != -1)
                                s.c.vClick(Statics.CLOSE_LEVEL_UP);
                        }
                    }
                    if (s.c.vClick(s.v.matchTemplate(Assets.Quest.Admin, 0.6)))
                    {
                        while (s.c.vClick(s.v.matchTemplate(Assets.Quest.Collect, 0.8)))
                        {
                            Debug.WriteLine("Admin");
                            if (s.v.matchTemplate(Assets.Etc.LevelUpTxt, 0.55).X != -1)
                                s.c.vClick(Statics.CLOSE_LEVEL_UP);
                        }
                        s.c.vClick(s.v.matchTemplate(Assets.Quest.Start, 0.5));
                    }
                    if (s.c.vClick(s.v.matchTemplate(Assets.Quest.Guild, 0.6)))
                    {
                        while (s.c.vClick(s.v.matchTemplate(Assets.Quest.Collect, 0.8)))
                        {
                            Debug.WriteLine("Guild");
                            if (s.v.matchTemplate(Assets.Etc.LevelUpTxt, 0.55).X != -1)
                                s.c.vClick(Statics.CLOSE_LEVEL_UP);
                        }
                        s.c.vClick(s.v.matchTemplate(Assets.Quest.Start, 0.5));
                    }
                    if (s.c.vClick(s.v.matchTemplate(Assets.Quest.VIP, 0.61)))
                    {
                        if (s.v.matchTemplate(Assets.Quest.VIPClaim, 0.7).X != -1)
                            s.c.vClick(s.v.matchTemplate(Assets.Quest.VIPChest, 0.6));
                    }
                }



                s.clearScreen();
                if (s.v.matchTemplate(Assets.Hud.Army, 0.6).X == -1)
                {
                    Gather g = new Gather(s);
                    s.lastResource = g.gather(rnd.Next(0, 5));
                }

                while (s.v.matchTemplate(Assets.Development.NoCR, 0.55).X != -1)
                {
                    s.goTo();
                    Build b = new Build(s);
                    b.build();
                    s.screen = -1;

                    s.c.vClick(s.v.matchTemplate(Assets.Development.Free, 0.65));
                    s.c.vClick(s.v.matchTemplate(Assets.Development.Help, 0.6));
                }

                s.c.vClick(s.v.matchTemplate(Assets.Development.Free, 0.65));
                s.c.vClick(s.v.matchTemplate(Assets.Development.Help, 0.6));

                if (s.v.matchTemplate(Assets.Chest.Collect, 0.65).X != -1)
                {
                    s.c.vClick(Statics.Chest.CHEST);
                    s.c.vClick(Statics.Chest.CLAIM);
                }


                Debug.WriteLine("Start: " + s.start.ToString() + ", End: " + s.start.AddMinutes(Settings.duration).ToString() + ", Done? " + s.hasTimeElapsed());
                Debug.WriteLine("Waiting for time to pass.");
                Thread.Sleep(1000);
            }
        }

        public static void stop()
        {
            foreach (Thread t in threads)
            {
                t.Abort();
            }
            Debug.WriteLine("Stopping!");
            running = false;
        }
    }
}
