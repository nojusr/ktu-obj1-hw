using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2_ND
{
    class PlayerRegister
    {
        private List<Player> allPlayers;

        public PlayerRegister(List<Player> players)
        {
            this.allPlayers = players;
        }

        /// <summary>
        /// gets the amount of players in the register
        /// </summary>
        /// <returns>a number lol</returns>
        public int PlayerCount()
        {
            return this.allPlayers.Count();
        }

        public List<Player> GetInvitedPlayers()
        {
            List<Player> output = new List<Player>();

            foreach (Player player in this.allPlayers)
            {
                if (player.IsPicked == true)
                {
                    output.Add(player);
                }
            }
            return output;


        }

        /// <summary>
        /// gets a list of the tallest players in the team
        /// </summary>
        /// <returns>a list of the tallest players</returns>
        public List<Player> GetTallestPlayers()
        {

            List<Player> output = new List<Player>();

            foreach (Player player in this.allPlayers)
            {
                if (output.Count == 0)
                {
                    output.Add(player);
                    continue;
                }

                Player playerToCompare = output[0];

                if (player.Height > playerToCompare.Height)
                {
                    output.Clear();
                    output.Add(player);
                }
                else if (player.Height == playerToCompare.Height)
                {
                    output.Add(player);
                }
            }
            return output;
        }


        /// <summary>
        /// gets a list of all of the attackers
        /// </summary>
        /// <returns>a list of all attackers</returns>
        public List<Player> GetAllAttackers()
        {
            List<Player> output = new List<Player>();

            foreach (Player player in this.allPlayers)
            {
                if (player.Position == "Attacker")
                {
                    output.Add(player);
                }
            }
            return output;
        }

        /// <summary>
        /// gets a list of all unique clubs from invited players
        /// </summary>
        /// <returns>a list of strings</returns>
        public List<String> GetUniqueInvitedClubs()
        {
            List<string> output = new List<string>();

            foreach (Player player in this.GetInvitedPlayers())
            {
                string club = player.Club;

                if (output.Contains(club) == false)
                {
                    output.Add(club);
                }
            }

            return output;
        }
    }
}
