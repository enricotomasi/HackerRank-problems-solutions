 
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
     * Complete the 'palindromeIndex' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    
    private static readonly bool debug = false;
    
    private static string rev (string str)
    {
        char[] stringa = str.ToCharArray();
        Array.Reverse(stringa);
        return new string(stringa);
    }

    public static int palindromeIndex(string s)
    {
        if (debug) Console.WriteLine("\n---------------------------------");
        if (debug) Console.WriteLine($"Stringa: {s}");
        if (debug) Console.WriteLine($"Reverse: {rev(s)}");
        
        if (s == rev(s)) return -1;
        
        
        int j = s.Length;
        for (int i =0; i<s.Length/2; i++)
        {
            j--;
            if (debug) Console.WriteLine($"{i},{j} --- {s[i]},{s[j]}");
            if (s[i] != s[j])
            {
                string str = s.Remove(i,1);
                if (debug) Console.WriteLine($"Diverso!");
                if (debug) Console.WriteLine($"{str} --- {rev(str)}");
                
                       
                if (str==rev(str))
                {
                    return i;
                }
                else
                {
                    return j;
                }
            }
            
        }
        
           
     
        return -1;
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

            int result = Result.palindromeIndex(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
