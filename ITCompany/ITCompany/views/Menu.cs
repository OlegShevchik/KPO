using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITCompanyApplication.views
{
    internal static class Menu
    {
        public static void ShowMenu()
        {
            ConsoleOutput.WriteLine("---------------Menu---------------\n1. Создать IT компанию\n2. Выбрать существующую компанию" +
                "\n3. Выход", ConsoleColor.Cyan);
            ConsoleOutput.Write("Ваш выбор: ", ConsoleColor.Cyan);
        }

        public static void ShowActionsWithCompany(string? companyName)
        {
            ConsoleOutput.WriteLine($"---------------{companyName}---------------\n1. Информация о компании\n2. Общий фонд з/п\n" +
                $"3. Сотрудники с максимальной з/п\n4. Сотрудники с минимальной з/п\n5. Добавить сотрудника\n6. Уволить сотрудника\n" +
                $"7. Вернуться в главное меню\n", ConsoleColor.Cyan);
            ConsoleOutput.Write("Ваш выбор: ", ConsoleColor.Cyan);
        }
    }
}
