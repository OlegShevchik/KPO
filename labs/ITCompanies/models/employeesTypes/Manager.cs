using ITCompanies.models;
using System.Reflection.Emit;

namespace ITCompanies.models.employeesTypes
{
    internal class Manager : Employee
    {
        public string Type { get; private set; }

        public Manager() : base()
        {
            Type = "Project";
        }

        public Manager(string name, decimal salary, string employeeType, string type) : base(name, salary, employeeType)
        {
            Type = type;
        }

        public new string GetEmployeeInfo()
        {
            return base.GetEmployeeInfo() + $"Тип: {Type}";
        }
    }
}
