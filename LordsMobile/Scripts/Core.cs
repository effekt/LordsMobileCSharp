using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsMobile.Scripts
{
    class Core
    {
        public static DateTime mainChecks(State s, int curScreen = -1)
        {
            s.reset();
            Action[] to = new Action[] { () => s.c.vMoveUp(), () => s.c.vMoveRight() };
            Action[] from = new Action[] { () => s.c.vMoveLeft(), () => s.c.vMoveDown() };
            foreach (Action a in to)
            {
                a();
            }

            if (s.v.matchTemplate(Assets.Turf.Infirmary, 0.75).X != -1)
            {
                s.c.vClick(Statics.Screen3.INFIRMARY);
                s.c.vClick(new Point(496, 543));
                s.clearScreen();
            }

            if (s.v.matchTemplate(Assets.Turf.Shelter, 0.65).X != -1)
            {
                s.c.vClick(Statics.Screen3.SHELTER);
                s.c.vClick(new Point(604, 407));
                s.c.vClick(new Point(492, 458));
                s.c.vClick(new Point(731, 355));
                s.c.vClick(new Point(553, 271));
                s.c.vClick(new Point(726, 466));
                s.clearScreen();
            }

            if (s.v.matchTemplate(Assets.Turf.Barracks, 0.7).X != -1)
            {
                s.c.vClick(Statics.Screen3.BARRACKS);
                bool train = false;
                try
                {
                    if (int.Parse(s.v.readText(Statics.Barracks.GRUNT_AMT, true)) < Settings.maxGrunts)
                    {
                        s.c.vClick(Statics.Barracks.GRUNT);
                        train = true;
                    }
                    else if (int.Parse(s.v.readText(Statics.Barracks.ARCHER_AMT, true)) < Settings.maxArchers)
                    {
                        s.c.vClick(Statics.Barracks.ARCHER);
                        train = true;
                    }
                    else if (int.Parse(s.v.readText(Statics.Barracks.CATAPHRACT_AMT, true)) < Settings.maxCataphracts)
                    {
                        s.c.vClick(Statics.Barracks.CATAPHRACT);
                        train = true;
                    }
                    else if (int.Parse(s.v.readText(Statics.Barracks.BALLISTA_AMT, true)) < Settings.maxBallistas)
                    {
                        s.c.vClick(Statics.Barracks.BALLISTA);
                        train = true;
                    }
                } catch(Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }

                if (train)
                {
                    s.c.vClick(Statics.Barracks.TRAIN);
                }
                s.clearScreen();
            }

            foreach (Action a in from)
            {
                a();
            }
            return DateTime.Now;
        }
    }
}
