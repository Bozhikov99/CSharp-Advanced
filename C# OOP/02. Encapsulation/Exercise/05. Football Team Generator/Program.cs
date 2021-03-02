using System;
using System.Collections.Generic;

namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Team> league = new Dictionary<string, Team>();

            string cmd = Console.ReadLine();

            while (cmd != "END")
            {
                //Team;Arsenal
                //Add;Arsenal;Kieran_Gibbs;75;85;84;92;67
                //Remove;Arsenal;Aaron_Ramsey
                //Rating;Arsenal

                string[] tokens = cmd.Split(';');
                string command = tokens[0];
                string teamName = tokens[1];
                try
                {
                    switch (command)
                    {
                        case "Team":
                            league.Add(teamName, new Team(teamName));
                            break;
                        case "Add":
                            if (!league.ContainsKey(teamName))
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                                break;
                            }

                            string playerName = tokens[2];
                            int endurance = int.Parse(tokens[3]);
                            int spring = int.Parse(tokens[4]);
                            int dribble = int.Parse(tokens[5]);
                            int passing = int.Parse(tokens[6]);
                            int shooting = int.Parse(tokens[7]);

                            league[teamName].AddPlayer(new Player(playerName, endurance, spring, dribble, passing, shooting));
                            break;
                        case "Remove":
                            string playerNameRemove = tokens[2];
                            league[teamName].RemovePlayer(playerNameRemove);
                            break;
                        case "Rating":
                            if (!league.ContainsKey(teamName))
                            {
                                Console.WriteLine($"Team {teamName} does not exist.");
                                break;
                            }
                            Console.WriteLine($"{teamName} - {league[teamName].Rating}");
                            break;
                        default:
                            break;
                    }

                }
                catch (ArgumentException x)
                {
                    Console.WriteLine(x.Message);
                }

                cmd = Console.ReadLine();
            }
        }
    }
}
