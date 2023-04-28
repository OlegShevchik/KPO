using NUnit.Framework;
using ITCompanies.controllers;
using ITCompanies.models;

namespace ITCompanies
{
    [TestFixture]
    internal class Tests
    {
        [TestCase]
        public void Test_IsSalaryOutOfRange()
        {
            Assert.AreEqual(false, UserInputController.IsSalaryOutOfRange(1000));
            Assert.Throws<ArgumentOutOfRangeException>(() => UserInputController.IsSalaryOutOfRange(-1000));
        }

        [TestCase]
        public void Test_IsCompanyExist()
        {
            // Тестовый список компаний
            List<ITCompany> companies = new();
            companies.Add(new ITCompany());

            // Тестирование
            Assert.Throws<ArgumentException>(() => UserInputController.IsCompanyExist("Google", ref companies));
            Assert.DoesNotThrow(() => UserInputController.IsCompanyExist("Microsoft", ref companies));
        }

        [TestCase]
        public void Test_IsEmployeeTypeCorrect()
        {
            Assert.Throws<ArgumentException>(() => UserInputController.IsEmployeeTypeCorrect("программист1234"));
            Assert.DoesNotThrow(() => UserInputController.IsEmployeeTypeCorrect("программист"));
        }
    }
}
