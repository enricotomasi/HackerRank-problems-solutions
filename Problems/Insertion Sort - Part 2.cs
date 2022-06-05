 
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
     * Complete the 'insertionSort2' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY arr
     */

    public static void insertionSort2(int n, List<int> arr)
    {
        bool debug=false;
        
        if (debug) Console.Error.WriteLine($"N: {n}");
        
        for (int i=0; i<n-1; i++)
        {
            
            if (arr[i] > arr[i+1])
            {
                int daSost = arr[i+1];
                if(debug) Console.Error.WriteLine($"\nCiclo {i} daSost: {daSost}");
                int pos = 0;
                
                //Trova la posizione
                for (int j=0; j<n; j++)
                {
                    if(debug) Console.Error.WriteLine($"--CicloDaSost {j}  DaSost: {daSost} arr[j] = {arr[j]}");
                    if (daSost < arr[j])
                    {
                        pos=j;
                        break;
                    }
                }
                if(debug) Console.Error.WriteLine($"-- DaSost: {daSost} - pos: {pos}");
                
                //Sposta array
                List<int> copia = new List<int>(arr);
                
                if (debug)
                {
                    Console.Error.Write("--- ARRAY NORMALE --- ");
                    for (int k=0; k<n; k++)
                    {
                        Console.Error.Write($"{arr[k]} ");
                    }
                    Console.Error.WriteLine();
                    
                    
                    Console.Error.Write("--- ARRAY COPIA --- ");
                    for (int k=0; k<n; k++)
                    {
                        Console.Error.Write($"{copia[k]} ");
                    }
                    Console.Error.WriteLine();
                    
                    
                }
                
                bool doppio=false;
                for (int j=pos+1; j<n; j++)
                {
                    if (copia[j-1] == daSost) doppio=true;
                            
                    if (doppio) arr[j] = copia[j];
                    else  arr[j] = copia[j-1];

                   
                }
                
                if(debug) Console.Error.WriteLine($"Fine ciclo sposta - arr[{i}] = {daSost}");
                arr[pos] =daSost;

                
            }
            
            //Stampa array
            for (int k=0; k<n; k++)
            {
                Console.Write($"{arr[k]} ");
                if (debug) Console.Error.Write($"{arr[k]} ");
            }
            Console.WriteLine();
            if (debug) Console.Error.WriteLine();
            
            
            
             
            
        }
        
        
        

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.insertionSort2(n, arr);
    }
}

