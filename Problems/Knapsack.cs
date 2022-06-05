 
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

    private static readonly bool debug = false;

    public static int unboundedKnapsack(int k, List<int> arr)
    {
        if (debug) Console.WriteLine($"\n---k: {k} --- " + string.Join(" ", arr));
        
        var lista = new List<int>();
        
        for (int i=0; i<arr.Count; i++)
        {
            int valore=arr[i];
            
            int val=valore;
            
            if (val <= k)
            {
               lista.Add(val);
               while (val <= k)
               {
                    val+=valore;
                    if (val<=k) lista.Add(val);
               }    
            }
            
        }
        if (debug) Console.WriteLine("Lista: " + string.Join(" ", lista));

        if (debug) Console.WriteLine($"Lista contiene {k}? {lista.Contains(k)}");
        if (lista.Contains(k))
        {
            if (debug) Console.WriteLine($"Numero preciso, ritorno: {k}");
            return k;
        }
        
        int risultato = 0;
        for (int i=0; i<lista.Count; i++)
        {
            for (int j=i+1; j<lista.Count; j++)
            {
                int somma=lista[i]+lista[j];
                
                if (somma<=k)
                {
                    risultato = Math.Max(risultato, somma);
                }
            }
        }
        
        int massimo = 0;
        
        if (lista.Count>0) massimo = lista.Max();
        
        risultato=Math.Max(risultato, massimo);        
        
        Console.WriteLine($"Ritorno: {risultato}");
        return risultato;
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);
        int t = Convert.ToInt32(Console.ReadLine().Trim());
        
        for (int i=0; i<t; i++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');
            int n = Convert.ToInt32(firstMultipleInput[0]);
            int k = Convert.ToInt32(firstMultipleInput[1]);
            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();
            int result = Result.unboundedKnapsack(k, arr);
            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
