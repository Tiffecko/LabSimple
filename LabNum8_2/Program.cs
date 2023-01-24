using System;
using System.IO;
using System.Collections;


public class Bills
{
    public long date;
    public int sum = 0;
    public string transaction;
}
class DateCompare : IComparer
{
    public int Compare(object obj1, object obj2)
    {
        var firstBill = (Bills)obj1;
        var secondBill = (Bills)obj2;
        return firstBill.date.CompareTo(secondBill.date);
    }
}
public class Programm
{
    static void Main()
    {
        Console.Write("Введите дату, используя знак «-» : ");
        string date = Console.ReadLine();
        date = ChangeDate(date);
        int count = 0;
        int sum = 0;
        int length = File.ReadAllLines("C:\\Users\\Axel\\source\\repos\\LabNum8_2\\right.txt").Length - 1;
        Bills[] bills = new Bills[length];
        foreach (string line in File.ReadLines("C:\\Users\\Axel\\source\\repos\\LabNum8_2\\right.txt"))
        {
            if (sum == 0)
            {
                sum = int.Parse(line);
                continue;
            }
            Distribution(line, bills, count);
            count++;
        }
        Sort(bills, new DateCompare());
        Console.WriteLine(CountSum(date, sum, length, bills));
    }

    public static void Sort(Array bills, IComparer comparer)
    {
        for (int i = bills.Length - 1; i > 0; i--)
            for (int j = 1; j <= i; j++)
            {
                object obj1 = bills.GetValue(j - 1);
                object obj2 = bills.GetValue(j);
                if (comparer.Compare(obj1, obj2) < 0)
                {
                    object temporary = bills.GetValue(j);
                    bills.SetValue(bills.GetValue(j - 1), j);
                    bills.SetValue(temporary, j - 1);
                }
            }
    }

    public static void Distribution(string line, Bills[] bills, int count)
    {
        line = ChangeDate(line);
        string[] lines = line.Split('|');
        bills[count] = new Bills();
        if (lines.Length == 3)
        {
            bills[count].date = long.Parse(lines[0]);
            bills[count].sum = int.Parse(lines[1]);
            bills[count].transaction = lines[2];
        }
        else
        {
            bills[count].date = long.Parse(lines[0]);
            bills[count].transaction = lines[1];
        }
    }
    public static string ChangeDate(string date)
    {
        date = date.Replace(":", "");
        date = date.Replace("-", "");
        date = date.Replace(" ", "");
        return date;
    }

    public static object CountSum(string date, int sum, int length, Bills[] bills)
    {
        bool firstTime = false;

        int lastNumber = 0;
        while (sum > 0)
        {
            if (bills[length - 1].date == long.Parse(date)) firstTime = true;
            else if (firstTime && bills[length - 1].date != long.Parse(date)) break;
            if (bills[length - 1].transaction == "in")
            {
                sum += bills[length - 1].sum;
                lastNumber = bills[length - 1].sum;
            }
            if (bills[length - 1].transaction == "out")
            {
                sum -= bills[length - 1].sum;
                lastNumber = bills[length - 1].sum * (-1);
            }
            if (bills[length - 1].transaction == "revert") sum -= lastNumber;
            length--;
        }
        if (sum < 0) return "Exception the amount less than 0";
        else return "amount is " + sum;
    }
}
