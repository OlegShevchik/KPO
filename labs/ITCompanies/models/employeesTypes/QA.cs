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

        public override string GetEmployeeInfo()
        {
            return $"Имя: {Name}; Зарплата: {Salary} $; Тип сотрудника: {EmployeeType}; Область: {Field}";
        }
    }
}
