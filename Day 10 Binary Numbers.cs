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
        
        string nbinario = Convert.ToString(n,2);
        
       
        //Console.WriteLine($"Binario, attenzione passa il treno: {nbinario}");
        
        int max = 0;
        char vecchio = '0';
        int conta = 0;
        int contafor = 0;
        
        foreach (char x in nbinario)
        {
            
            contafor++;
            if (contafor == 1)
            {
                vecchio = x;
                
                if (x == '1')
                 {
                    conta++;
                    max++;
                 }
            }
            else
            {
            
            
            
           if (x == '0') conta = 0;
           if (x == '1') conta++;
           if (conta > max) max = conta;
           
           
                
            vecchio = x;
            
            }             
           
            
        }
        
        Console.WriteLine(max);
        
        
        
        
    }
}
