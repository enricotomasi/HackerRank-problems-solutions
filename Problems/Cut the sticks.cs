 
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
     * Complete the 'cutTheSticks' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static List<int> cutTheSticks(List<int> arr)
    {
        
        arr.Sort();
        
        List<int> ritorno = new List<int>();
        ritorno.Add(arr.Count);
        
        
        int conta = 0;
        while (arr.Count > 1)
        {
           Console.WriteLine($"\n-----------------");
           conta++;
           Console.WriteLine($"Ciclo: {conta} - N. Elementi: {arr.Count}");
           
           int rif = arr[0];
                      
           while (arr[0] == rif && arr.Count > 1)
           {
               Console.WriteLine($"Rimuovo {arr[0]}");
               arr.Remove(arr[0]);
           }
           
           if (arr[0] == rif) break;
           
           Console.WriteLine("Array: ");
           foreach (int tapioca in arr)
           {
               Console.Write($"{tapioca} ");
           }
           Console.WriteLine();
           
           
           
           Console.WriteLine($"Ciclo: {conta}b - N. Elementi: {arr.Count} --- Sono <= 1? Esco? {arr.Count <= 1 && conta >= 1}");
           if (arr.Count < 1 && conta == 1)
           {
               Console.WriteLine("SI!");
               break;
           }
           Console.WriteLine("NO!");
            
           

           
           ritorno.Add(arr.Count);

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

        List<int> result = Result.cutTheSticks(arr);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
