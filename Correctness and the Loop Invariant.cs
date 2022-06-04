 
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


class Solution { 
    
    public static bool debug=false;
    
    public static void insertionSort (int[] A)
    { 
        
        var j = 0; 
        
        for (var i = 1; i < A.Length; i++)
        { 
            var value = A[i]; 
            if (debug) Console.Error.WriteLine($"\nCiclo: {i} - Lunghezza: {A.Length} --- Valore: ***{value}*** ");
            if (debug) Console.Error.WriteLine(string.Join(" ", A)); 
            
            j = i - 1; 
            
            if (debug) Console.Error.WriteLine($"Inizio sottociclo while fino a che {j} < 0  &&");
            if (debug && j>0) Console.Error.WriteLine($"j < A[J] -- {j} < {A[j]}");
            
            while (j >= 0 && value < A[j])
            { 
                if (debug) Console.Error.WriteLine($"---Sottociclo While {j} A[j + 1] = A[j] -- A[{j+1}] = a[{j}] -- {A[j+1]} = {A[j]}");
                A[j + 1] = A[j];
                j = j - 1; 
            } 
            
            if (debug) Console.Error.WriteLine($"-Assegno cifra sposata: A[j + 1] = value -- a[{j+1}] = {value} ");
            A[j + 1] = value; 
            
            if (debug) Console.Error.WriteLine(string.Join(" ", A)); 
            
        } 
        
        Console.WriteLine(string.Join(" ", A)); 
    }

    static void Main(string[] args) { 
        Console.ReadLine(); 
        int [] _ar = (from s in Console.ReadLine().Split() select Convert.ToInt32(s)).ToArray();
        insertionSort(_ar); 
    }
}

