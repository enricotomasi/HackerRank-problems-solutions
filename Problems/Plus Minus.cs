using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'plusMinus' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void plusMinus(List<int> arr)
    {
        int positivi = 0;
        int negativi = 0;
        int zeri = 0;
        
        foreach (int x in arr)
        {
            if (x > 0) positivi++;
            if (x < 0) negativi++;
            if (x == 0) zeri++;
        }
        
        // Console.WriteLine($"{positivi} {negativi} {zeri}");
        
        double totale = positivi + negativi + zeri;
        // Console.WriteLine(totale);
        // Console.WriteLine($"{positivi} / {totale}");
        
        
        double pos = Convert.ToDouble(positivi) / totale;
        double neg = Convert.ToDouble(negativi) / totale;
        double zer = Convert.ToDouble(zeri) / totale;
        
        Console.WriteLine(Math.Round(pos,6).ToString("0.000000"));
        Console.WriteLine(Math.Round(neg,6).ToString("0.000000"));
        Console.WriteLine(Math.Round(zer,6).ToString("0.000000"));
        
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.plusMinus(arr);
    }
}
