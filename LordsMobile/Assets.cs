using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LordsMobile
{
    class Assets
    {
        public class Challenge {
            public const string challenge = "challenge\\";
            public const string Chapter = challenge + "chapter.jpg";
        }

        public class MEmu
        {
            private const string memu = "assets\\memu\\";
            public const string Lords = memu + "lords.jpg";
            public const string Lords2 = memu + "lords2.jpg";
        }

        public class Chest
        {
            private const string chest = "assets\\chest\\";
            public const string x5 = chest + "5x.jpg";
            public const string Collect = chest + "collect.jpg";
            public const string Window = chest + "window.jpg";
        }

        public class Development
        {
            private const string dev = "assets\\dev\\";
            public const string Help = dev + "help.jpg";
            public const string Free = dev + "free.jpg";
            public const string Go = dev + "go.jpg";
            public const string Build = dev + "build.jpg";
            public const string Upgrade = dev + "upgrade.jpg";
            public const string NoCR = dev + "no_cr.jpg";
            public const string NoRes = dev + "no_res.jpg";
            public const string New = dev + "new.jpg";
        }

        public class Tutorial
        {
            private const string tutorial = "assets\\tutorial\\";
            public const string Create = tutorial + "create.jpg";
            public const string Important = tutorial + "important.jpg";
            public const string OathKeeper = tutorial + "oath_keeper.jpg";
            public const string Skirmish1 = tutorial + "skirmish1.jpg";
            public const string Confirm = tutorial + "confirm.jpg";
            public const string TapGo = tutorial + "tap_go.jpg";
            public const string MpFull1 = tutorial + "mp_full1.jpg";
            public const string MpFull2 = tutorial + "mp_full2.jpg";
            public const string MpFull3 = tutorial + "mp_full3.jpg";
            public const string Guild = tutorial + "guild.jpg";
            public const string Migrate = tutorial + "migrate.jpg";
        }

        public class Turf
        {
            private const string turf = "assets\\turf\\";
            public const string Statue = turf + "statue.jpg";
            public const string Statue2 = turf + "statue2.jpg";
            public const string Infirmary = turf + "infirmary.jpg";
            public const string Shelter = turf + "shelter.jpg";
            public const string Barracks = turf + "barracks.jpg";
        }

        public class Etc
        {
            private const string etc = "assets\\etc\\";
            public const string Kingdom = etc + "kingdom.jpg";
            public const string Turf = etc + "turf.jpg";
            public const string Leave = etc + "leave.jpg";
            public const string Oracle = etc + "oracle.jpg"; //0.55
            public const string LevelUp = etc + "level_up.jpg"; //0.85
            public const string LiveSupport = etc + "live_support.jpg";
            public const string Close = etc + "close.jpg"; //0.8
            public const string LevelUpTxt = etc + "level_up_txt.jpg";
        }

        public class Hud
        {
            private const string hud = "assets\\hud\\";
            public const string Army = hud + "army.jpg";
            public const string Help = hud + "help.jpg";
            public const string ExtraSupplies = hud + "extra_supplies.jpg";
        }

        public class Quest
        {
            private const string quest = "assets\\quest\\";
            public const string HasCompleted = quest + "has_completed.jpg";
            public const string HasQuests = quest + "has_quests.jpg";
            public const string Collect = quest + "collect.jpg";
            public const string Start = quest + "start.jpg";
            public const string Admin = quest + "admin_comp.jpg";
            public const string Turf = quest + "turf_comp.jpg";
            public const string Guild = quest + "guild_comp.jpg";
            public const string VIP = quest + "vip_comp.jpg";
            public const string VIPClaim = quest + "vip_claim.jpg";
            public const string VIPChest = quest + "vip_chest.jpg";
        }

        public class Gather
        {
            private const string res = "assets\\res\\";
            public const string GatherRes = res + "gather.jpg";
            public static readonly String[] Field = new String[]
            {
                res + "txt_field.jpg",
                res + "field.jpg"
            };
            public static readonly String[] Rocks = new String[]
            {
                res + "txt_rocks.jpg",
                res + "rocks.jpg"
            };
            public static readonly String[] Ore = new String[]
            {
                res + "txt_ore.jpg",
                res + "ore.jpg",
                res + "ore2.jpg"
            };
            public static readonly String[] Wood = new String[]
            {
                res + "txt_woods.jpg",
                res + "woods.jpg",
                res + "woods2.jpg"
            };
            public static readonly String[] Gold = new String[]
            {
                res + "txt_gold.jpg",
                res + "gold.jpg",
                res + "gold2.jpg"
            };
        }
    }
}
