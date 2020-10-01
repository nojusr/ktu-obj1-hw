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
            List<Player> allPlayers = IOUtils.ReadPlayers(@"krepsininkai.csv");

            IOUtils.PrintPlayers(allPlayers);

            List<Player> oldestPlayers = TaskUtils.FindOldestPlayers(allPlayers);
            Console.WriteLine("Seniausi žaidėjai:");
            IOUtils.PrintCondensedPlayersWithAge(oldestPlayers);


            List<Player> allAttackers = TaskUtils.FindAllAttackers(allPlayers);
            Console.WriteLine("Visi puolėjai:");
            IOUtils.PrintCondensedPlayersWithHeight(allAttackers);

            List<Player> invitedPlayers = TaskUtils.FindAllInvitedPlayers(allPlayers);
            IOUtils.OutputPlayersToCSV(@"Rinktine.csv", invitedPlayers);
        }
    }
}
