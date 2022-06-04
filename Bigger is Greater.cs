 
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
     * Complete the 'biggerIsGreater' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING w as parameter.
     */

    public static string biggerIsGreater(string word)
    {
        var w = word.ToCharArray();
        int lunghezza = w.Length;
        string risultato = "";
        
        
        for (int i=lunghezza-2; i>=0; i--)
        {
            for (int j=lunghezza-1; j>i; j--)
            {
                if (w[j] > w[i])
                {
                    for (int k=0; k<i; k++)
                    {
                        risultato += w[k];
                    }
                    
                    risultato += w[j];
                    
                    for (int t=lunghezza-1; t>i; t--)
                    {
                        if (t !=j) risultato += w[t];
                        else risultato+= w[i];
                    }
                    
                    return risultato;
                }
            }
        }
        
        return "no answer";
        
        
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int T = Convert.ToInt32(Console.ReadLine().Trim());

        for (int TItr = 0; TItr < T; TItr++)
        {
            string w = Console.ReadLine();

            string result = Result.biggerIsGreater(w);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
