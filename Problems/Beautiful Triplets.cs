 
//using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
//using System.ComponentModel;
// using System.Diagnostics.CodeAnalysis;
// using System.Globalization;
using System.IO;
using System.Linq;
// using System.Reflection;
// using System.Runtime.Serialization;
// using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'beautifulTriplets' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER d
     *  2. INTEGER_ARRAY arr
     */

    public static int beautifulTriplets(int d, List<int> arr)
    {
        int ritorno = 0;


        //// ------------------------------------------------------------
        //// Funziona ma impiega troppo trempo :(        
        // for (int i = 0; i<arr.Count(); i++)
        // {
        //     for (int j = i+1; j<arr.Count(); j++)
        //     {
        //         for (int k = j+1; k<arr.Count(); k++)
        //         {
        //             if (arr[j]-arr[i] == d && arr[k] - arr[j] == d)
        //             {
        //                ritorno++;
        //             }
        //         }
        //     }
        // }
        ////-------------------------------------------------------------
        
        for (int x=0; x<arr.Count(); x++)
        {
            int y = arr[x];
            if (arr.Contains(y+d) && arr.Contains(y+(2*d))) ritorno++;
        }
                
              
        return ritorno;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.beautifulTriplets(d, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
