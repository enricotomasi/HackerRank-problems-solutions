 
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

class Solution {

    // Complete the flatlandSpaceStations function below.
    
    //N = numero di citta
    //c = array, citta con la stazione spaziale
    //

    static int flatlandSpaceStations(int n, int[] c)
    {
        // floor(staz2-staz1)
        
        bool debug=false;
      
        Array.Sort(c);
        int ritorno=c[0];
                
        for (int i = 0; i<c.Length; i++)
        {
            if (debug) Console.WriteLine($"\nCiclo: {i}");
            int distTemp = 0;
            
            if (i == c.Length-1) //ultimo
            {
                distTemp = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(n-1-c[i])));
                if (debug) Console.WriteLine($"Ultima stazione! n-1-c[i] {n}-1-{c[i]}   = {(n-1-c[i])}");
            }
            else //normale
            {   
                distTemp = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(c[i+1]-1-c[i])/2));
                if (debug) Console.WriteLine($"c[i+1]-1-c[i] {c[i+1]}-1-{c[i]}  /2 = {(c[i+1]-1-c[i])/2}");
            }
            
          
            if (ritorno<distTemp) ritorno = distTemp; 
            
            if (debug) Console.WriteLine($"distTemp:{distTemp} - Ritorno: {ritorno}");
        }

        return ritorno;
    }
    
    
    //// Funziona ma impiega troppo tempo :-(
    ////
    // static int flatlandSpaceStations(int n, int[] c)
    // {
    //     // bool debug=false;
    //     int ritorno=0;
        
    //     for (int i=0; i<n; i++)
    //     {
    //         // if (debug) Console.WriteLine($"Citta: {i}");
            
    //         int distMin=int.MaxValue;
    //         foreach (int j in c)            
    //         {
    //             int distTemp=Convert.ToInt32(Math.Abs(Convert.ToDecimal(i) - Convert.ToDecimal(j) ) );
                
    //             if (distTemp<distMin) distMin =distTemp;
                                
    //             // if (debug) Console.WriteLine($"----> Distanza dalla stazione spaziale {j}={distTemp} --- Distanza minima: {distMin}");
    //         }
            
    //         if (ritorno < distMin) ritorno = distMin;
            
    //     }
        
        


    //     return ritorno;
    // }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nm = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nm[0]);

        int m = Convert.ToInt32(nm[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = flatlandSpaceStations(n, c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
