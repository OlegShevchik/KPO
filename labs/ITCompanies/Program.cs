using lab1.models;
using lab1.views;
using lab1.controllers;


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
                ITCompany newCompany = new ITCompany();
                newCompany.Name = newCompanyInfo["Name"];
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
                                        var employeeInfo = Menu.AddNewEmployee();
                                        var name = employeeInfo["Name"];
                                        var salary = decimal.Parse(employeeInfo["Salary"]);
                                        UserInputController.IsSalaryOutOfRange(salary);

                                        currentCompany.AddEmployee(name, salary);

                                        Menu.ShowSuccess("Сотрудник добавлен!");
                                    }
                                    catch (ArgumentOutOfRangeException ex)
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
