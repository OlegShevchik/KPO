using ITCompanies.models;

namespace ITCompanies.models.employeesTypes
{
    internal class Programmer : Employee
    {
        public string Level { get; private set; }
        public string Field { get; private set; }

        public Programmer() : base()
        {
            Level = "Middle";
            Field = "Back-End";
        }

        public Programmer(string name, decimal salary, string employeeType, string level, string field) : base(name, salary, employeeType)
        {
            Level = level;
            Field = field;
        }

        public new string GetEmployeeInfo()
        {
            return base.GetEmployeeInfo() + $"Уровень: {Level}; Область: {Field}";
        }
    }
}
