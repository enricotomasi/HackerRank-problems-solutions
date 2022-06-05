 
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
     * Complete the 'largestPermutation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */

    
     public static List<int> largestPermutation(int maxSwaps, List<int> arr)
    {
       int conta = 0;
       
       var mappa = arr.ToDictionary(first => first, second =>
       {
           int ritorno = conta;
           conta++;
           return ritorno;
       });
       
       int i=0;
       
       while(maxSwaps>0 && i<arr.Count)
       {
           if (arr[i]<arr.Count-i)
           {
               int valore = arr[i];
               int posizione = mappa[arr.Count-i];
               
               arr[posizione] = arr[i];
               arr[i] = arr.Count-i;
               
               mappa[arr.Count-i] = i;
               mappa[valore] = posizione;
               
               maxSwaps--;
           }
           i++;
       }
  
       return arr;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        List<int> result = Result.largestPermutation(k, arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
