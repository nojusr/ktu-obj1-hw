//PlayerRegister.cs
using System;
using System.Collections.Generic;
using System.Linq;

namespace L2_ND
{
    class PlayerRegister
    {
        /// <summary>
        /// the main list of players to be manipulated in the register
        /// </summary>
        private List<Player> allPlayers;

        /// <summary>
        /// constructor method with a player list as an argument
        /// creates a new list of players and adds the argument to the register's list
        /// </summary>
        /// <param name="players">a list of players</param>
        public PlayerRegister(List<Player> players)
        {
            if (this.allPlayers == null)
            {
                this.allPlayers = new List<Player>();
            }

            this.allPlayers.AddRange(players);
        }

        /// <summary>
        /// constructor method without any arguments -- creates an empty list of players in the register
        /// </summary>
        public PlayerRegister()
        {
            this.allPlayers = new List<Player>();
        }

        /// <summary>
        /// adds a list of players to this register's player list
        /// </summary>
        /// <param name="playersToAdd">a list of players</param>
        public void AddRange(List<Player> playersToAdd)
        {
            this.allPlayers.AddRange(playersToAdd);
        }

        /// <summary>
        /// get a player by index
        /// </summary>
        /// <param name="index">an index number</param>
        /// <returns>a Player object</returns>
        public Player GetPlayer(int index)
        {
            return this.allPlayers[index];
        }

        /// <summary>
        /// adds a player to this register's all players
        /// </summary>
        /// <param name="player">the player to add</param>
        public void Add(Player player)
        {
            this.allPlayers.Add(player);
        }


        /// <summary>
        /// turns the register to a string
        /// </summary>
        /// <returns>a string that describes the data held in the register</returns>
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
        /// gets a list of players by their year
        /// </summary>
        /// <returns>a list of players</returns>
        public List<Player> GetPlayersByYear(int year)
        {
            return this.allPlayers.Where((Player p) => p.startDate.Year == year).ToList();
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

                if (player > playerToCompare)
                {
                    output.Clear();
                    output.Add(player);
                }
                else if (player == playerToCompare)
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
