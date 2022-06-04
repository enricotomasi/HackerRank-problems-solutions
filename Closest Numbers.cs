 
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
     * Complete the 'closestNumbers' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static bool debug = false;

    public static List<int> closestNumbers(List<int> arr)
    {
        List<int> ritorno = new List<int>();
        
        int uno=arr[0];
        int due=arr[1];
        
        arr.Sort();
        
        if (debug)
        {
            Console.WriteLine("Array ordinato:");
            foreach (int i in arr)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine("\n");
        }
        
        for (int i=0; i<arr.Count-1; i++)
        {
            
            int diff1 = Math.Abs(uno-due);
            
            int diff2=0;
            
            diff2 = Math.Abs(arr[i]-arr[i+1]);

            if (debug)
            {
                Console.WriteLine($"Ciclo: {i} (lungh: {arr.Count-1})");
                Console.WriteLine($"Diff1 {uno} - {due} = {diff1}");
                Console.WriteLine($"Diff2 {arr[i]} - {arr[i+1]} = {diff2}");
                
            }

            if (diff2 < diff1)
            {
                uno = arr[i];
                due = arr[i+1];
                if (debug)Console.WriteLine($"--- Trovata coppia minore: {uno} {due} --- {diff2} ---");
            }
            
            if (debug) Console.WriteLine();
        }
        
        int diffOk = Math.Abs(uno-due);
       
        
        for (int i=0; i<arr.Count-1; i++)
        {
            uno = arr[i];
            due = arr[i+1];
            
            if (Math.Abs(uno-due) == diffOk) 
            {
                ritorno.Add(uno);
                ritorno.Add(due);
            }
            
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

        List<int> result = Result.closestNumbers(arr);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
