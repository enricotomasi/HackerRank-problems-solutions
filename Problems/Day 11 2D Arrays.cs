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

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }
        
        List<int> clessidre = new List<int>();
        
        //Console.WriteLine(arr[4][3]);
        for (int x = 0; x<4; x++) // riga
        {
            for (int y = 0; y < 4; y++) //colonna
            {
                //Console.WriteLine($"{x},{y}");
                int riga1 = arr[x][y] + arr[x][(y+1)] + arr[x][(y+2)];
                int riga2 = arr[(x+1)][(y+1)];
                int riga3 = arr[(x+2)][y] + arr[(x+2)][(y+1)] + arr[(x+2)][(y+2)];
                int clessi = riga1+riga2+riga3;
                
                // Console.WriteLine(riga1);
                // Console.WriteLine(riga2);
                // Console.WriteLine(riga3);
                // Console.WriteLine(clessi);
                // Console.WriteLine();
                
                
                clessidre.Add(clessi);
            } 
        }
        
        int max = int.MinValue;
        
        foreach (int x in clessidre)
        {
            if (x > max)
            {
                max = x;
                //Console.WriteLine($"X: {x} --- MAX: {max}"); 
            } 
        }
        
        Console.WriteLine(max);
        
        
        
    }
}
