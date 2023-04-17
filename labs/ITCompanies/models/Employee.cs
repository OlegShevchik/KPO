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
