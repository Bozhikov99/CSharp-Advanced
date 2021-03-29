using System;

namespace _01._Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            SandwichMenu menu = new SandwichMenu();

            menu["BLT"] = new Sandwich("Wheat", "Bacon", "Lettuce", "Tomato");
            menu["PB&J"] = new Sandwich("White", "Beef", "Iceberg", "Tomato");

            Sandwich sandwich1 = menu["BLT"].Clone() as Sandwich;
            Sandwich sandwich2 = menu["PB&J"].Clone() as Sandwich;
        }
    }
}
