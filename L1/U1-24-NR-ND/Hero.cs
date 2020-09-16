using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_24_NR_ND
{
    class Hero
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public string Class { get; set; }
        public int LifePoints { get; set; }
        public int ManaPoints { get; set; }
        public int AtkPoints { get; set; }
        public int DefPoints { get; set; }
        public int StrPoints { get; set; }
        public int SpdPoints { get; set; }
        public int IntPoints { get; set; }
        public string Special { get; set; }

        public Hero(string name, string race, string _class, int lifePoints, int manaPoints, int atkPoints, int defPoints, int strPoints, int spdPoints, int intPoints, string special)
        {
            this.Name = name;
            this.Race = race;
            this.Class = _class;
            this.LifePoints = lifePoints;
            this.ManaPoints = manaPoints;
            this.AtkPoints = atkPoints;
            this.DefPoints = defPoints;
            this.StrPoints = strPoints;
            this.SpdPoints = spdPoints;
            this.IntPoints = intPoints;
            this.Special = special;
        }
    }
}
