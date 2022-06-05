 
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
     * Complete the 'minimumDistances' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int minimumDistances(List<int> a)
    {
        var dizionario = new Dictionary<int, (int, bool)>();
        var posizione = 0;
        
        foreach(var i in a)
        {
            if(dizionario.ContainsKey(i))
            {
                dizionario[i] = (posizione - dizionario[i].Item1, true);
            }
            else
            {
                dizionario.Add(i, (posizione, false));
            }
            posizione++;
        }
        
        var ce = false;
        var risultato = int.MaxValue;
        
        foreach(var i in dizionario)
        {
            if(i.Value.Item2 && i.Value.Item1 < risultato)
            {
                risultato = i.Value.Item1;
                ce = true;
            }
        }
        
        if(ce)
        {
            return risultato;
        }
        else
        {
            return -1;
        }
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.minimumDistances(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
