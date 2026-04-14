// метод внутри метода -- функция
using System;

char[] operators = { '+', '-', '*', '/', '^', 'l' };

void ErrorLog(string text)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\n{text}\n");
    Console.ResetColor();
}

while (true)
{

    Console.WriteLine("Калькулятор:\n");
    string dirtyInput = Console.ReadLine()!;

    string cleanInput = dirtyInput.Replace(" ", "");

    int indexSimbol = cleanInput.IndexOfAny(operators);

    /*if (indexSimbol == -1) пока не нужен, так как добавили логарифм и проверка говно
    {
        ErrorLog("ОШИБКА: НЕ НАЙДЕН ЗНАК ОПЕРАЦИИ");
        continue;
    }*/

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

    // спрашиваем у пользователя, сколько ему нужно нулей после запятой (новый код)
    Console.WriteLine("Укажите, сколько вам гожа знаков после нуля:");
    string requestedZeros = Console.ReadLine()!;

    if (!int.TryParse(requestedZeros, out int intRequestedZeros)) // по идеи _ позволяет не возвращать ничего кроме bool
    {
        ErrorLog("ОШИБКА: ГОВНО");
        continue;
    } 

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
        case 'l':
           result = (float)Math.Log(first, second); break; // натуральный логарифм и синус.
    }

    result = (float)Math.Round(result, intRequestedZeros); // есть 2 параметра. result -- что округляем. requestedZeros -- насколько символов округляем.

    Console.WriteLine($"{result}\n");

}

// уменьшение гнездения.
// уход кода вправо -- плохо.
// 

// многосимвольные операции или операции с одним операндом.
