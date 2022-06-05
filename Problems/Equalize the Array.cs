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
     * Complete the 'equalizeArray' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int equalizeArray(List<int> arr)
    {

        List<int> unici = new List<int>();
        unici = arr.Distinct().ToList();
        
        unici.Sort();
        arr.Sort();

        int max = int.MinValue;
        int value = 0;
                
        
        foreach (int x in unici)
        {
            
            int tmpConta = 0;
            foreach (int y in arr)
            {
                if (x==y)
                {
                    tmpConta++;
                }
                
                if (tmpConta > max)
                {
                    // Console.WriteLine($"Piu' (ascii di merda) grande {tmpConta} - carattere {x}");
                    max = tmpConta;
                    value= x;
                }
                
            }
        }
        
        // Console.WriteLine($"Elemeno piu' (ascii di merda) abbondante: {value} con {max} occorrenze");
        
        int lunghezza = arr.Count;
        
        // Console.WriteLine($"Lunghezza {lunghezza}");
        // Console.WriteLine($"");
        
        return arr.Count-max;
        

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.equalizeArray(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
