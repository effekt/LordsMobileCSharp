using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LordsMobile.Scripts
{
    class Tutorial
    {
        State s;

        public Tutorial(State s)
        {
            this.s = s;
        }
        public void doTutorial()
        {
            if (!hasTutorial())
                return;

            //Bot.states[Bot.currentVM].state = "Doing tutorial";

            if (!stage1())
                return;

            if (!stage2())
                return;

            if (!stage3())
                return;

            if (!stage4())
                return;

            if (!stage5())
                return;

            if (!stage6())
                return;

            if (!stage7())
                return;
        }

        public bool hasTutorial()
        {
            while (s.v.matchTemplate(Assets.Tutorial.Important, 0.45).X == -1 && s.v.matchTemplate(Assets.Etc.Close, 0.55).X == -1) {
                Thread.Sleep(500);
            }
            return s.v.matchTemplate(Assets.Tutorial.Important, 0.45).X != -1;
        }

        public bool stage1()
        {
            while (s.v.matchTemplate(Assets.Tutorial.Important, 0.65).X == -1 && s.v.matchTemplate(Assets.Tutorial.OathKeeper, 0.65).X == -1)
            {
                s.c.vClick(new Point(12, 275));
                Thread.Sleep(350);
            }
            if (s.v.matchTemplate(Assets.Tutorial.Important, 0.65).X != -1)
                s.c.vClick(Statics.Tutorial.AGREE);
            return true;
        }

        public bool stage2()
        {
            while (s.v.matchTemplate(Assets.Tutorial.TapGo, 0.45).X == -1)
            {
                s.c.vClick(Statics.GAME_MID);
                Thread.Sleep(350);
            }
            Thread.Sleep(500);
            return true;
        }

        public bool stage3()
        {
            s.c.vClick(Statics.Tutorial.BUILD_BARRACKS);
            Thread.Sleep(2000);
            s.c.vClick(Statics.Tutorial.BUILD_BARRACKS2);
            Thread.Sleep(2000);
            s.c.vClick(Statics.Tutorial.BUILD_BARRACKS3);
            Thread.Sleep(2000);
            s.c.vClick(Statics.Building.BUILD);
            Thread.Sleep(2000);
            s.c.vClick(Statics.Tutorial.FREE_SPEED);
            Thread.Sleep(2000);
            s.c.vClick(Statics.Tutorial.BUILD_BARRACKS5);
            Thread.Sleep(2000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(2000);
            return true;
        }

        public bool stage4()
        {
            Debug.WriteLine("Stage 4");
            s.c.vClick(new Point(414, 472));
            Thread.Sleep(2000);
            s.c.vClick(new Point(414, 472));
            Thread.Sleep(2000);
            s.c.vClick(Statics.Tutorial.BUILD_CASTLE);
            Thread.Sleep(3000);
            s.c.vClick(Statics.Tutorial.BUILD_CASTLE2);
            Thread.Sleep(3500);
            s.c.vClick(Statics.Building.BUILD);
            Thread.Sleep(3000);
            s.c.vClick(Statics.Building.BUILD);
            Thread.Sleep(3000);
            s.c.vClick(Statics.Tutorial.FREE_SPEED);
            Thread.Sleep(3000);
            s.c.vClick(Statics.Tutorial.BUILD_CASTLE3);
            Thread.Sleep(3000);
            s.c.vClick(Statics.Tutorial.BUILD_CASTLE4);
            Thread.Sleep(3000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(2000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(3000);
            s.c.vClick(Statics.Tutorial.CLOSE_VIP);
            Thread.Sleep(3000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(3000);
            return true;

            //Debug.WriteLine("Stage 4");
            //s.c.vClick(Statics.Tutorial.BUILD_CASTLE);
            //Thread.Sleep(3000);
            //s.c.vClick(Statics.Tutorial.BUILD_CASTLE2);
            //Thread.Sleep(3000);
            //s.c.vClick(Statics.Building.BUILD);
            //Thread.Sleep(3000);
            //s.c.vClick(Statics.Building.BUILD);
            //Thread.Sleep(3000);
            //s.c.vClick(Statics.Tutorial.FREE_SPEED);
            //Thread.Sleep(3000);
            //s.c.vClick(Statics.Tutorial.BUILD_CASTLE3);
            //Thread.Sleep(3000);
            //s.c.vClick(Statics.Tutorial.BUILD_CASTLE4);
            //Thread.Sleep(3000);
            //s.c.vClick(Statics.GAME_MID);
            //Thread.Sleep(2000);
            //s.c.vClick(Statics.GAME_MID);
            //Thread.Sleep(3000);
            //s.c.vClick(Statics.Tutorial.CLOSE_VIP);
            //Thread.Sleep(3000);
            //s.c.vClick(Statics.GAME_MID);
            //Thread.Sleep(3000);
            //return true;
        }

        public bool stage5()
        {
            s.c.vClick(Statics.Tutorial.GO_TRAIN_BALLISTA);
            Thread.Sleep(2000);
            s.c.vClick(Statics.Tutorial.BUILD_BARRACKS2);
            Thread.Sleep(3500);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(50);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(2000);
            s.c.vClick(Statics.Barracks.BALLISTA);
            Thread.Sleep(2000);
            s.c.vClick(Statics.Barracks.TRAIN);
            Thread.Sleep(2000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(2000);
            s.c.vClick(Statics.CLOSE_MAIN);
            Thread.Sleep(2000);
            while (s.v.matchTemplate(Assets.Tutorial.Skirmish1, 0.65).X == -1)
            {
                Thread.Sleep(500);
            }
            return true;
        }

        public bool stage6()
        {
            s.c.vClick(Statics.Tutorial.GO_SKIRMISH1);
            while (s.v.matchTemplate(Assets.Tutorial.Confirm, 0.8).X == -1)
            {
                Thread.Sleep(500);
            }
            s.c.vClick(s.v.matchTemplate(Assets.Tutorial.Confirm, 0.8));
            Thread.Sleep(1000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Tutorial.CASTLE_SKIRMISH1);
            Thread.Sleep(2000);
            s.c.vClick(Statics.Tutorial.SCOUT_SKIRMISH1);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Tutorial.BATTLETIPS_SKIRMISH1);
            Thread.Sleep(1000);
            s.c.vClick(Statics.CLOSE_MAIN);
            Thread.Sleep(1000);
            s.c.vClick(new Point(564, 410));
            Thread.Sleep(1000);
            s.c.vClick(new Point(375, 157));
            Thread.Sleep(1000);
            s.c.vClick(new Point(375, 376));
            Thread.Sleep(1000);
            s.c.vClick(new Point(718, 464));
            Thread.Sleep(3000);
            s.c.vClick(Statics.GAME_MID);
            while (s.v.matchTemplate(Assets.Etc.Leave, 0.65).X == -1)
            {
                s.c.vClick(Statics.GAME_MID);
                Thread.Sleep(500);
            }
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Leave, 0.65));
            Thread.Sleep(1000);
            while (s.v.matchTemplate(Assets.Tutorial.Confirm, 0.65).X == -1)
            {
                Thread.Sleep(500);
            }
            s.c.vClick(s.v.matchTemplate(Assets.Tutorial.Confirm, 0.65));
            Thread.Sleep(2000);
            s.c.vClick(new Point(784, 175));
            s.c.vClick(new Point(653, 68));
            s.c.vClick(new Point(653, 68));
            s.c.vMoveLeft();
            s.c.vMoveUp();
            Thread.Sleep(1500);
            s.c.vClick(new Point(166, 232));
            Thread.Sleep(1000);
            while (s.v.matchTemplate(Assets.Tutorial.Confirm, 0.65).X == -1)
            {
                Thread.Sleep(500);
            }
            s.c.vClick(s.v.matchTemplate(Assets.Tutorial.Confirm, 0.65));

            //Skirmish 2
            s.c.vClick(new Point(596, 339));
            s.c.vClick(new Point(567, 409));
            s.c.vClick(new Point(729, 464));
            Thread.Sleep(3000);
            while (s.v.matchTemplate(Assets.Etc.Leave, 0.65).X == -1)
            {
                s.c.vClick(Statics.GAME_MID);
                Thread.Sleep(500);
            }
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Leave, 0.65));
            Thread.Sleep(3000);
            s.c.vClick(new Point(596, 339));
            s.c.vClick(new Point(567, 409));
            s.c.vClick(new Point(729, 464));
            Thread.Sleep(3000);
            while (s.v.matchTemplate(Assets.Etc.Leave, 0.65).X == -1)
            {
                s.c.vClick(Statics.GAME_MID);
                Thread.Sleep(500);
            }
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Leave, 0.65));
            Thread.Sleep(1000);
            while (s.v.matchTemplate(Assets.Tutorial.Confirm, 0.65).X == -1)
            {
                Thread.Sleep(250);
            }
            s.c.vClick(s.v.matchTemplate(Assets.Tutorial.Confirm, 0.65));
            Thread.Sleep(1000);
            s.c.vClick(new Point(787, 112));
            Thread.Sleep(1000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1000);
            s.c.vClick(new Point(144, 106));
            Thread.Sleep(1500);
            s.c.vClick(new Point(489, 259));
            while (s.v.matchTemplate(Assets.Tutorial.Confirm, 0.65).X == -1)
            {
                Thread.Sleep(250);
            }
            s.c.vClick(s.v.matchTemplate(Assets.Tutorial.Confirm, 0.65));

            //Statue Quest
            Thread.Sleep(3500);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1500);
            s.c.vClick(new Point(443, 218));
            Thread.Sleep(1500);
            s.c.vClick(new Point(861, 479));
            Thread.Sleep(1500);
            s.c.vClick(new Point(200, 382));
            Thread.Sleep(1500);
            s.c.vClick(new Point(283, 383));
            Thread.Sleep(1500);
            s.c.vClick(new Point(751, 437));
            Thread.Sleep(2500);
            s.c.vClick(Statics.GAME_MID);

            while (s.v.matchTemplate(Assets.Tutorial.MpFull1, 0.65).X == -1)
            {
                s.c.vClick(Statics.GAME_MID);
                Thread.Sleep(500);
            }
            s.c.vClick(new Point(397, 496));
            Thread.Sleep(1000);

            while (s.v.matchTemplate(Assets.Tutorial.MpFull2, 0.65).X == -1)
            {
                s.c.vClick(Statics.GAME_MID);
                Thread.Sleep(500);
            }
            s.c.vDragMouse(new Point(495, 486), new Point(622, 225));
            Thread.Sleep(1000);

            while (s.v.matchTemplate(Assets.Tutorial.MpFull3, 0.65).X == -1)
            {
                Thread.Sleep(500);
            }
            s.c.vDragMouse(new Point(398, 497), new Point(679, 196));
            Thread.Sleep(1000);

            while (s.v.matchTemplate(Assets.Etc.Leave, 0.65).X == -1)
            {
                s.c.vClick(Statics.GAME_MID);
                Thread.Sleep(500);
            }
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Leave, 0.65));
            Thread.Sleep(15000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1000);
            s.c.vClick(new Point(866, 540));
            Thread.Sleep(1000);
            s.c.vClick(new Point(217, 186));
            Thread.Sleep(1000);
            s.c.vClick(new Point(559, 192));
            Thread.Sleep(1000);
            s.c.vClick(new Point(637, 387));
            Thread.Sleep(1000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1000);
            s.c.vClick(new Point(628, 265));
            Thread.Sleep(1000);
            s.c.vClick(new Point(637, 371));
            Thread.Sleep(1000);
            s.c.vClick(new Point(746, 374));
            Thread.Sleep(1000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1000);
            s.c.vClick(Statics.CLOSE_MAIN);
            Thread.Sleep(1000);
            s.c.vClick(Statics.CLOSE_MAIN);
            Thread.Sleep(1000);
            s.c.vClick(new Point(652, 66));
            Thread.Sleep(1000);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
            Thread.Sleep(1000);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
            Thread.Sleep(4000);
            s.c.vClick(new Point(242, 340));
            Thread.Sleep(1000);
            s.c.vClick(new Point(482, 153));
            Thread.Sleep(1000);
            s.c.vClick(new Point(741, 521));
            Thread.Sleep(1000);
            s.c.vClick(new Point(302, 167));
            Thread.Sleep(1000);

            //Disable Turf quests
            s.c.vClick(new Point(698, 540));
            Thread.Sleep(1000);
            s.c.vClick(new Point(487, 311));
            Thread.Sleep(1000);
            s.c.vClick(new Point(734, 193));
            Thread.Sleep(1000);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
            Thread.Sleep(500);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
            Thread.Sleep(1500);

            //First research
            s.c.vClick(new Point(252, 317));
            Thread.Sleep(1000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1000);
            s.c.vClick(new Point(561, 281));
            Thread.Sleep(1000);
            s.c.vClick(new Point(490, 207));
            Thread.Sleep(1000);
            s.c.vClick(new Point(488, 489));
            Thread.Sleep(1000);
            s.c.vClick(new Point(737, 519));
            Thread.Sleep(1000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1000);
            s.c.vClick(new Point(303, 212));
            Thread.Sleep(1000);

            //Upgrade castle
            s.c.vClick(Statics.Screen1.WALL);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Building.BUILD);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Building.BUILD);
            Thread.Sleep(2500);
            s.c.vClick(new Point(306, 212));
            Thread.Sleep(2500);
            s.c.vClick(Statics.Screen1.CASTLE);
            Thread.Sleep(2500);
            s.c.vClick(Statics.Building.BUILD);
            Thread.Sleep(2500);
            s.c.vClick(Statics.Building.BUILD);
            Thread.Sleep(2500);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(2500);
            s.c.vClick(new Point(297, 212));
            Thread.Sleep(2500);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(2500);
            s.c.vClick(new Point(692, 209));
            Thread.Sleep(2500);
            s.c.vClick(new Point(560, 331));
            Thread.Sleep(2500);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));

            //Build first 4 resources
            s.c.vClick(Statics.Screen1.TILE_1);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Building.LUMBER_MILL);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Building.BUILD);
            Thread.Sleep(1000);
            s.c.vClick(new Point(300, 213));
            Thread.Sleep(1000);
            s.c.vClick(Statics.Screen1.TILE_2);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Building.QUARRY);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Building.BUILD);
            Thread.Sleep(1000);
            s.c.vClick(new Point(300, 213));
            Thread.Sleep(1000);
            s.c.vClick(Statics.Screen1.TILE_3);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Building.MINES);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Building.BUILD);
            Thread.Sleep(1000);
            s.c.vClick(new Point(300, 213));
            Thread.Sleep(1000);
            s.c.vClick(Statics.Screen1.TILE_4);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Building.FARM);
            Thread.Sleep(1000);
            s.c.vClick(Statics.Building.BUILD);
            Thread.Sleep(1000);
            s.c.vClick(new Point(300, 213));
            Thread.Sleep(1000);
            //s.c.vClick(Statics.GAME_MID);
            //Thread.Sleep(2000);

            //Skirmish 3
            s.c.vMoveUp();
            Thread.Sleep(2000);
            s.c.vMoveRight();
            Thread.Sleep(2000);
            s.c.vMoveRight();
            Thread.Sleep(2000);
            s.c.vMoveRight();
            Thread.Sleep(2000);
            s.c.vClick(new Point(832, 300));
            Thread.Sleep(6500);
            s.c.vClick(new Point(600, 434));
            Thread.Sleep(1500);

            for (int i = 0; i < 3; i++)
            {
                s.c.vClick(new Point(535, 308));
                Thread.Sleep(1000);
                s.c.vClick(new Point(561, 407));
                Thread.Sleep(1000);
                s.c.vClick(new Point(724, 465));
                while (s.v.matchTemplate(Assets.Etc.Leave, 0.65).X == -1)
                {
                    s.c.vClick(Statics.GAME_MID);
                    Thread.Sleep(500);
                }
                s.c.vClick(s.v.matchTemplate(Assets.Etc.Leave, 0.65));
                Thread.Sleep(10000);
            }
            s.c.vClick(new Point(595, 437));
            Thread.Sleep(1000);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
            Thread.Sleep(1500);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
            Thread.Sleep(3000);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
            Thread.Sleep(3000);

            ////Skirmish 4
            //s.c.vClick(new Point(195, 561));
            //Thread.Sleep(7500);
            //s.c.vClick(new Point(598, 440));
            //Thread.Sleep(2000);
            //s.c.vClick(new Point(561, 292)); //Castle
            //Thread.Sleep(2000);
            //s.c.vClick(new Point(557, 410)); //Attack
            //Thread.Sleep(2000);
            ////s.c.vClick(new Point(723, 360)); //Auto-Assemble
            ////Thread.Sleep(2000);
            //s.c.vClick(new Point(719, 472)); //Attack
            //Thread.Sleep(2000);
            //s.c.vClick(new Point(564, 285)); //Attack Anyway
            //Thread.Sleep(3500);
            //while (s.v.matchTemplate(Assets.Etc.Leave, 0.65).X == -1)
            //{
            //    s.c.vClick(Statics.GAME_MID);
            //    Thread.Sleep(500);
            //}
            //s.c.vClick(s.v.matchTemplate(Assets.Etc.Leave, 0.65));
            //Thread.Sleep(7000);






            return true;
        }

        public bool stage7()
        {
            //Create name
            Random rnd = new Random();
            int pow = 13 - Settings.namePrefix.Length > 7 ? 7 : 13 - Settings.namePrefix.Length;
            int nameNum = rnd.Next(1, int.Parse(Math.Pow(10, pow).ToString()) - 1);
            string name = Settings.namePrefix + nameNum.ToString();
            s.c.vClick(new Point(511, 56));
            Thread.Sleep(1000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1000);
            s.c.vClick(new Point(432, 281));
            Thread.Sleep(800);
            s.c.vType(name);
            Thread.Sleep(1000);
            s.c.vClick(new Point(490, 389));
            Thread.Sleep(1500);
            s.c.vClick(new Point(490, 389));
            Thread.Sleep(1500);

            //Join guild
            s.c.vClick(Statics.Hud.GUILD);
            Thread.Sleep(1000);
            s.c.vClick(new Point(606, 396));
            Thread.Sleep(1000);
            s.c.vClick(new Point(283, 164));
            Thread.Sleep(1000);
            s.c.vType(Settings.guildName);
            Thread.Sleep(1500);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1500);
            s.c.vClick(new Point(575, 154));
            Thread.Sleep(1000);
            s.c.vClick(new Point(746, 273));
            Thread.Sleep(1500);
            s.c.vClick(new Point(476, 535));
            Thread.Sleep(1000);
            s.c.vClick(new Point(750, 154));
            Thread.Sleep(2000);
            Point guildLoc = s.v.matchTemplate(Assets.Tutorial.Guild, 0.65);
            s.c.vClick(new Point(guildLoc.X + 510, guildLoc.Y));
            Thread.Sleep(1000);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
            Thread.Sleep(500);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
            Thread.Sleep(1500);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Kingdom, 0.75));
            Thread.Sleep(2500);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1000);
            s.c.vClick(Statics.GAME_MID);
            Thread.Sleep(1000);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Turf, 0.75));
            Thread.Sleep(2500);
            s.c.vClick(s.v.matchTemplate(Assets.Etc.Kingdom, 0.75));
            Thread.Sleep(2500);

            //Relocate
            while (true)
            {
                s.c.vClick(new Point(468, 103));
                s.c.vClick(new Point(394, 228));
                for (int i = 0; i < Settings.hiveCoordK.Length; i++)
                {
                    s.c.clickNumpad(int.Parse(Settings.hiveCoordK[i].ToString()));
                }
                s.c.clickNumpad(-1);
                Thread.Sleep(1500);
                s.c.vClick(new Point(496, 231));
                Settings.hiveCoordX = (int.Parse(Settings.hiveCoordX) + (rnd.Next(0, 20) * (rnd.Next(0, 2) * 2 - 1))).ToString();
                for (int i = 0; i < Settings.hiveCoordX.Length; i++)
                {
                    s.c.clickNumpad(int.Parse(Settings.hiveCoordX[i].ToString()));
                }
                s.c.clickNumpad(-1);
                Thread.Sleep(1500);
                s.c.vClick(new Point(596, 231));
                Settings.hiveCoordY = (int.Parse(Settings.hiveCoordY) + (rnd.Next(0, 20) * (rnd.Next(0, 2) * 2 - 1))).ToString();
                for (int i = 0; i < Settings.hiveCoordY.Length; i++)
                {
                    s.c.clickNumpad(int.Parse(Settings.hiveCoordY[i].ToString()));
                }
                s.c.clickNumpad(-1);
                Thread.Sleep(1500);
                s.c.vClick(new Point(494, 318));

                Thread.Sleep(4000);
                s.c.vClick(new Point(491, 307));
                Thread.Sleep(1000);
                if (s.c.vClick(s.v.matchTemplate(Assets.Tutorial.Migrate, 0.8)))
                {
                    Thread.Sleep(1000);
                    s.c.vClick(new Point(486, 437));
                    Thread.Sleep(1000);
                    s.c.vClick(new Point(564, 296));
                    Thread.Sleep(2000);
                    break;
                }
                else
                {
                    s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
                    Thread.Sleep(1000);
                    s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
                    Thread.Sleep(1000);
                    s.c.vClick(s.v.matchTemplate(Assets.Etc.Close, 0.55));
                    Thread.Sleep(1000);
                }
            }
            
            return true;
        }
    }
}
