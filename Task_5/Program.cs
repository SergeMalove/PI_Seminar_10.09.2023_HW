// Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04    |   00 01 02 03
// 12 13 14 05    |   10 11 12 13
// 11 16 15 06    |   20 21 22 23
// 10 09 08 07    |   30 31 32 33

int InputNum(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

int[,] Create2DArray(int rows, int columns)
{
    return new int[rows, columns];
}

void Fill2DArray(int[,] array)
{
    int number = 1;
    int length = array.GetLength(0);
    int direction = 0;
    int i = 0;
    int j = 0;

    while (number <= array.GetLength(0) + array.GetLength(1))
    {
        switch (direction)
        {
            case 0:
                for (; j < length; j++)
                {
                    array[i, j] = number;
                    number++;
                }
                length--;
                direction = 1;
                break;
            case 1:
                for (; i < length; i++)
                {
                    array[i, j] = number;
                    number++;
                }
                direction = 2;
                break;
            case 2:
                for (; j >= 0; j--)
                {
                    array[i, j] = number;
                    number++;
                }
                direction = 3;
                length--;
                break;
            case 3:
                for (; i >= 0; i--)
                {
                    array[i, j] = number;
                    number++;
                }
                direction = 0;
                break;
        }

    }
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

int[,] array = Create2DArray(4, 4);
Fill2DArray(array);
Print2DArray(array);