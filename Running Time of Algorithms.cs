 
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
     * Complete the 'runningTime' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static bool debug = false;
    
    public static int runningTime(List<int> A)
    {
        int passaggi=0;
        
        var j = 0; 
        
        for (var i = 1; i < A.Count; i++)
        { 
            var value = A[i]; 
            if (debug) Console.Error.WriteLine($"\nCiclo: {i} - Lunghezza: {A.Count} --- Valore: ***{value}*** ");
            if (debug) Console.Error.WriteLine(string.Join(" ", A)); 
            
            j = i - 1; 
            
            if (debug) Console.Error.WriteLine($"Inizio sottociclo while fino a che {j} < 0  &&");
            if (debug && j>0) Console.Error.WriteLine($"j < A[J] -- {j} < {A[j]}");
            
            while (j >= 0 && value < A[j])
            { 
                if (debug) Console.Error.WriteLine($"---Sottociclo While {j} A[j + 1] = A[j] -- A[{j+1}] = a[{j}] -- {A[j+1]} = {A[j]}");
                A[j + 1] = A[j];
                j = j - 1; 
                passaggi++;
            } 
            
            if (debug) Console.Error.WriteLine($"-Assegno cifra sposata: A[j + 1] = value -- a[{j+1}] = {value} ");
            A[j + 1] = value; 
            
            if (debug) Console.Error.WriteLine(string.Join(" ", A)); 
            
        } 
        
        //Console.WriteLine(string.Join(" ", A)); 
        
        return passaggi;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.runningTime(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
