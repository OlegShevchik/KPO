using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITCompanies.models.employeesTypes;

namespace ITCompanies.models
{
    internal class CompanyGenerator
    {
        private readonly string[] names = new string[] {"Даник", "Олег", "Максим", "Артем", "Павел"};
        private readonly decimal[] salaries = new decimal[] {1000, 500, 2000, 3000, 1500};
        private readonly string[] employeeTypes = new string[] {"программист", "менеджер", "тестировщик"};
        private readonly string[] programmerLevels = new string[] {"Junior", "Middle", "Senior"};
        private readonly string[] programmerFields = new string[] {"Back-End", "Front-End", "Machine Learning", "Data Science"};
        private readonly string[] managerTypes = new string[] {"Проетный", "Продуктный", "Маркетинг", "Качество"};
        private readonly string[] QAFields = new string[] {"Функциональное тестирование", "Нагрузочное тестирование", "Тестирование безопасности"};

        private ITCompany CreateRandomCompany(string companyName)
        {
            var randomizer = new Random();

            var newCompany = new ITCompany(companyName);

            int employeesCount = randomizer.Next(1, 4);
            for (int i = 0; i <= employeesCount; i++)
            {
                Employee newEmployee = null;

                var name = names[randomizer.Next(0, names.Count() - 1)];
                var salary = salaries[randomizer.Next(0, salaries.Count() - 1)];
                var employeeType = employeeTypes[randomizer.Next(0, employeeTypes.Count() - 1)];

                if (employeeType == "программист")
                {
                    var level = programmerLevels[randomizer.Next(0, programmerLevels.Count() - 1)];
                    var field = programmerFields[randomizer.Next(0, programmerFields.Count() - 1)];

                    newEmployee = new Programmer(name, salary, employeeType, level, field);
                }
                else if (employeeType == "менеджер")
                {
                    var type = managerTypes[randomizer.Next(0, managerTypes.Count() - 1)];

                    newEmployee = new Manager(name, salary, employeeType, type);
                }
                else if (employeeType == "тестировщик")
                {
                    var field = QAFields[randomizer.Next(0, QAFields.Count() - 1)];

                    newEmployee = new QA(name, salary, employeeType, field);
                }

                newCompany.AddEmployee(newEmployee);
            }

            return newCompany;
        }

        public List<ITCompany> CreateInitCompaniesList()
        {
            List<ITCompany> companies = new();

            for (int i = 1; i <= 5; i++)
            {
                companies.Add(CreateRandomCompany($"New Company {i}"));
            }

            return companies;
        }
    }
}
