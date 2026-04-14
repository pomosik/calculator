using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] operators = { '+', '-', '*', '/', '^' };
            
            void ErrorLog(string text)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{text}\n");
                Console.ResetColor();
            } 

            while (true)
            {

                Console.WriteLine("Калькулятор:\n");
                string? dirtyInput = Console.ReadLine();

                if (dirtyInput == null)
                {
                    ErrorLog("ОШИБКА: null");
                    continue;
                }
                
                if (dirtyInput.Trim() == "")
                {
                    ErrorLog("ОШИБКА: пустой ввод");
                    continue;
                }

                string cleanInput = dirtyInput.Replace(" ", "")

                int indexSimbol = cleanInput.IndexOfAny(operators);

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

                if (!float.TryParse(firstStr, out float first) || 
                    !float.TryParse(secondStr, out float second))
                    { 
                        ErrorLog("ОШИБКА: НЕВЕРНЫЙ ФОРМАТ ЧИСЛА"); 
                        continue; 
                    }
                
                float result = 0; 
                char currentOperator = cleanInput[indexSimbol];

                switch (currentOperator)
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
                        result = (float)Math.Pow(first, second); break;
                }

                Console.WriteLine($"{result}\n");

            }
        }
    }
}
