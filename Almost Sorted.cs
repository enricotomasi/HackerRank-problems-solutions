 
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

    private static void logga(string msg)
    {
        //Console.Error.WriteLine(msg);        
    }
    
    /*
     * Complete the 'almostSorted' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void almostSorted(List<int> arr)
    {
                
        List<int> arrSort = new List<int>(arr);
        arrSort.Sort();
        
        List<int> arrCopia = new List<int>(arr);
        
        logga("Orig: " + string.Join(" ",arr));
        logga("Sort: " + string.Join(" ",arrSort));
        
        List<int> diff = new List<int>();
        
        for (int i=0; i<arr.Count; i++)
        {
            if (arr[i] != arrSort[i]) diff.Add(i);
        }
        
        logga("Diff: " + string.Join(" ", diff));
        
        if (diff.Count <=0) // e' gia' ordinato
        {
            Console.WriteLine("yes"); // lo sapevo!
            return;
        }
        
        if (diff.Count == 2) //se si puo' swappare
        {
            Console.WriteLine("yes"); //lo sapevo
            Console.WriteLine($"swap {diff[0]+1} {diff[1]+1}");
            return;
        }
        
        // Rimane: revesrse, reverse + swap
        
        int inizio = diff[0];
        int fine = diff[diff.Count-1];
        
        logga($"Sono piu' di due ({diff.Count}) --- Inizio: {inizio} Fine: {fine}");
        
        int conta=0;
        for (int i=inizio; i<=fine; i++)
        {
            logga($" - ciclo: {i} arrCopia[i] = arr[fine-i] --- arrCopia[{i}] = arr[{fine-i}] --- {arrCopia[i]} = {arr[fine-i]}");
            
            arrCopia[i] = arr[fine-conta];
            conta++;
            
        }
        
        logga("Reve: " + string.Join(" ", arrCopia));
        
        List<int> diff2 = new List<int>();
        
        for (int i=0; i<arrCopia.Count; i++)
        {
            if (arrCopia[i] != arrSort[i]) diff2.Add(i);
        }
        
        logga("Dif2: " + string.Join(" ", diff2));
        
        if (diff2.Count <=0) // e' ordinato
        {
            Console.WriteLine("yes"); // lo sapevo!
            Console.WriteLine($"reverse {inizio+1} {fine+1}");
            return;
        }
        
        // A questo punto non ha funzionato ne lo swap ne il reverse! :(
        
        if (diff2.Count >=2)
        {
            Console.WriteLine("no"); // non lo sapevo
            return;
        }
            
    

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.almostSorted(arr);
    }
}
