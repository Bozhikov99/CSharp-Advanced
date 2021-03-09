using System;

namespace _06._Valid_Person
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Student gin4o = new Student("Gin4o", "Gin4o_4@abv.bg");
            }
            catch (InvalidPersonNameException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
