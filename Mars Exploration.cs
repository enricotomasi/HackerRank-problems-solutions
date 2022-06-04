 
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
     * Complete the 'marsExploration' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static int marsExploration(string s)
    {
        int ritorno=0;

        for (int i=0; i<s.Length;i++)
        {
            int carattere = (i % 3);
            char cara = (s[i]);
            // Console.WriteLine($"i:{i} - carattere: {carattere} - cara: {cara}");
            
            if (carattere==0)
            {
                if (cara != 'S') ritorno++;
            }
            if (carattere==1)
            {
                if (cara != 'O') ritorno++;
            }
            if (carattere==2)
            {
                if (cara != 'S') ritorno++;
            }
            
        }

        
        return ritorno;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        int result = Result.marsExploration(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
