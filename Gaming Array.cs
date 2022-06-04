 
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
     * Complete the 'gamingArray' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    // Bob gioca per primo (maschilista!)
    // Ad ogni mossa il giocatore elimina gli elementi degli array che seguono quello di maggiore valore (compreso)
    // Si gioca uno alla volta 
    // Il giocatore che elimina l'ultimo numero vince


    internal static readonly bool debug = false;
    public static string gamingArray(List<int> arr)
    {
        if (debug) Console.WriteLine("-------------------------------------------------------");
        int fine = arr.Count;
        bool vinceBob = false;
        
        if (debug) Console.WriteLine($"Fine: {fine} --- {fine <=0}");
                
        int max = 0;
        int conta = 0;
        
        for (int i=0; i<arr.Count;i++)
        {
            if (arr[i] > max)
            {
                max = arr[i];
                conta++;
            }
            
            
        }
        if (debug) Console.WriteLine($"{conta}");
                    
        if (conta%2==0)
        {
            return "ANDY";
        }
        else
        {
            return "BOB";
        }
        
        return "Casa cazzo e' successo?";
        
    }
    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int g = Convert.ToInt32(Console.ReadLine().Trim());

        for (int gItr = 0; gItr < g; gItr++)
        {
            int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            string result = Result.gamingArray(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
