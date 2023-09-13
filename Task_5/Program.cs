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

void Fill2DArray(int[,] array, int turn)
{
    int number = 1;
    int length = array.GetLength(0);
    int height = 0;
    int direction = 0;
    int i = 0;
    int j = 0;

    while (number <= array.GetLength(0) * array.GetLength(1))
    {
        switch (direction)
        {
            case 0:
                for (; j < length; j++)
                {
                    if (turn == 0)
                        array[i, j] = number;
                    else
                        array[j, i] = number;
                    number++;
                }
                direction = 1;
                j--;
                i++;
                break;
            case 1:
                for (; i < length; i++)
                {
                    if (turn == 0)
                        array[i, j] = number;
                    else
                        array[j, i] = number;
                    number++;
                }
                direction = 2;
                i--;
                j--;
                length--;
                break;
            case 2:
                for (; j >= height; j--)
                {
                    if (turn == 0)
                        array[i, j] = number;
                    else
                        array[j, i] = number;
                    number++;
                }
                direction = 3;
                height++;
                i--;
                j++;
                break;
            case 3:
                for (; i >= height; i--)
                {
                    if (turn == 0)
                        array[i, j] = number;
                    else
                        array[j, i] = number;
                    number++;
                }
                direction = 0;
                i++;
                j++;
                break;
        }
    }
}

void Print2DArray(int[,] array)
{
    int length = array.GetLength(0);
    int digits = 0;
    while (length != 0)
    {
        length /= 10;
        digits++;
    }
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]:d2}\t");
        }
        Console.WriteLine();
    }
}

int arraySize = InputNum("Введите размер массива: ");
int turn = InputNum("Введите направление заполнения (0 - почасовой стрелке, 1 - против часовой): ");
int[,] array = Create2DArray(arraySize, arraySize);
Fill2DArray(array, turn);
Print2DArray(array);