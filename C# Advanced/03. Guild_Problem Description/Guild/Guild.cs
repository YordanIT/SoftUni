using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;
        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            roster = new List<Player>(capacity);
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => roster.Count;
        public void AddPlayer(Player player)
        {
            if (roster.Count < Capacity)
            {
                roster.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            if (roster.Exists(p => p.Name == name))
            {
                roster.Remove(roster.FirstOrDefault(p => p.Name == name));
                return true;
            }
            return false;
        }
        public void PromotePlayer(string name)
        {
            var player = roster.First(p => p.Name == name);

            if (player.Rank != "Member")
            {
                player.Rank = "Member";
            }
        }
        public void DemotePlayer(string name)
        {
            var player = roster.Find(p => p.Name == name);

            if (player.Rank != "Trial")
            {
                player.Rank = "Trial";
            }
        }
        public Player[] KickPlayersByClass(string _class)
        {
            var kickedPlayers = roster.FindAll(p => p.Class == _class);
            roster.RemoveAll(p => p.Class == _class);

            return kickedPlayers.ToArray();
        }
        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");
            sb.AppendLine(string.Join(Environment.NewLine, roster));

            return sb.ToString().TrimEnd();
        }
    }
}
