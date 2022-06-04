 
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
     * Complete the 'larrysArray' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY A as parameter.
     */

    public static string larrysArray(List<int> A)
    {
        bool debug = false;
        
       if (debug) Console.WriteLine("--------------------------------------");
       if (debug) Console.WriteLine("---ORIGINALE --- " +string.Join(" ", A));
        
       
       for (int j=0; j<1000; j++)
       {
           for (int i=0; i<A.Count-2; i++)
        {
            int a=A[i];
            int b=A[i+1];
            int c=A[i+2];
            
            if (a<b && b<c) continue;
            
            if (b<c)
            {
                A[i] = b;        
                A[i+1] = c;      
                A[i+2] = a;      
            }
            else
            {
                A[i] = c;        
                A[i+1] = a;      
                A[i+2] = b;      
            }
        }
        
        if (debug) Console.WriteLine("---SHUFFOLATO--- " +string.Join(" ", A));
        
        int vecchio = A[0];
        bool ordinato=true;
        for (int i=1; i<A.Count; i++)
        {
            if (A[i]<vecchio)
            {
                ordinato=false;
                break;
            }
            vecchio = A[i];
        }
        if (ordinato) return "YES";
           
       }
       
        
        return "NO";
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

            List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

            string result = Result.larrysArray(A);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
