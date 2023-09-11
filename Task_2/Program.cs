// Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

int InputNum(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

int[,] Create2DArray(int rows, int columns)
{
    return new int[rows, columns];
}

void Fill2DArray(int[,] array, int minValue, int maxValue)
{
    Random rnd = new Random();
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = 0; j < array.GetLength(1); j++)
            array[i, j] = rnd.Next(minValue, maxValue + 1);
}

void Print2DArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
            Console.Write($"{array[i, j]}\t");
        Console.WriteLine();
    }
}

// Решил, что метод будет возвращать массив, в который будут записаны суммы элементов всех строк
// Таким образом, если вдруг сумма двух или более строк будут минимальными, будут выведены все

int[] FindMinSumRow(int[,] array)
{
    // + 1 тут чтобы в последнюю ячейку массива записать найденную минимальную сумму
    int[] rowsSums = new int[array.GetLength(0) + 1];
    int minRowSum = 0;

    for (int i = 0; i < array.GetLength(0); i++)
    {
        int rowSum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            rowSum += array[i, j];
        }

        rowsSums[i] = rowSum;

        if (rowSum < minRowSum || i == 0)
        {
            minRowSum = rowSum;
        }
    }

    rowsSums[array.GetLength(0)] = minRowSum;

    return rowsSums;
}

void PrintMinSumsRows(int[] array)
{
    int minSum = array[array.Length - 1];
    Console.WriteLine($"В данном массиве нижеследующие строки имеют минимальную сумму всех элементов равную {minSum}:");

    for (int i = 0; i < array.Length - 1; i++)
    {
        if (array[i] == minSum)
        {
            Console.WriteLine($"{i + 1} Строка");
        }
    }
}

int rows = InputNum("Введите количество строк массива: ");
int columns = InputNum("Введите количество столбцов массива: ");
int minValue = InputNum("Введите минимальное значение элемента: ");
int maxValue = InputNum("Введите максимальное значение элемента: ");
int[,] array = Create2DArray(rows, columns);
Fill2DArray(array, minValue, maxValue);
Console.WriteLine("\nИсходный массив:\n");
Print2DArray(array);
Console.WriteLine();
PrintMinSumsRows(FindMinSumRow(array));
Console.WriteLine();