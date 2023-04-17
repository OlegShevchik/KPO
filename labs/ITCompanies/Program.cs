using ITCompanies.models;
using ITCompanies.views;
using ITCompanies.controllers;
using ITCompanies.models.employeesTypes;


var companies = new List<ITCompany>();
ITCompany? currentCompany = null;

while (true)
{
    Menu.ShowMain();
    var userAction = Menu.GetAction();

    switch (userAction)
    {
        case "1":
            {
                var newCompanyInfo = Menu.CreateNewCompany();
                ITCompany newCompany = new ITCompany(newCompanyInfo["Name"]);
                companies.Add(newCompany);
                Menu.ShowSuccess("Компания создана!\n");
                break;
            }

        case "2":
            {
                var currentName = Menu.GetCurrentCompany();

                try
                {
                    UserInputController.IsCompanyExist(currentName, ref companies, out currentCompany);
                    Menu.ShowSuccess("Компания найдена и выставлена как текущая!");

                    // Меню компании
                    bool continueAddMenu = true;

                    while (continueAddMenu)
                    {
                        Menu.ShowAdditional(currentCompany.Name);
                        userAction = Menu.GetAction();

                        switch (userAction)
                        {
                            case "1":
                                {
                                    try
                                    {
                                        string? employeeType;
                                        var employeeInfo = Menu.AddNewEmployee(out employeeType);
                                        UserInputController.IsEmployeeTypeCorrect(employeeType);

                                        Employee? newEmployee = null;

                                        var name = employeeInfo["Name"];
                                        var salary = decimal.Parse(employeeInfo["Salary"]);
                                        UserInputController.IsSalaryOutOfRange(salary);

                                        if (employeeType == "программист")
                                        {
                                            var level = employeeInfo["Level"];
                                            var field = employeeInfo["Field"];

                                            newEmployee = new Programmer(name, salary, employeeType, level, field);
                                        }
                                        else if (employeeType == "менеджер")
                                        {
                                            var type = employeeInfo["Type"];

                                            newEmployee = new Manager(name, salary, employeeType, type);
                                        }
                                        else if (employeeType == "тестировщик")
                                        {
                                            var field = employeeInfo["Field"];

                                            newEmployee = new QA(name, salary, employeeType, field);
                                        }

                                        currentCompany.AddEmployee(newEmployee);

                                        Menu.ShowSuccess("Сотрудник добавлен!");
                                    }
                                    catch (Exception ex)
                                    {
                                        Menu.ShowError(ex.Message);
                                    }
                                    break;
                                }

                            case "2":
                                {
                                    Menu.ShowEmployeesInfo(currentCompany);
                                    break;
                                }

                            case "3":
                                {
                                    Menu.ShowGeneralPayroll(currentCompany);
                                    break;
                                }
                            case "4":
                                {
                                    Menu.ShowMaxSalaryEmployee(currentCompany);
                                    break;
                                }

                            case "5":
                                {
                                    Menu.ShowMinSalaryEmployee(currentCompany);
                                    break;
                                }

                            case "6":
                                {
                                    continueAddMenu = false;
                                    break;
                                }
                        }
                    }
                }
                catch (ArgumentException ex)
                {
                    Menu.ShowError(ex.Message);
                }
                break;
            }

        case "3":
            {
                Environment.Exit(0);
                break;
            }
    }
}
