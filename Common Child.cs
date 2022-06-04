 
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
    private static readonly bool debug = false;
    
    public static int commonChild(string s1, string s2)
    {
        var arr = new int[s1.Length+1, s2.Length+1];
        for (int i=0; i<s1.Length; i++)
        {
            for (int j=0; j<s2.Length; j++)
            {
                if (s1[i]==s2[j])
                {
                    arr[i+1,j+1] = arr[i,j]+1;
                }
                else
                {
                    arr[i+1,j+1] = Math.Max(arr[i+1,j],arr[i,j+1]);
                }
            }
        }
        
        if (debug)
        {
            for (int i=0; i<arr.GetLength(0); i++)
            {
                for (int j=0; j<arr.GetLength(1); j++)
                {
                    Console.Write($"{arr[i,j]} ");
                }
                Console.WriteLine();
            }
        }
        
        return arr[s1.Length,s2.Length];
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        string s1 = Console.ReadLine();
        string s2 = Console.ReadLine();
        int result = Result.commonChild(s1, s2);
        textWriter.WriteLine(result);
        textWriter.Flush();
        textWriter.Close();
    }
}
