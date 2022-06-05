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
     * Complete the 'birthday' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY s
     *  2. INTEGER d
     *  3. INTEGER m
     */

    public static int birthday(List<int> s, int d, int m)
    {
                      
      // Lunghezza segmento = mese  (m)
      // Somma degli interi = giorno (d)
      
      // - - - - - - - - - - - 
      
      int ritorno = 0;
      
      //Lungezza array
      int lungArr = s.Count();
      
      for (int x = 0; x < lungArr -m +1 ; x++)
      {
          
          Console.WriteLine($"Ciclo esterno x = {x}");
          int somma = 0;
          for (int y = x; y < x + m; y++)
          {
              somma += s[y];
              Console.WriteLine($"Ciclo interno x = {x} y = {y}");
          }
          
          if (somma == d)
          {
              ritorno++;
              Console.WriteLine($"Match! Somma = {somma} --- x = {x}");
          }
          else
          {
                 Console.WriteLine($"SCARTATO Somma = {somma} --- x = {x}");
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

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> s = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList();

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int d = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        int result = Result.birthday(s, d, m);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
