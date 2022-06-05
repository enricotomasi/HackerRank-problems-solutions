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
     * Complete the 'repeatedString' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. LONG_INTEGER n
     */

    public static long repeatedString(string s, long n)
    {
        long numero = 0;
        // Console.WriteLine($"s: {s} - n: {n}");
        
        int lunghezza = s.Length;
        // Console.WriteLine($"Lungehzza: {lunghezza}");
        
        long cicliCompleti = Convert.ToInt64(Math.Floor(Convert.ToDecimal(n) / Convert.ToDecimal(lunghezza)));
        // Console.WriteLine($"Cicli completi: {cicliCompleti}");
        
        long cicloMezzo = (n%lunghezza);
        // Console.WriteLine($"Ciclo Mezzo = {cicloMezzo}");
        
        int numeroA = 0;
        foreach (char c in s)
        {
            if (c == 'a') numeroA++;
        }
        // Console.WriteLine($"Numero di a nella stringa piccola: {numeroA}");

        numero+= (numeroA*cicliCompleti);
        // Console.WriteLine($"Numero parziale (solo cicli completi): {numero}");
        
        for (int x = 0; x<cicloMezzo; x++)
        {
            if (s[x] == 'a') numero++;
        }
        
        // Console.WriteLine($"Numero totale: {numero}");

        return numero;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        long n = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.repeatedString(s, n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
