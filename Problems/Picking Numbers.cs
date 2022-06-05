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
     * Complete the 'pickingNumbers' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY a as parameter.
     */

    public static int pickingNumbers(List<int> a)
    {
       int max = 0;
       int lunghezza = a.Count;
          
       for (int x = 0; x < lunghezza; x++)
       {
        
        List<int> listaTemp = new List<int>();
        Console.WriteLine();    
               
        for (int y = 0; y < lunghezza; y++)
           {
               if (y == 0)
               {
                  listaTemp.Add(a[x]);
                  Console.WriteLine($"Aggiungo primo elemento {a[x]}"); 
               } 
               if (x==y) continue;
               Console.Write($"X:{x} Y:{y} --- ");               
               
               bool aggiungo = true;
               foreach (int e in listaTemp)
               {
                   if (Math.Abs(a[y] - e) >1)
                   {
                       aggiungo = false;
                       //Console.Write($" ABS( {a[y]} - {e} ) = {Math.Abs(a[y] - e} aggiungo = {aggiungo}");
                   } 
                   else
                   {
                       //
                   }                
               }

               Console.WriteLine();
                if (aggiungo)
                {
                    listaTemp.Add(a[y]);
                    Console.WriteLine($"*** AGGIUNGO ALLA LISTA {a[y]}");
                } 
            
           }
           
           Console.WriteLine();
           
           //Controlliamo se la lista e piu lunga **** MALEDETTO ASCII ****
           int lun_temp = listaTemp.Count;
           if (lun_temp > max)
           {
               Console.Write($"Lungezza = {lun_temp} Max = {max} --- ****** Trovata nuova lungehzza massima ******");
               max = lun_temp;
           }       
           else
           {
               Console.Write($"Lungezza = {lun_temp} Max = {max} --- C'e una lista piu lunga :(");
           }
           
           
           Console.WriteLine();
           
       }

        if (max == 1) max--;

        return max;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        int result = Result.pickingNumbers(a);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
