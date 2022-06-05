 
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
     * Complete the 'strangeCounter' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts LONG_INTEGER t as parameter.
     */
     
     
     public static long strangeCounter(long t)
    {
        long ritorno = 0;
        long marca = 3;
        
        while (t > marca)
        {
            t-=marca;
            marca *= 2;
        }
        
       ritorno = (marca-t+1);
       
        return ritorno;
    }

    // //Funziona ma impiega troppo tempo :-(
    // public static long strangeCounter(long t)
    // {
    //     bool debug = false;
    //     long ritorno = 0;
        
    //     if (debug) Console.WriteLine($"Numero: {t}");
        
    //     long ciclo=0;
    //     long moltiplica=3;
    //     long max=3;
    //     long numero=4;
    //     for (long i=0; i<t; i++)
    //     {
    //         if (i==max)
    //         {
    //             ciclo++;
    //             moltiplica*=2;
    //             max=i+moltiplica;
    //             numero=moltiplica+1;
    //         }
            
    //         numero--;
            
    //         if (debug) Console.WriteLine($"ciclo: {ciclo} moltiplica: {moltiplica} max: {max} i: {i} numero: {numero} ");
            
            
    //     }
        
    //     if (debug) Console.WriteLine($"\nNUMERO: {numero} ");
        
    //     ritorno=numero;
        
    //     return ritorno;
    // }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        long t = Convert.ToInt64(Console.ReadLine().Trim());

        long result = Result.strangeCounter(t);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
