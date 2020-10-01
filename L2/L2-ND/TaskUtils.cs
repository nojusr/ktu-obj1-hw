//IOUtils.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2_ND
{
    class TaskUtils
    {
        /// <summary>
        /// gets a list of the oldest players in the team
        /// </summary>
        /// <param name="input">a list of players</param>
        /// <returns>a list of the oldest players</returns>
        public static List<Player> FindOldestPlayers(List<Player> input)
        {
            List<Player> output = new List<Player>();

            foreach (Player player in input)
            {
                if (output.Count == 0)
                {
                    output.Add(player);
                    continue;
                }

                Player playerToCompare = output[0];

                if (player.Age > playerToCompare.Age)
                {
                    output.Clear();
                    output.Add(player);
                }
                else if (player.Age == playerToCompare.Age)
                {
                    output.Add(player);
                }
            }
            return output;
        }


        /// <summary>
        /// gets a list of all of the attackers
        /// </summary>
        /// <param name="input">a list of players</param>
        /// <returns>a list of all attackers</returns>
        public static List<Player> FindAllAttackers(List<Player> input)
        {
            List<Player> output = new List<Player>();

            foreach (Player player in input)
            {
                if (player.Position == "Attacker") {
                    output.Add(player);
                }
            }
            return output;
        }

        /// <summary>
        /// gets a list of all invited players
        /// </summary>
        /// <param name="input">a list of players</param>
        /// <returns>a list of all invited players</returns>
        public static List<Player> FindAllInvitedPlayers(List<Player> input)
        {
            List<Player> output = new List<Player>();

            foreach (Player player in input)
            {
                if (player.IsPicked == true) {
                    output.Add(player);
                }
            }
            return output;
        }

    }
}
