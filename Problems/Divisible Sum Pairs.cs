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
     * Complete the 'divisibleSumPairs' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n Lunghezza Array
     *  2. INTEGER k intero divisore
     *  3. INTEGER_ARRAY ar array di numeri
     */

    public static int divisibleSumPairs(int n, int k, List<int> ar)
    {
        
        int conta = 0;
        
        for (int x = 0; x< n; x++)
        {
            for (int y = 0; y<n; y++)
            {
                 if (x < y)
            {
                if ((ar[x] + ar[y]) % k == 0) conta++;
                Console.WriteLine($"Match: x:{x} y:{y} --- Valori x:{ar[x]} y:{ar[y]}");
            }
            
            }
          
        }
        
        return conta;
        
        
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

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.divisibleSumPairs(n, k, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
