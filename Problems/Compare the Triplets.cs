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
     * Complete the 'compareTriplets' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY a
     *  2. INTEGER_ARRAY b
     */

    public static List<int> compareTriplets(List<int> a, List<int> b)
    {
        int puntiBob = 0;
        int puntiAlice = 0;
        
       for (int x=0; x<3; x++)
       {
           
           Console.WriteLine($"x = {x}");

           if (a[x] > b[x])
           {
               puntiAlice++;
               Console.WriteLine($"a {a[x]} - b {b[x]} +1 Alice");
           }
           
           if (a[x] < b[x])
           {
               puntiBob++;
               Console.WriteLine($"a {a[x]} - b {b[x]} +1 Bob");
           }
           Console.WriteLine("Fine ciclo");
       }
        
    List<int> ritorno = new List<int>();
           
    ritorno.Add(puntiAlice);
    ritorno.Add(puntiBob);
           
    Console.WriteLine("Ritorno");
    return ritorno;
              
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        List<int> b = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(bTemp => Convert.ToInt32(bTemp)).ToList();

        List<int> result = Result.compareTriplets(a, b);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
