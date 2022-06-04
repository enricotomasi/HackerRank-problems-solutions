 
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
     * Complete the 'howManyGames' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER p - costo primo gioco
     *  2. INTEGER d - sconto 
     *  3. INTEGER m - costo minimo
     *  4. INTEGER s - budget
     */

    public static int howManyGames(int p, int d, int m, int s)
    {
        // Return the number of games you can buy
        bool debug=false;
        int ritorno=0;
        int costoAttuale = p;
        bool primoGioco=true;
        if(debug) Console.WriteLine($"Costo primo gioco: {p} - Sconto: {d} - costoMin: {m} - budget: {s} ");
        
        while (s>=costoAttuale)
        {
            if (debug) Console.WriteLine($"\nCostoAttuale: {costoAttuale} - Budget: {s}");
            ritorno++;
            s-=costoAttuale;
            if (costoAttuale-d > m) costoAttuale-=d;
            else costoAttuale=m;
            if (debug) Console.WriteLine($"ritorno: {ritorno}");
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

        int p = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        int m = Convert.ToInt32(firstMultipleInput[2]);

        int s = Convert.ToInt32(firstMultipleInput[3]);

        int answer = Result.howManyGames(p, d, m, s);

        textWriter.WriteLine(answer);

        textWriter.Flush();
        textWriter.Close();
    }
}
