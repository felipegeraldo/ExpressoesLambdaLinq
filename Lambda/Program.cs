using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Lambda.Entities;

namespace Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter full file path: ");
            string path = Console.ReadLine();

            Console.Write("Enter salary: ");
            double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            List<Employee> employees = new List<Employee>();

            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        employees.Add(new Employee(sr.ReadLine()));

                    }
                }
                Console.WriteLine();
                Console.WriteLine("Email of people whose salary is more than 2000.00:");
                var emails = employees.Where(p => p.Salary > salary).OrderBy(p => p.Email).Select(p => p.Email);
                foreach (string item in emails)
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine();

                var sum = employees.Where(p => p.Name[0] == 'M').Sum(p => p.Salary);
                Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
                Console.WriteLine();
            }
            catch(IOException e)
            {
                Console.WriteLine("An error ocurred: " + e.Message);
            }
        }
    }
}
