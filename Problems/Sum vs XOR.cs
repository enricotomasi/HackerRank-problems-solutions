 
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
     * Complete the 'sumXor' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts LONG_INTEGER n as parameter.
     */
     
    private static readonly bool debug = true;
    private static void logga(string msg = "", bool aCapo = true)
    {
        if (debug && aCapo) Console.Error.WriteLine(msg);
        else if (debug) Console.Error.Write(msg);
    }


    public static long sumXor(long n)
    {
        long conta = 0;
        long conta2 = 0;
        
        if (n==0) return 1;
        
        while (n >0)
        {
            long tempo = n&1;
            if (tempo==0) conta++;
            n >>=1;
        }
        
        conta2 = (long)Math.Pow(2, conta);

        return conta2;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.sumXor(n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
