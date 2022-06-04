 
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
     * Complete the 'funnyString' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static bool debug = false;

    public static string funnyString(string s)
    {
        string f="Funny";
        string nf="Not Funny";
        
        List<int> diritta = new List<int>();
        List<int> rovesciata = new List<int>();
        
        
        if (debug) Console.WriteLine("Inizio dritta");
        for (int i=0; i<s.Length-1; i++)
        {
            int primo = (int)s[i];
            int secondo = (int)s[i+1];
            
            int diff = Math.Abs(primo-secondo);
            
            diritta.Add(diff);
            
            if (debug) Console.WriteLine($"Primo: {s[i]} - {primo} --- Secondo: {s[i+1]} {secondo} --- abs diff: {diff}");
        }
        
        if (debug) Console.WriteLine("Inizio roversciata");
        for (int i=s.Length-1; i>0; i--)
        {
            int primo = (int)s[i];
            int secondo = (int)s[i-1];
            
            int diff = Math.Abs(primo-secondo);
            
            rovesciata.Add(diff);
                if (debug) Console.WriteLine($"Primo: {s[i]} - {primo} --- Secondo: {s[i-1]} {secondo} --- abs diff: {diff}");
        }
        
        if (debug) Console.WriteLine(string.Join(" ", diritta));
        if (debug) Console.WriteLine(string.Join(" ", rovesciata));
                
        
        if (Enumerable.SequenceEqual(diritta, rovesciata)) return f;
        else return nf;
        
        
        

        return "qualcosa e' andato storto!";
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

            string result = Result.funnyString(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
