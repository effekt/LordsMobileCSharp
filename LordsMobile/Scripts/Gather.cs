using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsMobile.Scripts
{
    class Gather
    {
        private Action[] moves;
        private State state;

        public Gather(State state)
        {
            this.state = state;
            moves = new Action[]
            {
                () => state.c.vMoveLeft(false),
                () => state.c.vMoveUp(false),
                () => state.c.vMoveRight(false),
                () => state.c.vMoveRight(false),
                () => state.c.vMoveDown(false),
                () => state.c.vMoveDown(false),
                () => state.c.vMoveLeft(false),
                () => state.c.vMoveLeft(false),
                () => state.c.vMoveLeft(false),
                () => state.c.vMoveUp(false),
                () => state.c.vMoveUp(false),
                () => state.c.vMoveUp(false),
                () => state.c.vMoveRight(false),
                () => state.c.vMoveRight(false),
                () => state.c.vMoveRight(false),
                () => state.c.vMoveRight(false)
            };
        }

        public int gather(int resource)
        {

            String[] assets = new String[0];
            bool gathering = false;
            switch(resource)
            {
                case 0:
                    assets = Assets.Gather.Field;
                    break;
                case 1:
                    assets = Assets.Gather.Rocks;
                    break;
                case 2:
                    assets = Assets.Gather.Ore;
                    break;
                case 3:
                    assets = Assets.Gather.Wood;
                    break;
                case 4:
                    assets = Assets.Gather.Gold;
                    break;
            }

            state.clearScreen();
            state.goTo(false);
            foreach (Action a in moves)
            {
                for (int i = 1; i < assets.Length; i++)
                {
                    if (state.c.vClick(state.v.matchTemplate(assets[i], 0.25, true)))
                    {
                        if (state.v.matchTemplate(assets[0], 0.7).X != -1 && state.v.matchTemplate(Assets.Gather.GatherRes, 0.7).X != -1)
                        {
                            gathering = true;
                            break;
                        }
                        state.clearScreen();
                    }
                }
                if (gathering)
                    break;

                a();
            }
            state.c.vClick(Statics.Gather.GATHER);
            state.c.vClick(Statics.Gather.ASSEMBLE);
            state.c.vClick(Statics.Gather.START);
            state.goTo();

            return ++resource % 5;
        }
    }
}
