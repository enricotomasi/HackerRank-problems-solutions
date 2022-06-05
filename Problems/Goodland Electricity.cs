 
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

//Dissonanza cognitiva

class Result
{

    /*
     * Complete the 'pylons' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k --- Limite distrubuzione corrente (non compreso)
     *  2. INTEGER_ARRAY arr --- Lista citta'
     */

    //La distanza fra le citta e 1
    //0 non puoi fare la centrale
    //1 puoi fare la centrale


    internal static readonly bool debug = false;

    public static int pylons(int k, List<int> arr)
    {
        if (debug)
        {
            Console.WriteLine($"K: {k} --- Lunghezza: {arr.Count}");
            //for (int i = 0; i < arr.Count; i++)
            //{
            //    Console.Write($"{i} ");
            //}
            //Console.WriteLine();
            //Console.WriteLine(string.Join(" ", arr));
            //Console.WriteLine();
        }

        int ritorno = 0;

        // int distanza = 0;

        // for (int i=0; i<arr.Count()-k; i++)
        // {
        //     if (arr[i] == 0) distanza++;
        //     else distanza = 0;

        //     if (distanza > k) return -1;
        // }

        k--;

        for (int i = 0; i < arr.Count; i++)
        {
            if (debug) Console.WriteLine($"i: {i}");
            int inizio = i - k;
            int fine = i + k;

            if (inizio < 0) inizio = 0;
            if (fine > arr.Count - 1) fine = arr.Count - 1;

            bool funziona = false;
            
            if (debug)
            {
                Console.Write("     ");     
                for (int cur = fine; cur >= inizio; cur--)
                {
                    Console.Write($"{cur} ");
                }
                Console.WriteLine();
                
                Console.Write("     ");     
                for (int cur = fine; cur >= inizio; cur--)
                {
                    Console.Write($"{arr[i]} ");
                }
                Console.WriteLine();
            }

            for (int cur = fine; cur >= inizio; cur--)
            {
                if (debug) Console.WriteLine($"     I: {i} - Inizio: {inizio} - Fine: {fine} --- cur: {cur}");
                if (arr[cur] == 1)
                {
                    if (debug) Console.WriteLine($"                          -- Centrale -- {cur} --- ({ritorno})");
                    i = cur + k;
                    if (debug) Console.WriteLine($"     Nuovo valore della i: {i}");
                    ritorno++;
                    funziona = true;
                    break;
                }
            }

            if (!funziona)
            {
                if (debug) Console.WriteLine($"Impossibile :(");
                return -1;
            }

        }

        if (debug) Console.WriteLine($"Ritorno: {ritorno}");
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

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.pylons(k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
