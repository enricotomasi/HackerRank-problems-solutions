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
     * Complete the 'staircase' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    public static void staircase(int n)
    {

        
        for (int x=0; x<n; x++) //riga
        {
            for (int y=1; y<n+1; y++) //colonna
            {
                // Console.WriteLine($"x:{x} y{y}");
                if (x > (n-y-1)) Console.Write("#");
                 else Console.Write(" ");
            }
            
            Console.WriteLine("");
            
        }
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        Result.staircase(n);
    }
}

