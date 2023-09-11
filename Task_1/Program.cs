// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

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

void SortRowsArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)    // Этот цикл бежит по столбцам
    {
        for (int j = 0; j < array.GetLength(1) - 1; j++)   // Два следующих цикла бегут по строке сортируя её (усовершенствованный пузырёк)
        {
            bool flag = true;
            int max = j;
            for (int k = 0; k < array.GetLength(1) - 1 - j; k++)
            {
                if (array[i, k] < array[i, k + 1])
                {
                    (array[i, k], array[i, k + 1]) = (array[i, k + 1], array[i, k]);
                    flag = false;
                }
                if (array[i, k] > array[i, max])
                    max = k;
            }
            if (flag)
                break;
            if (max > j)
                (array[i, j], array[i, max]) = (array[i, max], array[i, j]);
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
Console.WriteLine("\nИзменённый массив:\n");
SortRowsArray(array);
Print2DArray(array);
Console.WriteLine();