using System;
using System.Collections.Generic;

namespace Teamwork_Projects
{
    class Program
    {
        static void Main(string[] args)
        {
            int countTeam = int.Parse(Console.ReadLine());
            string line = Console.ReadLine();
            List<Team> teams = new List<Team>();
            while (line != "end of assignment")
            {
                
                if (line.Contains("->"))
                {

                }
                else
                {
                    Team team = new Team();
                    team.Creator = line.Split("-")[0];

                }
                line = Console.ReadLine();
            }
        }
    }
    class Team
    {
        public string Creator { get; set; }
        public List<string> Members { get; set; } = new List<string>();
        public string TeamName { get; set; }
        public override string ToString()
        {
            string a = $"{TeamName}" + Environment.NewLine + $"-{Creator}";
            foreach (string member in Members)
            {
                a += Environment.NewLine + $"--{member}";
            }
            return a;
        }

    }
}
