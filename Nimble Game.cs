 
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
     * Complete the 'nimbleGame' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY s as parameter.
     */

    public static string nimbleGame(List<int> s)
    {
        int ritorno = 0;
        
        for (int i=0; i<s.Count; i++)
        {
            if (s[i]>0)
            {
                ritorno ^=s[i]%2 == 0 ? 0 : i;
            }
        }
        
        if (ritorno>0) return "First";
            else return "Second";
        
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

            List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

            string result = Result.nimbleGame(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
