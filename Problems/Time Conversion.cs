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
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        string risultato = "";

        string ore = s.Substring(0,2);
        Console.WriteLine($"Ore -{ore}-");
        
        string minuti = s.Substring(3,2);
        Console.WriteLine($"Minuti -{minuti}-");
        
        string secondi = s.Substring(6,2);
        Console.WriteLine($"Secondi -{secondi}-");
        
        string segno = s.Substring(8,2);
        Console.WriteLine($"Segno -{segno}-");
        
        int oreInt = Convert.ToInt32(ore);
        
        if (segno == "AM")
        {
            string oreStringMattina = ore;
            if (oreStringMattina == "12") oreStringMattina = "00";
            return ($"{oreStringMattina}:{minuti}:{secondi}");
        }
        
        if (segno == "PM")
        {
            int oreIntPomeriggio = oreInt+12;
            if (oreIntPomeriggio == 24) oreIntPomeriggio = 12;
            return ($"{oreIntPomeriggio.ToString()}:{minuti}:{secondi}");
        }
        
        return "error";
        
        
        
    }

}



class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.timeConversion(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}

