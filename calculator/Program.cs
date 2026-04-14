// Вечером попробую добавить в это чудо классы.

using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] operators = { '+', '-', '*', '/', '^' }; 
            
            void ErrorLog(string text) // добавил прикольный метод
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{text}\n");
                Console.ResetColor();
            } 

            while (true)
            {

                Console.WriteLine("Калькулятор:\n");
                string? dirtyInput = Console.ReadLine(); // ? -- говорим компилятору, что мы в курсе возможного null в input. 

                // проверка на null и пустой ввод
                if (dirtyInput == null)
                {
                    ErrorLog("ОШИБКА: null");
                    continue;
                }

                if (dirtyInput.Trim() == "") // .Trim -- срезает пробелы по бокам
                {
                    ErrorLog("ОШИБКА: пустой ввод");
                    continue;
                }


                string cleanInput = dirtyInput.Replace(" ", ""); // заменяем(Replace) все строки " ", наш пробел, на ""

                // обновление. получаем first и second через индексы
                int indexSimbol = cleanInput.IndexOfAny(operators); // находим индекс знака

                if (indexSimbol == -1) 
                { 
                    ErrorLog("ОШИБКА: НЕ НАЙДЕН ЗНАК ОПЕРАЦИИ"); 
                    continue;
                }

                int firstStart = 0;
                int secondStart = indexSimbol + 1;
                
                int firstLength = indexSimbol;
                int secondLength = cleanInput.Length - secondStart;

                string firstStr = cleanInput.Substring(firstStart, firstLength);
                string secondStr = cleanInput.Substring(secondStart, secondLength);

                // проверка и сразу парсинг двух наших чисел
                if (!float.TryParse(firstStr, out float first) || 
                    !float.TryParse(secondStr, out float second))
                    { 
                        ErrorLog("ОШИБКА: НЕВЕРНЫЙ ФОРМАТ ЧИСЛА"); 
                        continue; 
                    }

                // финальные вычесления
                float result = 0;
                char currentOperator = cleanInput[indexSimbol]; // теперь в другую переменную ложим наш знак

                switch (currentOperator) // currentOperator -- текущийОператор
                {
                    case '+':
                        result = first + second; break;
                    case '-':
                        result = first - second; break;
                    case '*':
                        result = first * second; break;
                    case '/':
                        if (second == 0)
                        {
                            ErrorLog("ОШИБКА: ДЕЛЕНИЕ НА НОЛЬ НЕВОЗМОЖНО"); 
                            continue;
                        }
                        result = first / second; break;
                    case '^':
                        result = (float)Math.Pow(first, second); break; // автоматически Math.Pow работает с типом double
                }

                Console.WriteLine($"{result}\n"); // вывод результата с создание дополнительной пустой строки снизу

            }
        }
    }
}
