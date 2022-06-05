 
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
     * Complete the 'maxMin' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */

    private static readonly bool debug = false;

    public static int maxMin(int k, List<int> arr)
    {
        if (debug) Console.WriteLine($"k: {k} arr.count: {arr.Count}");
        
        if (debug) Console.WriteLine(string.Join(" ", arr));
        arr.Sort();
        if (debug) Console.WriteLine(string.Join(" ", arr));
        if (debug) Console.WriteLine();
        int ritorno = int.MaxValue;
        
        
        int j=k-1;
        for (int i=0; i<=arr.Count-k; i++)
        {
            int max = arr[j];
            int min = arr[i];
            
            int sub = max-min;
            
            if (debug)
            {
                Console.WriteLine($"I: {i} J: {j} - max: {max} min: {min} - sub: {sub}");
                for (int a = i; a<j; a++)
                {
                    Console.Write($"{arr[a]} ");
                }
                Console.WriteLine("\n");
            }
            
            if (sub < ritorno) ritorno = sub;
            
            
            j++;
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

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
            arr.Add(arrItem);
        }

        int result = Result.maxMin(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
