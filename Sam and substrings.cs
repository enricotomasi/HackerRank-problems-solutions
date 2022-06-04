 
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
    public static int substrings(string s)
    {
        long M = 1000000007;
        
        long somma = 0;
        int n = s.Length;
        long x = s[0]-'0';
        var dp = new long[200008];
        dp[0]=x;
        somma+=x;
        
        for (int i=1; i<n; i++)
        {
            dp[i]=((i+1) * (s[i]-'0') +10*dp[i-1]) %M;
            somma += (dp[i])%M;
            
            if (somma<0) somma=(somma+M)%M;
        }
        
        return Convert.ToInt32((somma)%M);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string n = Console.ReadLine();

        int result = Result.substrings(n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
