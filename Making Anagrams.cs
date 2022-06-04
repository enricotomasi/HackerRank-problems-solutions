 
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
     * Complete the 'makingAnagrams' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. STRING s1
     *  2. STRING s2
     */

    public static int makingAnagrams(string s1, string s2)
    {
        int ritorno = 0;
        
        char[] s1Arr = s1.ToArray();
        char[] s2Arr = s2.ToArray();
        
        int[] s1Map = new int[255];
        int[] s2Map = new int[255];
        
        foreach (char c in s1Arr)
        {
            int numero = (int)c;
            s1Map[numero]++;
        }
        
         foreach (char c in s2Arr)
        {
            int numero = (int)c;
            s2Map[numero]++;
        }
        
        for (int i = 0; i<255; i++)
        {
            ritorno += Math.Abs(s1Map[i]-s2Map[i]);
        }
        
        
        return ritorno;
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s1 = Console.ReadLine();

        string s2 = Console.ReadLine();

        int result = Result.makingAnagrams(s1, s2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
