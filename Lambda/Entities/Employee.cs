using System.Globalization;

namespace Lambda.Entities
{
    class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public Employee(string name, string email, double salary)
        {
            Name = name;
            Email = email;
            Salary = salary;
        }

        public Employee(string csvEmployee)
        {
            string[] vet = csvEmployee.Split(',');

            Name = vet[0];
            Email = vet[1];
            Salary = double.Parse(vet[2], CultureInfo.InvariantCulture);
        }
    }
}
