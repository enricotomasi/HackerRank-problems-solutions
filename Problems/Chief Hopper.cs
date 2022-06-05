 
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

    // It works, but it's too slow :-((((

    /*
     * Complete the 'chiefHopper' function below.
     *
     * The function is expected to return an INTEGER.        -- Minimum botEnergy
     * The function accepts INTEGER_ARRAY arr as parameter.  -- Building heights
     */
    
    // start from build 0 height 0
    // if botenergy < height --- newEnergy = botEnergy - (height-botEnergy)
    // if botEnergy > height --- newEnergy = botEnergy + (botEnergy-Height)
    

    // internal static readonly bool debug = false;
    // public static int chiefHopper(List<int> arr)
    // {
    //     int i = 0;
    //     while (true)
    //     {
    //         if (debug) Console.WriteLine($"Test energy: {i}");
            
    //         int energy = i;
    //         for (int j=0; j<arr.Count; j++)
    //         {
    //             if (energy<arr[j]) // if botEnergy < height
    //             {
    //                 energy = energy - (arr[j]-energy);                    
    //             }
    //             else // if botenergy > height
    //             {
    //                  energy = energy + (energy - arr[j]);
    //             }

    //             if (energy < 0) break;
    //         }
    //         if (energy >= 0) break;
            
    //         i++;
    //     }
        
    //     return i;
        
    // }


    internal static readonly bool debug = false;
    public static int chiefHopper(List<int> arr)
    {
        int ritorno = 0;
        
        for (int i=arr.Count-1; i>=0; i--)
        {
             ritorno=(arr[i]+ritorno+1)/2;
        }
        
        return ritorno;
    }




}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.chiefHopper(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
