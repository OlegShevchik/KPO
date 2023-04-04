using ITCompanyApplication.controllers;
using ITCompanyApplication.models;
using ITCompanyApplication.views;

var companies = new List<ITCompany>();

while (true)
{
    Menu.ShowMenu();
    int userChoice;
    
    if (int.TryParse(Console.ReadLine(), out userChoice) && InputController.IsValueInRange(userChoice, 1, 3))
    {
        switch (userChoice)
        {
            case 1:
                {
                    ConsoleOutput.Write("\nВведите название новой компании: ");
                    string? newCompanyName = Console.ReadLine();
                    companies.Add(new ITCompany(newCompanyName));
                    ConsoleOutput.WriteLine("Компания была добавлена в список!\n", ConsoleColor.Green);
                    break;
                }
            case 2:
                {
                    ConsoleOutput.Write("\nВведите название компании: ");
                    string? existCompanyName = Console.ReadLine();
                    Console.WriteLine();

                    ITCompany? currentCompany;
                    if (InputController.IsCompanyExist(existCompanyName, companies, out currentCompany))
                    {
                        bool a = true;
                        while (a)
                        {
                            Menu.ShowActionsWithCompany(existCompanyName);
                            if (int.TryParse(Console.ReadLine(), out userChoice) && InputController.IsValueInRange(userChoice, 1, 7))
                            {
                                Console.WriteLine();
                                switch (userChoice)
                                {
                                    case 1:
                                        {
                                            ConsoleOutput.WriteLine("\n" + currentCompany.GetCompanyInfo());
                                            break;
                                        }
                                    case 2:
                                        {
                                            if (currentCompany.Employees.Count > 0) ConsoleOutput.WriteLine(InfoAboutITCompany.GetEmployeeCostSummary(currentCompany) + "\n");
                                            else ConsoleOutput.WriteLine("Список сотрудников пуст!\n", ConsoleColor.Red);
                                            break;
                                        }
                                    case 3:
                                        {
                                            if (currentCompany.Employees.Count > 0)
                                            {
                                                foreach (var employee in InfoAboutITCompany.FindEmployeesWithMaxSalary(currentCompany))
                                                {
                                                    ConsoleOutput.WriteLine(employee.GetEmployeeInfo() + "\n");
                                                }
                                            }
                                            else ConsoleOutput.WriteLine("Список сотрудников пуст!\n", ConsoleColor.Red);
                                            break;
                                        }
                                    case 4:
                                        {
                                            if (currentCompany.Employees.Count > 0)
                                            {
                                                foreach (var employee in InfoAboutITCompany.FindEmployeesWithMinSalary(currentCompany))
                                                {
                                                    ConsoleOutput.WriteLine(employee.GetEmployeeInfo() + "\n");
                                                }
                                            }
                                            else ConsoleOutput.WriteLine("Список сотрудников пуст!\n", ConsoleColor.Red);
                                            break;
                                        }
                                    case 5:
                                        {
                                            ConsoleOutput.Write("\nВведите имя нового сотрудника: ");
                                            string? newEmployeeName = Console.ReadLine();

                                            ConsoleOutput.Write("\nВведите з/п нового сотрудника: ");
                                            short newEmployeeSalary;
                                            if (short.TryParse(Console.ReadLine(), out newEmployeeSalary))
                                            {
                                                currentCompany.AddEmployee(newEmployeeName, newEmployeeSalary);
                                                ConsoleOutput.WriteLine("Сотрудник принят в компанию!\n", ConsoleColor.Green);
                                            }
                                            else
                                            {
                                                ConsoleOutput.WriteLine("\nЗначение должно быть с плавающей точкой!\n", ConsoleColor.Red);
                                            }
                                            break;
                                        }
                                    case 6:
                                        {
                                            ConsoleOutput.Write("Введите имя увольняемого сотрудника: ");
                                            string? removedEmployeeName = Console.ReadLine();
                                            Employee employeeToRemove;

                                            if (InputController.IsEmployeeExist(removedEmployeeName, currentCompany.Employees, out employeeToRemove))
                                            {
                                                currentCompany.RemoveEmployee(employeeToRemove);
                                                ConsoleOutput.WriteLine("Сотрудник уволен из компании!\n", ConsoleColor.Green);
                                            }
                                            else
                                            {
                                                ConsoleOutput.WriteLine("\nТакого сотрудника нет в списке!\n", ConsoleColor.Red);
                                            }
                                            break;
                                        }
                                    case 7:
                                        {
                                            a = false;
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                ConsoleOutput.WriteLine("\nЗначение не находится в конкретном диапазоне!", ConsoleColor.Red);
                            }
                        }
                    }
                    else
                    {
                        ConsoleOutput.WriteLine("Такой компании нет в списке!\n", ConsoleColor.Red);
                    }
                    break;
                }
            case 3:
                {
                    Environment.Exit(0);
                    break;
                }
        }
    }
    else
    {
        ConsoleOutput.WriteLine("\nЗначение не находится в конкретном диапазоне!\n", ConsoleColor.Red);
    }
}