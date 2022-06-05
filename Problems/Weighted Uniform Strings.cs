 
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
     * Complete the 'weightedUniformStrings' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER_ARRAY queries
     */
     
    private static readonly bool debug = false;
     
    private static int trovaNumero(char c)
    {
        return (int)c-96;
    }

    public static List<string> weightedUniformStrings(string s, List<int> queries)
    {
        if (debug) Console.WriteLine($"------ {s}");
        
        List<string> ritorno = new List<string>();
        List<int> valori = new List<int>();
        
        char carattere = s[0];
        int temp = trovaNumero(carattere);
        int tempTot = temp;
        valori.Add(tempTot);
        

        for (int i=1; i<s.Length; i++)
        {
            if (s[i] == carattere)
            {
                tempTot += temp;
                valori.Add(tempTot);
            }
            else
            {
                carattere = s[i];
                temp = trovaNumero(carattere);
                tempTot = temp;
                valori.Add(tempTot);
            }
        }
      
        valori.Sort();
        int lungh = valori.Count;
        
        if (debug) valori.ForEach(x => {Console.WriteLine(x);});
        
        foreach (int i in queries)
        {
            if (debug) Console.WriteLine($"i: {i} valori.BinarySearch(i):{valori.BinarySearch(i)}");
            if (valori.BinarySearch(i) >= 0)
            {
                ritorno.Add("Yes"); // lo sapevo!
            }
            else
            {
                ritorno.Add("No"); // Non lo sapevo!
            }
        }
        
        return ritorno;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int queriesCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> queries = new List<int>();

        for (int i = 0; i < queriesCount; i++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<string> result = Result.weightedUniformStrings(s, queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
