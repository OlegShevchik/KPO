using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCompanyApplication.models
{
    internal class Employee
    {
        public string Name { get; private set; }
        public short Salary { get; private set; }

        public Employee(string name, short salary)
        {
            Name = name;
            Salary = salary;
        }

        public string GetEmployeeInfo()
        {
            return $"Имя: {Name}; З/п: {Salary}";
        }
    }
}
