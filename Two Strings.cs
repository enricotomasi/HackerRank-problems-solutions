 
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
     * Complete the 'twoStrings' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s1
     *  2. STRING s2
     */

    public static string twoStrings(string s1, string s2)
    {
        int[] c1 = new int[255];
        int[] c2 = new int[255];
     
        foreach (char c in s1)
        {
            c1[(int)c]++;
        }
        
        foreach (char c in s2)
        {
            c2[(int)c]++;
        }
        
        
        for (int i = 0; i<255; i++)
        {
            if (c1[i] >0 && c2[i] >0) return "YES";
        }
        
        return "NO";
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
            string s1 = Console.ReadLine();

            string s2 = Console.ReadLine();

            string result = Result.twoStrings(s1, s2);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
