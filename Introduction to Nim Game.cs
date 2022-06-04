 
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
     * Complete the 'nimGame' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY pile as parameter.
     */

    public static string nimGame(List<int> pile)
    {
        int somma = 0;
        foreach (int i in pile)
        {
            somma^=i;
        }
        
        if (somma>0) return "First";
        else return "Second";
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
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> pile = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(pileTemp => Convert.ToInt32(pileTemp)).ToList();

            string result = Result.nimGame(pile);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
