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
     * Complete the 'rotLeft' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER d
     */

    public static List<int> rotLeft(List<int> arr, int rotazioni)
    {
        // Console.WriteLine($"-------------");
        List<int> ritorno = new List<int>();
        int lunghezza = arr.Count;
        // Console.WriteLine($"Lunghezza: {lunghezza} - Rotazioni: {rotazioni}");
        
        //calcola shift
        int shift = (rotazioni % lunghezza);
        // Console.WriteLine($"Shift: {shift}");
        
        
        for (int x = 0; x < lunghezza; x++)
        {
            
            int cifra = x+shift;
            if (cifra < lunghezza)
            {
                // Console.WriteLine($"MINORE - {x}+{shift}= {x+shift} < {lunghezza} --- cifra {x} diventa {cifra}");
                // Console.WriteLine($"Aggiungo: {arr[cifra]}");
                ritorno.Add(arr[cifra]);
            }
            else
            {
                cifra -= lunghezza; 
                // Console.WriteLine($"MAGGIORE - {x}+{shift}= {x+shift} < {lunghezza} --- cifra {x} diventa {cifra}");
                // Console.WriteLine($"Aggiungo: {arr[cifra]}");
                ritorno.Add(arr[cifra]);
            }
            
            // Console.WriteLine("---");
            
            
        }
        return ritorno;
        // Console.WriteLine($"-------------");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        List<int> result = Result.rotLeft(a, d);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
