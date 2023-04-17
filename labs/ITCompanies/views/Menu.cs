using lab1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.views
{
    internal static class Menu
    {
        public static void ShowMain()
        {
            Console.WriteLine("==========MENU==========");
            Console.WriteLine("1. Создать компанию\n2. Выбрать существующую\n3. Выход\n");
        }

        public static void ShowAdditional(string companyName)
        {
            Console.WriteLine($"=========={companyName}==========");
            Console.WriteLine("1. Добавить сотрудника\n2. Вывести информацию о сотрудниках\n3. Общий фонд з/п\n" +
                "4. Сотрудник с максимальной з/п\n5. Сотрудник с минимальной з/п\n6. Выход\n");
        }

        public static string? GetAction()
        {
            Console.Write("Выберите действие: ");
            var result = Console.ReadLine();
            Console.WriteLine();
            return result;
        }

        public static Dictionary<string, string?> CreateNewCompany()
        {
            var company = new Dictionary<string, string?>();

            Console.Write("Введите название компании: ");
            company.Add("Name", Console.ReadLine());
            Console.WriteLine();

            return company;
        }

        public static string? GetCurrentCompany()
        {
            Console.Write("Введите название компании: ");
            var result = Console.ReadLine();
            Console.WriteLine();
            return result;
        }

        public static Dictionary<string, string?> AddNewEmployee()
        {
            var employee = new Dictionary<string, string?>();

            Console.Write("Введите имя сотрудика: ");
            employee.Add("Name", Console.ReadLine());

            Console.Write("Введите зарплату сотрудника: ");
            employee.Add("Salary", Console.ReadLine());

            Console.WriteLine();

            return employee;
        }

        public static void ShowEmployeesInfo(ITCompany company)
        {
            Console.WriteLine("Информация о сотрудниках компании: ");
            foreach (var employee in company.Employees)
            {
                Console.WriteLine(employee.GetEmployeeInfo());
            }
            Console.WriteLine();
        }

        public static void ShowGeneralPayroll(ITCompany company)
        {
            Console.WriteLine($"Общий фонд заработной палты составляет {company.GetGeneralPayroll()} $\n");
        }

        public static void ShowMaxSalaryEmployee(ITCompany company)
        {
            var maxSalaryEmployee = company.GetMaxSalaryEmployee();

            if (maxSalaryEmployee != null) Console.WriteLine($"Сотрудник с максимальной зарплатой: " +
                $"{maxSalaryEmployee.GetEmployeeInfo()}\n");
            else Console.WriteLine($"Невозможно найти такого сотрудника!\n");

        }

        public static void ShowMinSalaryEmployee(ITCompany company)
        {
            var minSalaryEmployee = company.GetMinSalaryEmployee();

            if (minSalaryEmployee != null) Console.WriteLine($"Сотрудник с минимальной зарплатой: " +
                $"{minSalaryEmployee.GetEmployeeInfo()}\n");
            else Console.WriteLine($"Невозможно найти такого сотрудника!\n");
        }

        public static void ShowSuccess(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg + "\n");
            Console.ResetColor();
        }

        public static void ShowError(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg + "\n");
            Console.ResetColor();
        }
    }
}
