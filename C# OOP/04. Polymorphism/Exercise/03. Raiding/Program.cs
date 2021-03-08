using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<BaseHero> raiders = new List<BaseHero>();

            while (raiders.Count < n)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                try
                {
                    BaseHero hero = CharacterCreation(name, type);
                    raiders.Add(hero);
                }
                catch (ArgumentException x)
                {
                    Console.WriteLine(x.Message);
                }
            }

            int bossPower = int.Parse(Console.ReadLine());

            foreach (BaseHero b in raiders)
            {
                Console.WriteLine(b.CastAbility());
                bossPower -= b.Power;
            }

            string output = bossPower <= 0 ? "Victory!" : "Defeat...";
            Console.WriteLine(output);

        }
            public static BaseHero CharacterCreation(string name, string type)
            {
                BaseHero current = null;

                switch (type)
                {
                    case "Paladin":
                        current = new Paladin(name);
                        break;
                    case "Warrior":
                        current = new Warrior(name);
                        break;
                    case "Druid":
                        current = new Druid(name);
                        break;
                    case "Rogue":
                        current = new Rogue(name);
                        break;
                    default:
                        throw new ArgumentException("Invalid hero!");
                }
                return current;
            }
    }
}
