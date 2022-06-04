 
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
     * Complete the 'redJohn' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */

    public static int redJohn(int n)
    {
        var tiles = new int[n+1];
        
        for (int i=0; i<=n; i++)
        {
            tiles[i] = 1;
        }
        
        if (n>3)
        {
            for (int i=4; i<=n; i++)
            {
                tiles[i] = tiles[i-1] + tiles[i-4];
            }
        }
        
        Console.WriteLine(string.Join(" ", tiles));
        
        int p=0;
        var prime = new bool[tiles[n]+1];
        for (int i=0; i<=tiles[n]; i++)
        {
            prime[i] = true;
        }
        
        for (int i=2; i<= tiles[n];i++)
        {
            if (prime[i])
            {
                for (int j=2*i; j<=tiles[n]; j+=i)
                {
                    prime[j] = false;
                }
                p++;
            }
        }
        return p;
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

            int result = Result.redJohn(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
