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
     * Complete the 'viralAdvertising' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */

    public static int viralAdvertising(int n) // n = GIORNI
    {
        int likeTotali = 0;
        int persone = 5;
        
  
        for (int x = 0; x <n; x++) //giorni
        {
            int likeOggi = Convert.ToInt32(Math.Floor(Convert.ToDecimal(persone)/2));
            persone = likeOggi*3;

            likeTotali += likeOggi;            
            Console.WriteLine($"Giorno {x+1} - likeOggi {likeOggi} - Persone {persone} - likeTotali {likeTotali}        -");
            
            
            
        }
  

        return likeTotali;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.viralAdvertising(n);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
