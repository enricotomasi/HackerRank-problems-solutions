 
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
     * Complete the 'powerSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER X
     *  2. INTEGER N
     */

    public static int powerSum(int X, int N, int a=1)
    {
        if (X<0 || X<Convert.ToInt32(Math.Pow(a, N))) return 0;
        
        if (X==0 || X==Convert.ToInt32(Math.Pow(a, N))) return 1;
        
        return powerSum(X-Convert.ToInt32(Math.Pow(a, N)), N, a+1) + powerSum(X,N,a+1);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int X = Convert.ToInt32(Console.ReadLine().Trim());

        int N = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.powerSum(X, N);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
