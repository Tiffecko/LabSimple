using System;


public static class LabNum4
{
    static string[] numbers;

    static void Main()
    {
        Console.WriteLine("Вводите массив чисел ниже через пробел.");
        string str = Console.ReadLine();
        str.Trim();
        numbers = str.Split(' ');

        SpaceEraser();
        OutputArray();
        ChangeElementsInArrayAndWrite();
    }
    static public void SpaceEraser()
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = numbers[i].Trim();
        }
    }
    static public void OutputArray()
    {
        Console.Clear();
        Console.Write("Исходный массив: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i]);
            Console.Write(", ");
        }
    }
    static public int RoundNums(decimal elementDouble)
    {
        decimal result = decimal.Round(elementDouble, 2, MidpointRounding.AwayFromZero);
        result -= (int)(decimal.Round(elementDouble, 2, MidpointRounding.AwayFromZero));
        result *= 100;
        return (int)result;
    }
    static public void ChangeElementsInArrayAndWrite()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.Write("Переработанный массив: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            int elementInt;
            decimal elementDouble;
            if (int.TryParse(numbers[i], out elementInt))
            {
                elementInt = int.Parse(numbers[i]);
                if (elementInt > -1) Console.Write(Factorial(elementInt));
                else Console.Write(elementInt);
                Console.Write(", ");
            }
            else if (decimal.TryParse(numbers[i], out elementDouble))
            {
                elementDouble = decimal.Parse(numbers[i]);
                elementDouble = Math.Abs(elementDouble);
                Console.Write(RoundNums(elementDouble));
                Console.Write(", ");
            }
        }
    }
    static public int Factorial(int elementInt)
    {
        int factorial = 1;
        for (int j = 1; j < elementInt + 1; j++)
        {
            factorial *= j;
        }
        return factorial;
    }
}
