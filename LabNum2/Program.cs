using System;


public class LabNum2
{
    public static void PrintProcesedInput(string userInput, bool userNumbIsNegative)
    {
        userInput = Console.ReadLine();

        if ((userInput == string.Empty) || (!IsStrNumberCorrect(userInput, out userNumbIsNegative)))
        {
            Console.WriteLine("Некорректный ввод!");
            return;
        }
        else
        {
            int indexator = 0;
            int sum = 0;

            if (userNumbIsNegative)
            {
                sum -= userInput[1] - '0';
                indexator += 2;
            }

            for (; indexator < userInput.Length; indexator++)
                sum += userInput[indexator] - '0';

            Console.WriteLine(sum);
        }
    }
    private static bool IsStrNumberCorrect(string strNumber, out bool isNegativeNumber)
    {
        int positionIndex = 0;

        isNegativeNumber = false;

        if (strNumber[0] == '-' && strNumber.Length > 1)
        {
            isNegativeNumber = true;

            if (!char.IsDigit(strNumber[0 + 1]))
                return false;

            positionIndex += 2;
        }

        for (; positionIndex < strNumber.Length; positionIndex++)
            if (!char.IsDigit(strNumber[positionIndex]))
                return false;

        return IsSrtNumberNotOverflow(strNumber, isNegativeNumber);
    }
    private static bool IsSrtNumberNotOverflow(string strNumber, bool numberIsNegative)
    {
        string _tempMinInt;

        if (numberIsNegative)
            _tempMinInt = int.MinValue.ToString();
        else
            _tempMinInt = int.MaxValue.ToString();

        if (_tempMinInt.Length == strNumber.Length)
        {
            for (int i = 1; i < strNumber.Length; i++)
                if (strNumber[i] != _tempMinInt[i])
                    return strNumber[i] < _tempMinInt[i];
        }
        else
        {
            return _tempMinInt.Length > strNumber.Length;
        }

        return true;
    }
}

