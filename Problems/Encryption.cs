 
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
     * Complete the 'encryption' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string encryption(string s)
    {
        bool debug=false;
        
        string ritorno = "";
        
        string senzaSpazi=s.Trim(' ');
        if (debug) Console.WriteLine($"senzaSpazi: {senzaSpazi}");
        
        double radiceQ=Math.Sqrt(senzaSpazi.Length);
        double righe=Math.Floor(radiceQ);
        double colonne=Math.Ceiling(radiceQ);
        
        if (debug) Console.WriteLine($"radiceQ={radiceQ} - righe: {righe} - colonne: {colonne}");
        if (debug) Console.WriteLine($"Lunghezza: {s.Length} - Area: {righe*colonne}");
        
        if ((righe*colonne) < s.Length) //L'area non basta per inserire la stringa
        {
            if ((righe+1)*colonne > righe*(colonne+1))
            {
                righe++;
            }
            else if ((righe+1)*colonne == righe*(colonne+1))
            {
                righe++;
            }
            else
            {
                colonne++;                
            }
            
            
        }
        
       
        char[,] arrei = new char[Convert.ToInt32(righe),Convert.ToInt32(colonne)];
                
        for (int x=0; x<Convert.ToInt32(righe);x++) //righe
        {
            for (int y=0; y<Convert.ToInt32(colonne);y++) //colonne
            {
                char aggiungi = '-';
                try
                {
                    aggiungi = s[(Convert.ToInt32(colonne)*x)+y];
                }
                catch
                {
                    aggiungi = ' ';
                }
                
                arrei[x,y]=aggiungi;
                if (debug) Console.Write(aggiungi);
            }
            if (debug) Console.WriteLine();
        }

        for (int a=0; a<Convert.ToInt32(colonne); a++)
        {
            for (int b=0; b<Convert.ToInt32(righe);b++)
            {
                char carattere = arrei[b,a];
                if (carattere != ' ')
                {
                   ritorno +=carattere; 
                }
                 
            }
            ritorno += " ";
            
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

        string result = Result.encryption(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
