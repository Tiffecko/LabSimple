using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    private static void Main(string[] args)
    {
        List<string> array = new List<string> { "code", "doce", "ecod", "framer", "frame", "frame" };
        AnagramBuild(array);
    }

    public static bool AnagramСomparison(string one, string two)
    {
        char[] char1 = one.ToCharArray();
        char[] char2 = two.ToCharArray();

        Array.Sort(char1);
        Array.Sort(char2);
        return (char1 == char2);
    }

    static void AnagramBuild(List<string> reultArray)
    {
        reultArray.Sort();
        for (int i = 0; i < reultArray.Count; i++)
        {
            if (AnagramСomparison(reultArray[i], reultArray[i + 1]))
                reultArray[i + 1] = " ";
            if (reultArray[i] == " ")
                reultArray.Remove(reultArray[i]);
        }
    }
}
