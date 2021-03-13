using System;
using System.Collections.Generic;

namespace P03.DetailPrinter
{
    class Program
    {
        static void Main()
        {
            Manager manager = new Manager("Petar", new List<string> { "side note" });
            Manager manager1 = new Manager("Kaloyan", new List<string> { "side note","VAC Ban reports" });

            DetailsPrinter printer = new DetailsPrinter(new List<Employee> { manager, manager1 });
            printer.PrintDetails();
        }
    }
}
