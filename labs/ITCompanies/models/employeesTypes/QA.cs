using ITCompanies.models;

namespace ITCompanies.models.employeesTypes
{
    internal class QA : Employee
    {
        public string Field { get; private set; }

        public QA() : base()
        {
            Field = "WEB";
        }

        public QA(string name, decimal salary, string employeeType, string field) : base(name, salary, employeeType)
        {
            Field = field;
        }

        public new string GetEmployeeInfo()
        {
            return base.GetEmployeeInfo() + $"Область: {Field}";
        }
    }
}
