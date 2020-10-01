//IOUtils.cs
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
            


            List<Player> allAttackers = reg.GetAllAttackers();
            Console.WriteLine("Visi puolėjai:");
            IOUtils.PrintCondensedPlayersWithHeight(allAttackers);


            List<Player> tallestPlayers = reg.GetTallestPlayers();
            Console.WriteLine("Aukščiausi žaidėjai:");
            IOUtils.PrintCondensedPlayersWithHeight(tallestPlayers);

            List<string> uniqueClubs = reg.GetUniqueInvitedClubs();
            IOUtils.OutputStringListToCSV("Klubai.csv", uniqueClubs);
        }
    }
}
