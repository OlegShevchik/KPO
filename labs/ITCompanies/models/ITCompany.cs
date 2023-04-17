using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCompanies.models
{
    internal class ITCompany
    {
        public string? Name { get; private set; }
        public List<Employee> Employees { get; private set; }

        public ITCompany()
        {
            Name = "Google";
            Employees = new List<Employee>();
        }

        public ITCompany(string? name) : this()
        {
            Name = name;
        }

        public ITCompany(ITCompany other)
        {
            Name = other.Name;
            Employees = other.Employees;
        }
        
        public void AddEmployee(Employee employee)
        {
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
