using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LordsMobile
{
    class Profile
    {
        private string accountNo = "";
        private List<Building> buildings = new List<Building>();
        private State s;

        public Profile(State s)
        {
            this.s = s;
        }

        public string getAccountNo()
        {
            return this.accountNo;
        }

        public void getProfile()
        {
            Thread.Sleep(1000);
            s.c.vClick(Statics.Hud.SETTINGS);
            s.c.vClick(Statics.Settings.Account.POINT);
            this.accountNo = s.v.readText(Statics.Settings.Account.ROI);
            Thread.Sleep(500);
            getAccount();
        }

        private void getAccount()
        {
            if (DB.read("SELECT account FROM accounts WHERE account = '" + this.accountNo + "'").HasRows)
                return;
            else
                addAccount();
        }

        private void addAccount()
        {
            DB.insert("INSERT INTO accounts (account) VALUES (" + this.accountNo + ")");
        }

        class Building
        {
            public string Tile;
            public int Level;
            public string Type;
            public Building(string bldg, string tile, int level)
            {
                this.Type = bldg;
                this.Tile = tile;
                this.Level = level;
            }
        }

        class Talent
        {
            public string Type;
            public int Level;
            public Talent(string tlnt, int level)
            {
                this.Type = tlnt;
                this.Level = level;
            }
        }
    }
}
