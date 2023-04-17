using lab1.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1.controllers
{
    internal static class UserInputController
    {
        public static bool IsSalaryOutOfRange(decimal salary)
        {
            if (salary < 0) throw new ArgumentOutOfRangeException("Значение не может быть отрицательным!");
            return true;
        }

        public static void IsCompanyExist(string? name, ref List<ITCompany> companies, out ITCompany company)
        {
            foreach (var c in companies)
            {
                if (c.Name == name)
                {
                    company = c;
                    return;
                }
            }
            throw new ArgumentException("Такой компании нет в списке!");
        }
    }
}
