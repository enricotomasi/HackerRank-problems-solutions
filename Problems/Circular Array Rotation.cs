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
     * Complete the 'circularArrayRotation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a ---Array
     *  2. INTEGER k - Rotazioni
     *  3. INTEGER_ARRAY queries - Queries
     */

    public static List<int> circularArrayRotation(List<int> arr, int rotazioni, List<int> queries)
    {

        List<int> risultati = new List<int>();
        
        List<int> nuovoarr = new List<int>();
        
        int lunghezza = arr.Count();
        // Console.WriteLine($"Lunghezza: {lunghezza} - Rotazioni {rotazioni}");
        
        int shift = lunghezza - (rotazioni % lunghezza);
        
        // Console.WriteLine($"Shift: {shift}");
   
        
        for (int x = 0; x < lunghezza; x++)
        {
            // Console.WriteLine($"--------------------------------------------");
    
            int cifra = x + shift;
            
            // Console.Write($" cifra: {cifra} - lungehzza {lunghezza} --- ");
            
            if (cifra >= lunghezza)
            {

                cifra -= lunghezza;
                // Console.Write($"TROPPO LUNGO --- Nuova cifra: {cifra}");
            }
        
            
            nuovoarr.Add(arr[cifra]);
            // Console.WriteLine("\n\n");                
        }
        
        
        
        foreach (int x in queries)
        {
            risultati.Add(nuovoarr[x]);
        }
        
        
        
        return risultati;
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

        int q = Convert.ToInt32(firstMultipleInput[2]);

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        List<int> queries = new List<int>();

        for (int i = 0; i < q; i++)
        {
            int queriesItem = Convert.ToInt32(Console.ReadLine().Trim());
            queries.Add(queriesItem);
        }

        List<int> result = Result.circularArrayRotation(a, k, queries);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
