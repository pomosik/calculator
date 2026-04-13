using System;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {

            char[] simbol = { '+', '-', '*', '/', '^' }; 

            while (true)
            {

                Console.WriteLine("Калькулятор:\n");
                string? dirtyInput = Console.ReadLine(); // ? -- говорим компилятору, что мы в курсе возможного null в input. 

                if (dirtyInput == null) { continue; } // при null возвращаемся в самое начало цикла через continue

                string cleanInput = dirtyInput.Replace(" ", ""); // заменяем(Replace) все строки " ", наш пробел, на ""

                string[] numberOnly = cleanInput.Split(simbol); // разбиваем(Split) строку cleanInput на массив, который ложим в numberOnly

                // проверка и сразу парсинг двух наших чисел
                if (!float.TryParse(numberOnly[0], out float first) || 
                    !float.TryParse(numberOnly[1], out float second)) // если выражение == false, то выполняем внутренний код
                    { 
                        Console.WriteLine("неверный ввод"); 
                        continue; 
                    }

                // финальные вычесления
                float result = 0;
                int index = cleanInput.IndexOfAny(simbol); // создаём переменную, куда вставляем номер ячейки найденного методом знака
                char currentOperator = cleanInput[index]; // теперь в другую переменную ложим наш знак

                switch (currentOperator) // current -- текущий
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
                            Console.WriteLine("На ноль делить нельзя!");
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