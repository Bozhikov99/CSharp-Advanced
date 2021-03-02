using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FootballTeamGenerator
{
    public class Team
    {
        public Team(string name)
        {
            Name = name;
            squad = new Dictionary<string, Player>();
        }
        private string name;
        private int playerCount;
        private Dictionary<string, Player> squad = new Dictionary<string, Player>();

        public string Name
        {
            get => name;
            private set
            {
                Validator.ThrowEmptyName(value, "A name should not be empty.");
                name = value;
            }
        }

        public double Rating
        {
            get
            {
                if (squad.Count==0)
                {
                    return 0;
                }
               return Math.Round(squad.Values.Average(p => p.Overall));
            }
        }

        public void AddPlayer(Player player)
        {
            playerCount++;
            squad.Add(player.Name, player);
        }

        public void RemovePlayer(string player)
        {
            if (!squad.ContainsKey(player))
            {
                Console.WriteLine($"Player {player} is not in {Name} team.");
            }
            else
            {
                playerCount--;
                squad.Remove(player);
            }
        }
    }
}
