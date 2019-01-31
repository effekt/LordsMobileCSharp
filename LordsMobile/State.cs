using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LordsMobile
{
    class State
    {
        public string state;
        public int account;
        public DateTime start;
        public int processIndex;
        public Profile profile;
        public int screen = -1;
        public DateTime lastShelterCheck;
        public int lastResource = 0;
        public IntPtr hwnd;
        public Vision v;
        public Controller c;
        
        public State(IntPtr hwnd)
        {
            this.hwnd = hwnd;
            this.start = DateTime.Now;
            this.profile = new Profile(this);
            this.v = new Vision(this.hwnd);
            this.c = new Controller(this.hwnd);
            this.state = "Loading";
        }

        public bool hasTimeElapsed()
        {
            return DateTime.Now > start.AddMinutes(Settings.duration);
        }

        public void clearScreen()
        {
            Debug.WriteLine("Stuck in clear");
            if (v.matchTemplate(Assets.Etc.Oracle, 0.55).X != -1)
            {
                Debug.WriteLine("In oracle");
                Thread.Sleep(500);
                this.c.vClick(Statics.GAME_MID);
                clearScreen();
            }

            if (v.matchTemplate(Assets.Etc.Close, 0.65).X != -1)
            {
                Debug.WriteLine(v.matchTemplate(Assets.Etc.Close, 0.65));
                this.c.vClick(v.matchTemplate(Assets.Etc.Close, 0.65));
                Debug.WriteLine("Stuck in close");
                Thread.Sleep(500);
                clearScreen();
            }
        }

        public void reset()
        {
            Thread.Sleep(1000);
            clearScreen();
            goTo();
            Action[] actions = new Action[]
            {
                () => this.c.vMoveDown(false),
                () => this.c.vMoveDown(false),
                () => this.c.vMoveDown(false),
                () => this.c.vMoveLeft(false),
                () => this.c.vMoveLeft(false),
                () => this.c.vMoveLeft(false),
                () => this.c.vMoveLeft(false),
                () => this.c.vMoveLeft(false),
                () => this.c.vMoveLeft(false),
                () => this.c.vMoveLeft(false),
                () => this.c.vMoveRight(false),
                () => this.c.vMoveRight(false),
                () => this.c.vMoveRight(false)
            };

            if (!this.c.vClick(v.matchTemplate(Assets.Turf.Statue, 0.5)) &&
                !this.c.vClick(v.matchTemplate(Assets.Turf.Statue2, 0.5)))
            {
                foreach (Action a in actions)
                {
                    a();
                    if (this.c.vClick(v.matchTemplate(Assets.Turf.Statue, 0.5)) ||
                        this.c.vClick(v.matchTemplate(Assets.Turf.Statue2, 0.5)))
                    {
                        break;
                    }
                    clearScreen();
                }
            }
            Thread.Sleep(4500);
            clearScreen();
            Thread.Sleep(4500);
        }

        public void goTo(bool turf = true)
        {
            Thread.Sleep(1000);
            if (turf == true)
            {
                if (this.c.vClick(v.matchTemplate(Assets.Etc.Turf, 0.7)))
                    Thread.Sleep(4000);
            }
            else
            {
                if (this.c.vClick(v.matchTemplate(Assets.Etc.Kingdom, 0.7)))
                    Thread.Sleep(4000);
            }
        }
    }
}
