//Program.cs
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2_ND
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Player> allPlayers = new List<Player>();

            allPlayers.AddRange(IOUtils.ReadPlayersFromFile("2020-krepsininkai.csv"));
            allPlayers.AddRange(IOUtils.ReadPlayersFromFile("2019-krepsininkai.csv"));

            PlayerRegister reg = new PlayerRegister(allPlayers);
            
            // print out all players
            Console.WriteLine("Visi Žaidėjai: ");
            Console.Write(reg.ToString());

            // get and print out all attackers
            List<Player> allAttackers = reg.GetAllAttackers();
            Console.WriteLine("Visi puolėjai:");
            IOUtils.PrintCondensedPlayersWithHeight(allAttackers);

            // get and print out the tallest player(s)
            List<Player> tallestPlayers = reg.GetTallestPlayers();
            Console.WriteLine("Aukščiausi žaidėjai:");
            IOUtils.PrintCondensedPlayersWithHeight(tallestPlayers);

            // write all unique clubs to a file
            List<string> uniqueClubs = reg.GetUniqueInvitedClubs();
            IOUtils.OutputStringListToCSV("Klubai.csv", uniqueClubs);
        }
    }
}
