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
     * Complete the 'countingValleys' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER steps
     *  2. STRING path
     */

    public static int countingValleys(int steps, string path)
    {
        
        int altitudine = 0;
        int conta = 0;
        
        foreach (char x in path)
        {
            if (x=='U')
            {
                altitudine++;
                if (altitudine == 0) conta++;
            }
            else
            {
                altitudine--;
            }            
        }
        
        
        // for (int y = 0; y < steps; y++)
        // {
            
        //     char x = path[y];
        //     if (x == 'U')
        //     {
        //         altitudine++;
        //         //Console.WriteLine("/");
        //     }
        //     else
        //     {
        //         altitudine--;
        //         //Console.WriteLine("\\");
        //     }
            
        //     Console.WriteLine($"Altitudine {altitudine}");
            
        //     if (altitudine == 0 && x == 'U') conta++;
            
        // }
        
        return conta;
        
    }
    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int steps = Convert.ToInt32(Console.ReadLine().Trim());

        string path = Console.ReadLine();

        int result = Result.countingValleys(steps, path);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
