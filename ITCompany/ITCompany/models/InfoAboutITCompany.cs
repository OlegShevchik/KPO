using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCompanyApplication.models
{
    internal static class InfoAboutITCompany
    {
        public static short GetEmployeeCostSummary(ITCompany company)
        {
            short costs = 0;
            foreach (var employee in company.Employees) costs += employee.Salary;
            return costs;
        }

        public static List<Employee> FindEmployeesWithMaxSalary(ITCompany company)
        {
            var salaries = new List<short>();
            foreach (var employee in company.Employees) salaries.Add(employee.Salary);
            var maxSalary = salaries.Max();
            return company.Employees.Where(e => e.Salary == maxSalary).ToList();
        }

        public static List<Employee> FindEmployeesWithMinSalary(ITCompany company)
        {
            var salaries = new List<short>();
            foreach (var employee in company.Employees) salaries.Add(employee.Salary);
            var minSalary = salaries.Min();
            return company.Employees.Where(e => e.Salary == minSalary).ToList();
        }
    }
}
