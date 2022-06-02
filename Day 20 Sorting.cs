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



class Solution
{
    public static void Main(string[] args)
    {
        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> a = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(aTemp => Convert.ToInt32(aTemp)).ToList();

        // Write your code here
        // n = Numero elementi
        // a = array elementi
        
        int swap = 0;
        int min = 0;
        int max = 0;
        
        for (int x = 0; x<n; x++)
        {
            int tempSwap = 0;

            
            for (int y = 0; y < n-1; y++)
            {
                //Console.WriteLine($"Cicolo esterno {x}");
                if (a[y] > a[y+1])
                {
                    //Console.WriteLine($"Ciclo interno {y}");
                    
                    int t = a[y+1];
                    a[y+1] = a[y];
                    a[y] = t;
                    
                    tempSwap++;
                    swap++;
                }
            }
            
            if (tempSwap == 0) break;
            tempSwap = 0;
            
        }
                
        
        Console.WriteLine($"Array is sorted in {swap} swaps.");
        Console.WriteLine($"First Element: {a[0]}");
        Console.WriteLine($"Last Element: {a[n-1]}");
        
        
        
        
    }
}
