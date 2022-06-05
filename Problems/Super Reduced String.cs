 
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
     * Complete the 'superReducedString' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string superReducedString(string s)
    {
        bool debug=false;
        string intermedia="";
        bool finito=false;
        
        while(!finito)
        {
            if (debug) Console.WriteLine($"Inizio ciclo, lunghezza di s: {s.Length}");
            finito=true;
            for (int i=0; i<s.Length; i++)
            {
                if (i != s.Length-1)
                {
                    if (s[i] != s[i+1])
                    {
                        intermedia += s[i];
                    }
                    else
                    {
                        finito=false;
                        i++;
                    }
                    
                }
                else
                {
                    intermedia += s[i];
                }
                
                if (debug) Console.WriteLine(intermedia);
                
            }
            s=intermedia;
            intermedia="";
        } 

        if (s!="") return s;
        else return "Empty String";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.superReducedString(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
