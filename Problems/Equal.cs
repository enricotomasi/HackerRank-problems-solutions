 
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
    public static int equal(List<int> arr)
    {
        int min = arr.Min();
        var mosse = new List<int>();
        
        for (int i=0; i<5; i++)                
        {
            int mosseTemp = 0;
            
            for (int j=0; j<arr.Count; j++)
            {
                int diff = arr[j] - (min-i);
                mosseTemp += diff/5;
                mosseTemp += (diff%5)/2;
                mosseTemp += (diff%5)%2;
            }
            
            mosse.Add(mosseTemp);
            
        }
        
        return mosse.Min();
        
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

            List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

            int result = Result.equal(arr);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
