// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

// | 00  01  02 |   | 00  01  02 |   | (00*00 + 01*10 + 02*20)  (00*01 + 01*11 + 02*21)  (00*02 + 01*12 + 02*22) |
// | 10  11  12 | X | 10  11  12 | = | (10*00 + 11*10 + 12*20)  (10*01 + 11*11 + 12*21)  (10*02 + 11*12 + 12*22) |
// | 20  21  22 |   | 20  21  22 |   | (20*00 + 21*10 + 22*20)  (20*01 + 21*11 + 22*21)  (20*02 + 21*12 + 22*22) |

int[,] MatrixMultiply(int[,] matrix1, int[,] matrix2)
{
    int[,] result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];

    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            int element = 0;
            for (int k = 0; k < matrix1.GetLength(1); k++)
            {
                element += matrix1[i, k] * matrix2[k, j];
            }
            result[i, j] = element;
        }
    }
    return result;
}

bool CheckMatrix(int[,] matrix1, int[,] matrix2)
{
    return matrix1.GetLength(1) == matrix2.GetLength(0);
}

int rows1 = InputNum("Введите количество строк 1-ой матрицы: ");
int columns1 = InputNum("Введите количество столбцов 1-ой матрицы: ");
int rows2 = InputNum("Введите количество строк 2-ой матрицы: ");
int columns2 = InputNum("Введите количество столбцов 2-ой матрицы: ");
int minValue = InputNum("Введите минимальное значение элемента: ");
int maxValue = InputNum("Введите максимальное значение элемента: ");
int[,] matrix1 = Create2DArray(rows1, columns1);
int[,] matrix2 = Create2DArray(rows2, columns2);
Fill2DArray(matrix1, minValue, maxValue);
Fill2DArray(matrix2, minValue, maxValue);
Console.WriteLine("\nМатрица 1:\n");
Print2DArray(matrix1);
Console.WriteLine("\nМатрица 2:\n");
Print2DArray(matrix2);
Console.WriteLine();

// Да здесь можно было просто сравнить columns1 c row2, но мне захотелось заморочаться с ещё одной функцией, т.к. мне кажется так больше универсальности
if (CheckMatrix(matrix1, matrix2))
{
    int[,] result = MatrixMultiply(matrix1, matrix2);
    Console.WriteLine("Произведение матриц равно: \n");
    Print2DArray(result);
    Console.WriteLine();
}
else
{
    Console.WriteLine("Данные матрицы невозможно перемножить.\n");
}