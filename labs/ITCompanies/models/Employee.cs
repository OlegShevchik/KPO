using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.models
{
    internal class Employee : IComparable<Employee>
    {
        public string? Name;
        public decimal Salary;

        public Employee()
        {
            Name = "Иван";
            Salary = 1000;
        }

        public Employee(string? name) : this()
        {
            Name = name;
        }

        public Employee(decimal salary) : this()
        {
            Salary = salary;
        }

        public Employee(string? name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public Employee(Employee other)
        {
            Name = other.Name;
            Salary = other.Salary;
        }

        public int CompareTo(Employee? other)
        {
            return Salary.CompareTo(other?.Salary);
        }

        public string GetEmployeeInfo()
        {
            return $"Name: {Name}; Salary: {Salary} $";
        }
    }
}
