using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labs
{
    public static class LabNum1
    {
        public static void Main()
        {
            bool exit = false;

            string lastInput = string.Empty;

            while (!exit)
            {
                string userInput = Console.ReadLine();

                bool userNumberIsDouble;

                if (userInput == "q")
                    exit = true;

                if ((userInput == string.Empty) || (!IsStrNumberCorrect(userInput, out userNumberIsDouble)))
                {
                    Console.WriteLine($"Некорректный ввод");
                    continue;
                }

                if (userNumberIsDouble)
                {
                    if (lastInput != string.Empty && double.Parse(userInput) == double.Parse(lastInput))
                        exit = true;
                    else
                        lastInput = string.Empty;
                }
                else
                {
                    if (int.Parse(userInput) > char.MaxValue || int.Parse(userInput) < char.MinValue)
                        Console.WriteLine("Данное число не может быть выведенно в виде символа юникода");
                    else
                        Console.WriteLine((char)int.Parse(userInput));
                }
                lastInput = userInput;
            }
        }
        private static bool IsStrNumberCorrect(string strNumber, out bool isDouble)
        {
            int positionIndex = 0;

            isDouble = false;

            if (strNumber[0] == '-' && strNumber.Length > 1)
            {
                if (!char.IsDigit(strNumber[0 + 1]))
                    return false;

                positionIndex += 2;
            }

            for (; positionIndex < strNumber.Length; positionIndex++)
                if (!char.IsDigit(strNumber[positionIndex]))
                    if ((strNumber[positionIndex] == ',') && (positionIndex != 0) && ((positionIndex + 1) < strNumber.Length) && !isDouble)
                        isDouble = true;
                    else
                        return false;

            if (isDouble)
                return double.TryParse(strNumber, out _);
            else
                return int.TryParse(strNumber, out _);
        }
    }
}