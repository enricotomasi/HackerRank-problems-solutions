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
     * Complete the 'dayOfProgrammer' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER year as parameter.
     */

    public static string dayOfProgrammer(int year)
    {
        Console.WriteLine($"*** Anno: {year}");
        
        if (year == 1918) return "26.09.1918";
                
        int giorno = 0;
               
        if (year <= 1917) //calendario giuliano
        {
            Console.WriteLine("Calendario Giuliano");
            if (year % 4 == 0) //bisestile
            {
                Console.WriteLine("Bisestile");
                giorno = 256-244;
            }
            else //non bisestile
            {
                Console.WriteLine("NON Bisestile");
                giorno = 256-243;
            }
            
        }
        else //calendario gregoriano
        {
            
            Console.WriteLine("Calendario Gregoriano");
            
            if (year %400 == 0 || (year % 4 == 0 && year % 100 !=0)) //bisestile
            {
                Console.WriteLine("Bisestile");
                giorno = 256-244;
            }
            else //non bisestile
            {
                Console.WriteLine("NON Bisestile");
                giorno = 256-243;
            }
            
        }
        
        string dop = $"{giorno}.09.{year}";
            
        Console.WriteLine(dop);
            
        return dop;
            
        
        
        

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int year = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.dayOfProgrammer(year);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
