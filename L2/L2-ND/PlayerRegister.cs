//PlayerRegister.cs
using System;
using System.Collections.Generic;
using System.Linq;

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
        /// turns the register to a string
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string output = "";

            output += String.Format(
                "Žaidėjų registras: Žaidėjų kiekis: {0}\n",
                this.PlayerCount()
            );

            output += "Visi Žaidėjai: \n";

            foreach (Player p in this.allPlayers)
            {
                output += String.Format(
                    "{0}\n",
                    p.ToString()
                );
            }

            return output;
        }

        /// <summary>
        /// gets the amount of players in the register
        /// </summary>
        /// <returns>the player count</returns>
        public int PlayerCount()
        {
            return this.allPlayers.Count();
        }

        /// <summary>
        /// gets all players that are stored in the register
        /// </summary>
        /// <returns>a list of all players</returns>
        public List<Player> GetAllPlayers()
        {
            return this.allPlayers;
        }

        /// <summary>
        /// get a list of all players who have been invited
        /// </summary>
        /// <returns>a list of players who have been invited</returns>
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
        /// get the tallest player(s) in the register
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
        /// gets a list of all unique clubs from every invited player
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
