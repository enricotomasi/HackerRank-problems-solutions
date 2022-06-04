 
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
     * Complete the 'candies' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr
     */


    public static long candies(int n, List<int> arr)
    {


        int[] numeri = new int[arr.Count];

        numeri[0]=1;

        for (int i=1; i< arr.Count; i++)
        {
            numeri[i] =1;
            if (arr[i] > arr[i-1])
                numeri[i] = numeri[i-1]+1;
            
        }

        for (int i=arr.Count-1; i>0; i--)
        {
            if (arr[i] < arr[i-1])
            {
                numeri[i-1] = Math.Max(numeri[i-1], numeri[i]+1);
            }

        }

        long ritorno = 0;
        for (int i=0; i<numeri.Count(); i++)
        {
            ritorno+=numeri[i];
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

        List<int> arr = new List<int>();

        for (int i = 0; i < n; i++)
        {
            int arrItem = Convert.ToInt32(Console.ReadLine().Trim());
            arr.Add(arrItem);
        }

        long result = Result.candies(n, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
