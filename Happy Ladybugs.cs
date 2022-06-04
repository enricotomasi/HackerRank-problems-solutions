 
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
     * Complete the 'happyLadybugs' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING b as parameter.
     */

    public static string happyLadybugs(string b)
    {
        bool debug = false;
        int lungh = b.Count();
   
        if (lungh==1 && b[0]=='_')
        {
          if (debug) Console.WriteLine("lunghezza 1 e carattere _ nessuna ladybug infelice! YES");
          return "YES";  
        } 

        if (lungh ==1 && b[0] !='_') return "NO";
        
        int vuoti=0;
        int[] arr = new int[256];
        
        if (debug) Console.WriteLine("\n");
        
        bool giaFelice=true; 
        for (int i=0; i<lungh; i++)
        {
            if (b[i] == '_') vuoti++;
            else
            {
                arr[(int)b[i]]++;
            }
            if (debug) Console.WriteLine($"{b[i]} - {(int)b[i]}:{arr[(int)b[i]]}");
            
            if (i!=0 && i!=lungh-1)
            {
                if ( ! (b[i] == b[i-1] || b[i] == b[i+1]) ) giaFelice=false;
            }
          
        }
   
        bool sonTuttiVuoti=true;
        int tipiDiversi=0;
     
        for (int i=0; i<256; i++)
        {
            if (debug) Console.Write($"{arr[i]}");
            if (arr[i] != 0)
            {
                if (arr[i] == 1) return "NO";
                sonTuttiVuoti=false;
                tipiDiversi++;
            }

        }
        
        if (debug) Console.WriteLine($"\nVuoti:{vuoti} - Lunghezza: {lungh} - sonTuttiVuoti: {sonTuttiVuoti} - TipiDiversi: {tipiDiversi}");
        
        if (tipiDiversi==1) return "YES";
        
        if (lungh==2 && tipiDiversi >1) return "NO";

        if (giaFelice)
        {
            if (debug) Console.WriteLine("Gia felice!");
            return "YES";
        }
        
        if (tipiDiversi==0) return "YES";
        
        if (sonTuttiVuoti)
        {
            if (debug) Console.WriteLine("YES Son tutti vuoti");
            return "YES";
        }
        
        if (vuoti == 0) return "NO";
        else return "YES";
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

            string b = Console.ReadLine();

            string result = Result.happyLadybugs(b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
