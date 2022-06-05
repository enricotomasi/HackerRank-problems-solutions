
 
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
     * Complete the 'gameOfStones' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER n as parameter.
     */
     
    // Due giocatori, P1 muove sempre per primo
    // Regole: puoi prendere 2,3 o 5 sassi
    // Perde chi non puo piu muoversi 
    
    private static readonly bool debug = true;

    public static string gameOfStones(int n)
    {
       if (n<2) return "Second";
       
       if (n%7<2) return "Second";
       else return "First";
       
       
       
     
        return "Qualcosa e' andato storto";    
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string result = Result.gameOfStones(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
