 
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
     * Complete the 'insertionSort1' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr
     */

    public static void insertionSort1(int n, List<int> arr)
    {
        bool smetto = false;
        while (!smetto)
        {
            smetto=true;
            int precedente=int.MinValue;
            for (int i=0; i<n; i++)
            {
                if (arr[i]<precedente)
                {
                    smetto=false;
                    Console.Write($"{arr[i-1]} ");
                    int tempo = arr[i];
                    arr[i] = arr[i-1];
                    arr[i-1] = tempo;
                }
                else
                {
                    Console.Write($"{arr[i]} ");
                }
                
                precedente=arr[i];
            }
            Console.WriteLine();
            
            
        }
        
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.insertionSort1(n, arr);
    }
}
