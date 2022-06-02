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
     * Complete the 'squares' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER a
     *  2. INTEGER b
     */

    public static int squares(int a, int b)
    {
        // int conta = 0;
        
        // // Console.WriteLine($"A: {a} - B: {b}");
        
        // for (int x = a; x<=b; x++)
        // {
        //      Console.WriteLine("----------------");
        //      Console.WriteLine(x);
        //      Console.WriteLine(Math.Sqrt(x) % 1);

        //     if ((Math.Sqrt(x) % 1) == 0)
        //     {
        //         conta++;
        //         x = x+1*x+1;
        //         Console.WriteLine(x);
        //     } 
            
        // }

        return Convert.ToInt32(Math.Floor(Math.Sqrt(b) - Math.Ceiling(Math.Sqrt(a))) +1);

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int a = Convert.ToInt32(firstMultipleInput[0]);

            int b = Convert.ToInt32(firstMultipleInput[1]);

            int result = Result.squares(a, b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
