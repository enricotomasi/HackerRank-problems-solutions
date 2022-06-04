 
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
     * Complete the 'luckBalance' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. 2D_INTEGER_ARRAY contests
     */

    public static bool debug = false;

    public static int luckBalance(int k, List<List<int>> contests)
    {
        int ritorno = 0;
        
        int lung = contests.Count();
        
        if (debug) Console.WriteLine($"Lunghezza: {lung} - Posso perdere max {k} importanti");
        
        List<int> importanti = new List<int>();
     
        foreach (List<int> item in contests)
        {
            if (debug) Console.WriteLine($"{item[0]} - {item[1]}");
            
            if (item[1] == 0)
            {
                ritorno += item[0];
                if (debug) Console.WriteLine($"Non importante, lo perdo aggiungo {item[0]} alla fortuna. Ritorno: {ritorno}");
            }
            else
            {
                importanti.Add(item[0]);
                if (debug) Console.WriteLine($"E' importante, lo aggiungo in lista e poi ci penso dopo: {item[0]}");
            }
            
            if (debug) Console.WriteLine();   
        }
        
        
        importanti.Sort();
        importanti.Reverse();
        
        for (int i=0; i<importanti.Count; i++)
        {
            if (k>0)
            {
                ritorno += importanti[i];
                if (debug) Console.WriteLine($"-Ciclo importanti n: {i} (max {k}) lo perdo e aggiungo {importanti[i]} alla fortuna. Ritorno: {ritorno}");
                k--;
            }
            else
            {
                ritorno -= importanti[i];
                if (debug) Console.WriteLine($"-Ciclo importanti n: {i} --SUPERATOMAX -- lo vinco e rolgo {importanti[i]} alla fortuna. Ritorno: {ritorno}");
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

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> contests = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            contests.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(contestsTemp => Convert.ToInt32(contestsTemp)).ToList());
        }

        int result = Result.luckBalance(k, contests);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
