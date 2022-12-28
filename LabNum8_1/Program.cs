using System;
using System.IO;
using System.Timers;


public class FileData
{
    public int time1;
    public int time2;
    public string pos;
    public string colour;
    public string word;
}

public class Programm
{
    public int time1;
    public int time2;
    public string pos;
    public string colour;
    public string word;

    static int width = 100;
    static int height = 40;
    static Timer aTimer;
    static int length = File.ReadAllLines("C:\\Users\\Axel\\source\\repos\\LabNum8_1\\times.txt").Length;
    static FileData[] subtitles = new FileData[length];
    static int time = 0;

    static void Main()
    {
        GetInfo();
        DrawScreen();
        TimerSetter();
        Console.ReadKey();
    }
    public static void GetInfo()
    {          
        char[] separators = { '-', '[', ',', ']' };
        int count = 0;
        foreach (var str in File.ReadLines("C:\\Users\\Axel\\source\repos\\LabNum8_1\\times.txt"))
        {
            if (str.Contains('[')) str.Replace(" ", "");
            string[] appartedData = str.Split(separators);
            DataToClass(appartedData, count);
            count++;
        }
    }

    private static void TimerSetter()
    {
        aTimer = new System.Timers.Timer(1000);
        aTimer.Elapsed += OnTimedEvent;
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
    }

    static void OnTimedEvent(Object source, ElapsedEventArgs e)
    {
        foreach (var screenword in subtitles)
        {
            if (screenword.time1 == time) WriteWord(screenword);
            if (screenword.time2 == time) DeleteWord(screenword);
        }
        time++;
    }

    public static void DrawScreen()
    {
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (i == 0 || i == height - 1) Console.Write("*");
                else if (j == 0 || j == width - 1) Console.Write("|");
                else Console.Write(" ");
            }
            Console.WriteLine();
        }
    }

    public static void ChangeColor(string color)
    {
        if (color != null) color = color.Replace(" ", "");
        if (color == "Red") Console.ForegroundColor = ConsoleColor.Red;
        if (color == "Green") Console.ForegroundColor = ConsoleColor.Green;
        if (color == "White") Console.ForegroundColor = ConsoleColor.White;
        if (color == "Blue") Console.ForegroundColor = ConsoleColor.Blue;
    }
    public static void WriteWord(FileData screenword)
    {
        PosChanger(screenword.pos, screenword.word.Length);
        ChangeColor(screenword.colour);
        Console.WriteLine(screenword.word);
    }

    public static void PosChanger(string position, int lengthOfWord)
    {
        switch (position)
        {
            case "Top":
                Console.SetCursorPosition((width - 2 - lengthOfWord) / 2, 1);
                break;
            case "Bottom":
                Console.SetCursorPosition((width - 2 - lengthOfWord) / 2, height - 2);
                break;
            case "Right":
                Console.SetCursorPosition(width - 1 - lengthOfWord, height / 2 - 1);
                break;
            case "Left":
                Console.SetCursorPosition(1, height / 2 - 1);
                break;
            default:
                Console.SetCursorPosition((width - lengthOfWord) / 2, height / 2);
                break;
        }
    }

    public static void DeleteWord(FileData screenword)
    {
        PosChanger(screenword.pos, screenword.word.Length);
        for (int i = 0; i < screenword.word.Length; i++)
        {
            Console.Write(" ");
        }
    }

    public static void DataToClass(string[] appartedData, int count)
    {
        subtitles[count] = new FileData();
        subtitles[count].time1 = int.Parse(appartedData[0].Replace(":", "")) % 100;
        if (appartedData.Length == 2)
        {
            subtitles[count].time2 = int.Parse(appartedData[1].Substring(0, 5).Replace(":", ""));
            subtitles[count].word = appartedData[1].Substring(6);
        }
        else
        {
            subtitles[count].time2 = int.Parse(appartedData[1].Replace(":", "")) % 100;
            subtitles[count].pos = appartedData[2];
            subtitles[count].colour = appartedData[3];
            subtitles[count].word = appartedData[4];
        }
    }
}
