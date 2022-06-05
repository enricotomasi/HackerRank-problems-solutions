 
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
     * Complete the 'theLoveLetterMystery' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */
     
    public static bool debug = false;

    public static int theLoveLetterMystery(string s)
    {
        int ritorno=0;
        
        int lungh = s.Length;
        int mezzaLungh = Convert.ToInt32(Math.Floor(Convert.ToDouble(lungh)/2));
        
        bool pari=true;
        if (lungh%2 != 0) pari = false;
        
        if (debug) Console.WriteLine($"\nStringa: {s} - Lung: {lungh} - Mezza Lungh: {mezzaLungh} - pari: {pari}");
        
        string inizio=s.Substring(0,mezzaLungh);
        string mezzo="";
        if (!pari) mezzo=s.Substring(mezzaLungh,1);
        string fine = "";
        if (!pari) fine = s.Substring(mezzaLungh+1);
        else fine = s.Substring(mezzaLungh);
        
        string fineRev= "";
        
        for (int i=fine.Length-1; i>=0; i--)
        {
            fineRev+=fine[i];
        }
        
        if (debug) Console.WriteLine($"{inizio} - {mezzo} - {fine} ------ fineRev: {fineRev}");
        

        for (int i =0; i< inizio.Length; i++)
        {
            char prima = inizio[i];
            char seconda = fineRev[i];
            
            if (debug) Console.WriteLine($"-Ciclo cambia1 - {prima} {seconda}");
            
            if (prima != seconda)
            {
                ritorno+= Math.Abs((int)prima - (int)seconda);
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

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.theLoveLetterMystery(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
