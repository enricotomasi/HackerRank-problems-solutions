 
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
        int inp = Convert.ToInt32(Console.ReadLine().Trim());
        int posizione = 0;
        var arr = new StringBuilder[101];
        
     
        for(int i =0; i < 101; i++)
        {
               arr[i] = new StringBuilder();
        }
        
        for (int i = 0; i < inp/2; i++)
        {
            var data = Console.ReadLine().TrimEnd().Split(' ');
            posizione = int.Parse(data[0]);
            arr[posizione].Append("- ");
        }

        for (int i = inp/2; i < inp; i++)
        {
            var data = Console.ReadLine().TrimEnd().Split(' ');
            posizione = int.Parse(data[0]);
            arr[posizione].Append(data[1] + " ");
        }
        
        
        for (int i = 0; i < 101; i++)
        {
            Console.Write(arr[i].ToString());
        }
        
        
}
    
    
   
}
