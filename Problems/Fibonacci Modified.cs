 
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
using System.Numerics;
using System;

class Result
{
    //--------------------------------           ---------------------- DEBUG
    private static readonly bool debug = false;
    private static void logga<T>(T msg, bool aCapo = true)
    {
        if (debug && aCapo) Console.Error.WriteLine(msg.ToString());
        else if (debug) Console.Error.Write(msg.ToString());
    }
    //---------------------------------------------------------------- DEBUG

    /*
     * Complete the 'fibonacciModified' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER t1
     *  2. INTEGER t2
     *  3. INTEGER n
     */

    public static BigInteger fibonacciModified(int t1, int t2, int n)
    {
     
        BigInteger o0=t1;
        BigInteger o1=t2;
        
        BigInteger result = 0;
        
        // cazzo di forumla: result = ti-2 + (ti-1)2
        for (int i=2; i<n; i++)
        {
            result = o0 + BigInteger.Pow(o1,  2);
            logga ($"t{i} = {o0} + ({o1})2 = {result}");
            
            o0 = o1;
            o1 = result;
            
        }
        
        logga ($"Risultato: {result}");
        return result;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int t1 = Convert.ToInt32(firstMultipleInput[0]);

        int t2 = Convert.ToInt32(firstMultipleInput[1]);

        int n = Convert.ToInt32(firstMultipleInput[2]);

        BigInteger result = Result.fibonacciModified(t1, t2, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
