 
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
     * Complete the 'balancedSums' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static string balancedSums(List<int> arr)
    {
        
        // Console.WriteLine("\n" + string.Join(" ", arr));
        
        int destra = 0;
        int sinistra = 0;
        
        for (int i=1; i<arr.Count; i++)
        {
            destra+=arr[i];
        }
        
        // Console.WriteLine($"Ciclo 0: sx: {sinistra} - dx: {destra}");
        
        if (sinistra==destra) return "YES";
        
        
        for (int i=1; i<arr.Count; i++)
        {
            destra-= arr[i];
            sinistra+= arr[i-1];
            
            // Console.WriteLine($"Ciclo {i}: sx: {sinistra} - dx: {destra}");
            
            if (sinistra==destra) return "YES";
        }
        
        return "NO";
        

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
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            string result = Result.balancedSums(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
