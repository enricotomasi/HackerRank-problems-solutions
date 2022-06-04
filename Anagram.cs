 
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
     * Complete the 'anagram' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */
    
    public static bool debug = false;

    public static int anagram(string s)
    {
        if (debug) Console.WriteLine($"\n{s}");
        if (s.Length %2 != 0) return -1;
        
        string uno = s.Substring(0,(s.Length/2));
        string due = s.Substring((s.Length/2));
        
        int[] un = new int[255];
        int[] du = new int[255];
        
        for (int i=0; i<uno.Length; i++)
        {
            int u = (int)uno[i];
            int d = (int)due[i];
            
            un[u]++;
            du[d]++;
        }

        int ritorno =0;
        
        for (int i=0; i<255; i++)
        {
            ritorno+=Math.Abs(un[i]-du[i]);
            if (debug && Math.Abs(un[i]-du[i]) !=0) Console.WriteLine($"ciclo: {i} - {un[i]} vs {du[i]} --- {Math.Abs(un[i]-du[i])}  --- Ritorno: {ritorno}");
            
        }
       
        return ritorno/2;
  
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
            string s = Console.ReadLine();

            int result = Result.anagram(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
