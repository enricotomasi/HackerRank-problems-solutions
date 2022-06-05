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
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int migratoryBirds(List<int> arr)
    {
        
        int conta1 = 0;
        int conta2 = 0;
        int conta3 = 0;
        int conta4 = 0;
        int conta5 = 0;
        
        
        foreach (int x in arr)
        {
            if (x == 1) conta1++;
            if (x == 2) conta2++;
            if (x == 3) conta3++;
            if (x == 4) conta4++;
            if (x == 5) conta5++;
        }
        
        Console.WriteLine($"Conta1: {conta1}");
        Console.WriteLine($"Conta2: {conta2}");
        Console.WriteLine($"Conta3: {conta3}");
        Console.WriteLine($"Conta4: {conta4}");
        Console.WriteLine($"Conta5: {conta5}");
        
        int result = 0;
        int max = 0;
        
        if (conta1 > max)
        {
            result = 1;
            max = conta1;
            Console.WriteLine($"result: {result} - max:{max}");
        }
        
         if (conta2 > max)
        {
            result = 2;
            max = conta2;
            Console.WriteLine($"result: {result} - max:{max}");
        }
        
         if (conta3 > max)
        {
            result = 3;
            max = conta3;
            Console.WriteLine($"result: {result} - max:{max}");
        }
        
         if (conta4 > max)
        {
            result = 4;
            max = conta4;
            Console.WriteLine($"result: {result} - max:{max}");
        }
        
         if (conta5 > max)
        {
            result = 5;
            max = conta5;
            Console.WriteLine($"result: {result} - max:{max}");
        }
        
        
        
        
             
        return result;
        
               
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.migratoryBirds(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
