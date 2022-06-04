 
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

    public static string appendAndDelete(string dest, string sorg, int max)
    {
        int lunghezzaComune = 0;
        
        for (int i=0; i<Math.Min(sorg.Length, dest.Length); i++)
        {
            if (sorg[i] == dest[i]) lunghezzaComune++;
            else break;
        }
        
       
        if ((sorg.Length + dest.Length - 2*lunghezzaComune) > max) return "No";
        
        else if ((sorg.Length + dest.Length - 2* lunghezzaComune) %2 == max%2) return "Yes";
        
        else if (sorg.Length + dest.Length - max < 0) return "Yes";
        
        else return "No";
      
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string t = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.appendAndDelete(s, t, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
