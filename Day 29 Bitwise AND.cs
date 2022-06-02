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
     * Complete the 'bitwiseAnd' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER N
     *  2. INTEGER K
     */

    public static int bitwiseAnd(int N, int K)
    {
        int max = 0;
        
        // Console.WriteLine("\n\n\n---------------------------------");
        // Console.WriteLine($"N: {N} - K: {K}");
                
        for (int a = N; a > 0; a--)
        {
             for (int b = N; b > 0; b--)
             {
              
                if (a>b) break;
                //  Console.WriteLine($"a: {a} b: {b}");

                 int c = a&b;
                //  Console.WriteLine($"a&b - {a}&{b}: {c} - max: {max} K: {K}"); 

                 if (a<b && c > max && c < K)
                 {
                  max = c;
                  //   Console.WriteLine($"Nuovo massimo! {max}");
                 }
                 
             }
            
        }
        
        return max;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int count = Convert.ToInt32(firstMultipleInput[0]);

            int lim = Convert.ToInt32(firstMultipleInput[1]);

            int res = Result.bitwiseAnd(count, lim);

            textWriter.WriteLine(res);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
