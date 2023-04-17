using ITCompanies.models;
using ITCompanies.models.employeesTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCompanies.views
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

        public static Dictionary<string, string?> AddNewEmployee(out string? employeeType)
        {
            var employee = new Dictionary<string, string?>();

            Console.Write("Введите имя сотрудика: ");
            employee.Add("Name", Console.ReadLine());

            Console.Write("Введите зарплату сотрудника: ");
            employee.Add("Salary", Console.ReadLine());

            Console.Write("Введите тип сотрудника (программист, менеджер, тестировщик): ");
            employeeType = Console.ReadLine();

            if (employeeType == "программист")
            {
                Console.Write("Введите уровень программиста (Junior, Middle, Senior): ");
                employee.Add("Level", Console.ReadLine());

                Console.Write("Введите область программиста (например Back-End): ");
                employee.Add("Field", Console.ReadLine());
            }
            else if (employeeType == "менеджер")
            {
                Console.Write("Введите тип менеджера (например проектный): ");
                employee.Add("Type", Console.ReadLine());
            }
            else if (employeeType == "тестировщик")
            {
                Console.Write("Введите область тестировщика (например WEB): ");
                employee.Add("Field", Console.ReadLine());
            }

            Console.WriteLine();

            return employee;
        }

        public static void ShowEmployeesInfo(ITCompany company)
        {
            Console.WriteLine("Информация о сотрудниках компании: ");
            foreach (var employee in company.Employees)
            {
                if (employee.EmployeeType == "программист") Console.WriteLine(((Programmer)employee).GetEmployeeInfo());
                else if (employee.EmployeeType == "менеджер") Console.WriteLine(((Manager)employee).GetEmployeeInfo());
                else if (employee.EmployeeType == "тестировщик") Console.WriteLine(((QA)employee).GetEmployeeInfo());
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

            if (maxSalaryEmployee != null)
            {
                Console.WriteLine("Сотрудник с максимальной зарплатой: ");
                if (maxSalaryEmployee.EmployeeType == "программист") Console.Write(((Programmer)maxSalaryEmployee).GetEmployeeInfo());
                else if (maxSalaryEmployee.EmployeeType == "менеджер") Console.Write(((Manager)maxSalaryEmployee).GetEmployeeInfo());
                else if (maxSalaryEmployee.EmployeeType == "тестировщик") Console.Write(((QA)maxSalaryEmployee).GetEmployeeInfo());
                Console.WriteLine();
            }
            else Console.WriteLine($"Невозможно найти такого сотрудника!\n");

        }

        public static void ShowMinSalaryEmployee(ITCompany company)
        {
            var minSalaryEmployee = company.GetMinSalaryEmployee();

            if (minSalaryEmployee != null)
            {
                Console.WriteLine("Сотрудник с минимальной зарплатой: ");
                if (minSalaryEmployee.EmployeeType == "программист") Console.Write(((Programmer)minSalaryEmployee).GetEmployeeInfo());
                else if (minSalaryEmployee.EmployeeType == "менеджер") Console.Write(((Manager)minSalaryEmployee).GetEmployeeInfo());
                else if (minSalaryEmployee.EmployeeType == "тестировщик") Console.Write(((QA)minSalaryEmployee).GetEmployeeInfo());
                Console.WriteLine();
            }
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
