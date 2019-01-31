using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LordsMobile.Scripts
{
    class Build
    {
        private State state;
        public Build(State s)
        {
            this.state = s;
        }

        public DateTime build()
        {
            Thread.Sleep(1000);
            state.reset();

            state.c.vClick(Statics.Screen1.CASTLE);

            while(true)
            {
                if (state.c.vClick(state.v.matchTemplate(Assets.Development.Upgrade, 0.7)))
                    Thread.Sleep(500);

                for (int i = 0; i < 3; i++)
                {
                    if (state.c.vClick(state.v.matchTemplate(Assets.Development.Go, 0.7)))
                    {
                        Thread.Sleep(1500);
                        state.c.vClick(new Point(Statics.GAME_MID.X, Statics.GAME_MID.Y + 55));
                        break;
                    }
                    Thread.Sleep(500);
                }
                Point isNew = state.v.matchTemplate(Assets.Development.New, 0.7);
                if (isNew.X != -1)
                {
                    state.c.vClick(new Point(isNew.X + 162, isNew.Y));
                }
                if (state.v.matchTemplate(Assets.Development.NoRes, 0.8).X != -1)
                    return DateTime.Now;

                if (state.v.matchTemplate(Assets.Development.Upgrade, 0.7).X == -1)
                    break;
            }
            state.c.vClick(Statics.Building.BUILD);
            return DateTime.Now.Subtract(DateTime.Now.AddMinutes(5) - DateTime.Now);
        }
    }
}
