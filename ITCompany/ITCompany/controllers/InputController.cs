using ITCompanyApplication.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCompanyApplication.controllers
{
    internal static class InputController
    {
        public static bool IsValueInRange(int value, int minValue, int maxValue)
        {
            return value >= minValue || value <= maxValue;
        }

        public static bool IsCompanyExist(string? companyName, List<ITCompany> companies, out ITCompany? findedCompany)
        {
            findedCompany = null;
            foreach (var company in companies)
            {
                if (company.Name == companyName)
                {
                    findedCompany = company;
                    break;
                }
            }
            return findedCompany != null;
        }

        public static bool IsEmployeeExist(string? employeeName, List<Employee> employees, out Employee? findedEmployee)
        {
            findedEmployee = null;
            foreach (var employee in employees)
            {
                if (employee.Name == employeeName)
                {
                    findedEmployee = employee;
                    break;
                }
            }
            return findedEmployee != null;
        }
    }
}
