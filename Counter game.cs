 
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
     * Complete the 'counterGame' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts LONG_INTEGER n as parameter.
     */


    // Louise muove per primo
    // se il numero e' una potenza di due divide per 2
    // se no sottrae al numero la potenza di due piu' vicina
    
    public static string counterGame(long n)
    {
        int conta=0;
        
        while (n>0 && n %2 ==0)
        {
            n/=2;
            conta++;
        }
        
        while (n>0)
        {
            if (n%2 == 1) conta++;
            n >>=1;
        }
        
        
        if (conta%2==1)
        {
            return "Richard";
        }
        else
        {
            return "Louise";
        }
    
        return "qualcosa non va";   
        
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
            long n = Convert.ToInt64(Console.ReadLine().Trim());

            string result = Result.counterGame(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}