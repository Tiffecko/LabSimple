using System;

public static class LabNum1
{
    public static void Main()
    {
        bool exit = false;

        string lastInput = string.Empty;

        while (!exit)
        {
            string enterNum = Console.ReadLine();
            bool enterNumDouble;

            if (enterNum == "q")
                exit = true;

            if ((enterNum == string.Empty) || (!StrNumCorrect(enterNum, out enterNumDouble)))
            {
                Console.WriteLine("Некорректный ввод!");
                continue;
            }

            if (enterNumDouble)
            {
                if (lastInput != string.Empty && double.Parse(enterNum) == double.Parse(lastInput))
                    exit = true;
                else
                    lastInput = string.Empty;
            }
            else
            {
                if (int.Parse(enterNum) < char.MinValue || int.Parse(enterNum) > char.MaxValue)
                    Console.WriteLine("Число выходит за пределы кодировки Unicode!");
                else
                    Console.WriteLine((char)int.Parse(enterNum));
            }
            lastInput = enterNum;
        }
    }
    private static bool StrNumCorrect(string strNum, out bool isDouble)
    {
        int positionIndex = 0;

        isDouble = false;

        if (strNum[0] == '-' && strNum.Length > 1)
        {
            if (!char.IsDigit(strNum[0 + 1]))
                return false;

            positionIndex += 2;
        }

        if (isDouble)
            return double.TryParse(strNum, out _);
        else
            return int.TryParse(strNum, out _);
    }
}
