// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, 
// которая будет построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int InputNum(string message)
{
    Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}

int[,,] Create3DArray(int height, int width, int length)
{
    return new int[height, width, length];
}

int[] NumbersGenerator()
{
    int[] numbers = new int[90];
    for (int i = 0; i < 90; i++)
        numbers[i] = i + 10;

    Random rnd = new Random();

    for (int i = numbers.Length - 1; i >= 1; i--)
    {
        int j = rnd.Next(i + 1);
        (numbers[j], numbers[i]) = (numbers[i], numbers[j]);
    }
    return numbers;
}

void Fill3DArray(int[,,] array)
{
    int[] numbers = NumbersGenerator();
    int numIndex = 0;
    for (int y = 0; y < array.GetLength(0); y++)
        for (int x = 0; x < array.GetLength(1); x++)
            for (int z = 0; z < array.GetLength(2); z++)
            {
                array[y, x, z] = numbers[numIndex];
                numIndex++;
            }
}

void Print3DArray(int[,,] array)
{
    for (int y = 0; y < array.GetLength(0); y++)
    {
        Console.WriteLine($"{y + 1} Слой массива:");
        for (int x = 0; x < array.GetLength(1); x++)
        {
            for (int z = 0; z < array.GetLength(2); z++)
            {
                Console.Write($"{array[y, x, z]} ({y},{x},{z})\t");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

int length = InputNum("Введите длину массива: ");
int width = InputNum("Введите ширину массива: ");
int height = InputNum("Введите высоту массива: ");
Console.WriteLine();

// А вообще по хорошему надо бы конечно ввести еще проверку на отрицательные числа как минимум
if (3 <= length * width * height && length * width * height <= 90)
{
    int[,,] array = Create3DArray(height, width, length);
    Fill3DArray(array);
    Print3DArray(array);
}
else
{
    Console.WriteLine($"Массив с введенными размерами {length} x {width} x {height} не может быть заполнен случайными не повторяющимися двузначными цифрами\n");
}