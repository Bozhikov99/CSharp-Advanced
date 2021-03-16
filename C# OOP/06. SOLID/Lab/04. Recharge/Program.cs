namespace P04.Recharge
{
    using System;

    class Program
    {
        static void Main()
        {
            Employee employee = new Employee("18061017");
            employee.Work(8);

            Robot stancho = new Robot("0013", 30);
            stancho.Recharge();
            stancho.Work(8);
            stancho.Work(8);
            stancho.Work(8);
            stancho.Work(8);
            
        }
    }
}
