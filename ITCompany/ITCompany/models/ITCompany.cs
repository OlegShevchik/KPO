using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCompanyApplication.models
{
    internal class ITCompany
    {
        public string? Name { get; private set; }

        public List<Employee> Employees { get; private set; }

        public ITCompany(string? name) 
        {
            Name = name;
            Employees = new List<Employee>();
        }

        public void AddEmployee(string name, short salary)
        {
            Employees.Add(new Employee(name, salary));
        }

        public void RemoveEmployee(Employee employee)
        {
            Employees.Remove(employee);
        }

        public string GetCompanyInfo()
        {
            string info = $"Название: {Name}\nКол-во сотрудников: {Employees.Count()}\nСписок сотрудников:\n";
            foreach (var employee in Employees) info += employee.GetEmployeeInfo() + "\n";
            return info;
        }
    }
}
