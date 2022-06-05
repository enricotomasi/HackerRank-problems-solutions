 
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
     * Complete the 'gemstones' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING_ARRAY arr as parameter.
     */

    public static int gemstones(List<string> arr)
    {
        int ritorno = 0;
        
        List<char> minGemmaTemp = new List<char>();
        
        foreach (string s in arr)
        {
            foreach (char c in s)
            {
                minGemmaTemp.Add(c);
            }
        }
        
        minGemmaTemp.Sort();
        
        List<char> minGemma = minGemmaTemp.Distinct().ToList();
        
        foreach (char c in minGemma)
        {
            bool aggiungo = true;
            foreach (string s in arr)
            {
                if (!s.Contains(c)) aggiungo = false;
            }
            
            if (aggiungo) ritorno++;
        }
        
        
        
        return ritorno;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> arr = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string arrItem = Console.ReadLine();
            arr.Add(arrItem);
        }

        int result = Result.gemstones(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
