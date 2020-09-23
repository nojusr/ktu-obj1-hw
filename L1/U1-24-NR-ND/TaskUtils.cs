//TaskUtils.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace U1_24_NR_ND
{
    class TaskUtils
    {
        public static List<Hero> FindHeroesWithHighestHealth(List<Hero> input)
        {
            List<Hero> output = new List<Hero>();

            foreach (Hero hero in input)
            {
                if (output.Count == 0)
                {
                    output.Add(hero);
                    continue;
                }

                Hero heroToCompare = output[0];

                if (hero.LifePoints > heroToCompare.LifePoints)
                {
                    output.Clear();
                    output.Add(hero);
                }
                else if (hero.LifePoints == heroToCompare.LifePoints)
                {
                    output.Add(hero);
                }

            }


            return output;
        }

        // a method that finds all heroes with the smallest difference between
        // their atkPoints and defPoints
        public static List<Hero> FindHeroesWithSmallestDifference(List<Hero> input)
        {
            List<Hero> output = new List<Hero>();

            foreach (Hero hero in input)
            {
                if (output.Count == 0)
                {
                    output.Add(hero);
                    continue;
                }

                Hero heroToCompare = output[0];

                int aDiff = Math.Abs(hero.AtkPoints-hero.DefPoints);
                int bDiff = Math.Abs(heroToCompare.AtkPoints - heroToCompare.DefPoints);

                if (aDiff < bDiff)
                {
                    output.Clear();
                    output.Add(hero);
                }
                else if (aDiff == bDiff)
                {
                    output.Add(hero);
                }

            }

            return output;
        }

        public static List<String> FindUniqueClasses(List<Hero> input)
        {
            List<String> output = new List<String>();

            foreach (Hero hero in input)
            {
                if (!output.Contains(hero.Class))
                {
                    output.Add(hero.Class);
                }
            }

            return output;
        }
    }
}
