 
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
    public static int nonDivisibleSubset(int k, List<int> s)
    {
        int n=s.Count();
        
        var counts = new int[k];
        
        
        for (int i=0; i<n; i++)
        {
            counts[s[i]%k]++;
        }
        
        int count=Math.Min(counts[0], 1);
        
        for (int i=1; i<(k/2)+1;i++)
        {
            if (i != k-i)
            {
                count+= Math.Max(counts[i], counts[k-i]);
            }
        }
        
        if (k%2==0) count++;
        return count;
        
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

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        int result = Result.nonDivisibleSubset(k, s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
