 
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
     * Complete the 'absolutePermutation' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER k
     */
     
     //permutazione = il primo numero nel range [1,n]
     
    private static readonly bool debug = false;

    public static List<int> absolutePermutation(int n, int k)
    {
        
        List<int> ritorno = new List<int>();
        
        if (debug) Console.WriteLine($"\n------------ n: {n} - k: {k}");


        if ((k!=0) && n%(2*k)!=0)
        {
            ritorno.Add(-1);
            return ritorno;
        }
         
        bool diritto = false;
        int conta = k;
        int ultimo = 0;
        
        for (int i=0; i<n; i++)
        {
            if (diritto)
            {
                ultimo=i-k+1;
                ritorno.Add(ultimo);
            }
            else
            {
                ultimo=i+k+1;
                ritorno.Add(ultimo);
            }
             
            if (conta < 2)
            {
                diritto = !diritto;
                conta = k;
            }
            else
            {
               conta--; 
            }
            
        }
        
        if (ritorno.Count==0)
        {
            ritorno.Add(-1);            
        }
        
        return ritorno;
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
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> result = Result.absolutePermutation(n, k);

            textWriter.WriteLine(String.Join(" ", result));
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
