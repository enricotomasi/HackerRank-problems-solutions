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
     * Complete the 'libraryFine' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER d1
     *  2. INTEGER m1
     *  3. INTEGER y1
     *  4. INTEGER d2
     *  5. INTEGER m2
     *  6. INTEGER y2
     */

    public static int libraryFine(int d1, int m1, int y1, int d2, int m2, int y2)
    {
        int ritorno = int.MinValue;
        char pad = '0';
        
        DateTime giornoRestituzione = new DateTime();
        string gR = $"{y2.ToString().PadLeft(4, pad)}-{m2.ToString().PadLeft(2, pad)}-{d2.ToString().PadLeft(2, pad)}";
        Console.WriteLine($"Stringa gR: {gR}");
        giornoRestituzione = DateTime.ParseExact(gR, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        
        Console.WriteLine($"Giorno nel quale doveva restituire il libro: {giornoRestituzione}");
        
        Console.WriteLine("---"); //-------------------------------------------------------------------
        
        DateTime giornoVero = new DateTime();
        string gV = $"{y1.ToString().PadLeft(4, pad)}-{m1.ToString().PadLeft(2, pad)}-{d1.ToString().PadLeft(2, pad)}";
        Console.WriteLine($"Stringa gV: {gV}");
        giornoVero = DateTime.ParseExact(gV, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        
        Console.WriteLine($"Giorno vero: {giornoVero}");
        
        
        Console.WriteLine("---"); //-------------------------------------------------------------------
        
        int giorniRitardo = Convert.ToInt32(Math.Floor(((giornoVero-giornoRestituzione).TotalDays)));
        
        Console.WriteLine($"Giorni di ritardo: {giorniRitardo}");
        
        if (giorniRitardo <= 0)
        {
            Console.WriteLine("Restituito entro la data");
            return 0;
        }
         
        if (y1==y2 && m1==m2)
        {
            Console.WriteLine("Restituito entro la fine del mese");
            return giorniRitardo*15;
        }
        
        if (y1==y2)
        {
            Console.WriteLine("Restituito entro la fine dell'anno");
            return (m1-m2)*500;
        }
        
               
        return 10000;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int d1 = Convert.ToInt32(firstMultipleInput[0]);

        int m1 = Convert.ToInt32(firstMultipleInput[1]);

        int y1 = Convert.ToInt32(firstMultipleInput[2]);

        string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int d2 = Convert.ToInt32(secondMultipleInput[0]);

        int m2 = Convert.ToInt32(secondMultipleInput[1]);

        int y2 = Convert.ToInt32(secondMultipleInput[2]);

        int result = Result.libraryFine(d1, m1, y1, d2, m2, y2);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
