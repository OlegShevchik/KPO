using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.models
{
    internal class ITCompany
    {
        public string? Name;
        public List<Employee> Employees = new List<Employee>();

        public ITCompany()
        {
            Name = "Google";
        }

        public ITCompany(string? name)
        {
            Name = name;
        }

        public ITCompany(ITCompany other)
        {
            Name = other.Name;
            Employees = other.Employees;
        }
        
        public void AddEmployee(string name, decimal salary)
        {
            Employee employee = new Employee();
            employee.Name = name;
            employee.Salary = salary;

            Employees.Add(employee);
        }

        public decimal GetGeneralPayroll()
        {
            decimal total = 0;
            foreach (var employee in Employees) total += employee.Salary;
            return total;
        }

        public Employee? GetMaxSalaryEmployee()
        {
            return Employees.Max();
        }

        public Employee? GetMinSalaryEmployee()
        {
            return Employees.Min();
        }
    }
}
