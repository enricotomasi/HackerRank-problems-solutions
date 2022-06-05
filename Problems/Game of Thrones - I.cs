 
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
     * Complete the 'gameOfThrones' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string gameOfThrones(string s)
    {
        bool pari= false;
        if (s.Length % 2 == 0) pari=true;
        
        int[] mappa = new int[255];
        
        foreach (char c in s)
        {
            int car = (int)c;
            mappa[car]++;
        }
        
        int dispari =0;
        foreach (int i in mappa)
        {
            if (i !=0 && i%2 != 0) dispari++;
        }
        
        
        if (pari & dispari >=1) return "NO";
        if (!pari & dispari >1) return "NO";
        
        return "YES";

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.gameOfThrones(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
