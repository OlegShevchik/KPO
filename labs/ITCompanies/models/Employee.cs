using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCompanies.models
{
    internal class Employee : IComparable<Employee>
    {
        public string? Name { get; private set; }
        public decimal Salary { get; private set; }
        public string EmployeeType { get; private set; }

        public Employee()
        {
            Name = "Иван";
            Salary = 1000;
            EmployeeType = "программист";
        }

        public Employee(string? name, decimal salary, string employeeType)
        {
            Name = name;
            Salary = salary;
            EmployeeType = employeeType;
        }

        public Employee(Employee other)
        {
            Name = other.Name;
            Salary = other.Salary;
            EmployeeType = other.EmployeeType;
        }

        public int CompareTo(Employee? other)
        {
            return Salary.CompareTo(other?.Salary);
        }

        public string GetEmployeeInfo()
        {
            return $"Имя: {Name}; Зарплата: {Salary} $; Тип сотрудника: {EmployeeType};";
        }
    }
}
