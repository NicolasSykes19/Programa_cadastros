using System;
using System.Collections.Specialized;
using System.Globalization;
using Aulas_CSHARP.Entities;
using Aulas_CSHARP.Entities.Enums;

namespace Aulas_CSHARP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department1s name: ");
            string depName = Console.ReadLine();
            Console.WriteLine("Enter worker data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel),Console.ReadLine());
            Console.Write("BaseSalary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Departament dept = new Departament(depName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.WriteLine();

            Console.Write("How many contracts to this worker?: ");
            int con = int.Parse(Console.ReadLine());

            Console.WriteLine();

            for (int i=1; i<=con; i++)
            {
                Console.WriteLine();
                Console.WriteLine("Enter #" + i + "contract data: ");
                Console.Write("Date (DD/MM/YY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());
                HourContract contract = new HourContract(date,valuePerHour,hours);
                worker.AddContract(contract);

            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income (MM/YY): ");
            string monthYear = Console.ReadLine();
            int month = int.Parse(monthYear.Substring(0, 2));
            int year = int.Parse(monthYear.Substring(3));
            Console.WriteLine();
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Departament.Name);
            Console.WriteLine("Income for " + monthYear + ":" + worker.Income(year, month));
        }
    }
}
