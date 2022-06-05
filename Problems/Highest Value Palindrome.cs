 
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
    private static readonly bool debug = false;
    public static string highestValuePalindrome(string s1, int n1, int k)
    {
        var s = s1.ToCharArray();
        int n = s1.Length;
        int camb = k;
        var visitato = new int[n];
        
        if (debug) Console.WriteLine($"Inizio: s:{s1} n:{n} k:{k}");
        
        if (k==1 && n == 1)
        {
            if (debug) Console.WriteLine("1 Cifra e 1 cambiamento, ritorno 9");
            return "9";
        }
        
        
        if (debug) Console.WriteLine("\nContiamo le differenze");
        int diff=0;
        for (int i=0; i<n/2; i++)
        {
            int j=n-i-1;
            if (s[i] != s[j])
            {
                if (debug) Console.WriteLine($"{i},{j}: {s[i]},{s[j]} *** DIVERSO ***");
                diff++;
            } 
            else
            {
                if (debug)Console.WriteLine($"{i},{j}: {s[i]},{s[j]}");
            }
            
        }
        if (debug) Console.WriteLine($"Differenze:{diff}");
        
        if (diff > k)
        {
            if (debug) Console.WriteLine($"\nNon mi bastano i cambiamenti. Esco! diff: {diff} maxCambiamenti: {k}");
            if (debug) Console.WriteLine($"-1");
            return "-1";
        }
        
        if (debug) Console.WriteLine("\nPalindromizzo la stringa e mi segno le caselle cambiate");
        for (int i=0; i<n; i++)
        {
            int j=n-i-1;
            if (s[i] != s[j])
            {
                int primo = Convert.ToInt32(s[i]);
                int secondo = Convert.ToInt32(s[j]);
                
                if (primo>secondo)
                {
                    s[j] = s[i];
                    visitato[j] = 1;
                    camb--;
                    if (debug) Console.WriteLine($"{i},{j} {s[i]},{s[j]} Il primo e' maggiore sostituisco il secondo. Cambiamenti rimanenti: {camb}");
                }
                else
                {
                    s[i] = s[j];
                    visitato[i] = 1;
                    camb--;
                    if (debug) Console.WriteLine($"{i},{j} {s[i]},{s[j]} Il primo e' maggiore sostituisco il secondo. Cambiamenti rimanenti: {camb}");
                }
            }
        }
        
        if (debug) Console.WriteLine(string.Join("", s));
        
        if (debug) Console.WriteLine("\nMettiamo a 9 le coppie fino a che abbiamo cambiamenti");
        
        for (int i=0; i<n; i++)        
        {
            if (camb <=0) break;
            
            int j=n-i-1;
            
            if (s[i] != '9' && s[j] != '9')
            {
                int cambNecessari = 0;
                if (visitato[i] != 1) cambNecessari++;
                if (visitato[j] != 1) cambNecessari++;
                if (camb < cambNecessari) continue;
                s[i] = '9';
                s[j] = '9';
                camb -= cambNecessari; 
                if (debug) Console.WriteLine($"{i},{j} {s[i]},{s[j]} Entrambi diversi da 9. CambNecessari:{cambNecessari} CambRimasti: {camb}");               
            }
            else if (s[i] !='9')
            {
                int cambNecessari = 0;
                if (visitato[i] != 1) cambNecessari++;
                s[i] = '9';
                camb -= cambNecessari;  
                if (debug) Console.WriteLine($"{i},{j} {s[i]},{s[j]} Primo diverso da 9. CambNecessari:{cambNecessari} CambRimasti: {camb}");               
                
            }
            else if (s[j] != '9')
            {
                int cambNecessari = 0;
                if (visitato[j] != 1) cambNecessari++;
                s[j] = '9';
                camb -= cambNecessari; 
                if (debug) Console.WriteLine($"{i},{j} {s[i]},{s[j]} Secondo diverso da 9. CambNecessari:{cambNecessari} CambRimasti: {camb}");               
                 
            }
            else
            {
                if (debug) Console.WriteLine($"{i},{j} {s[i]},{s[j]} Sono gia' enntrambi 9, non faccio niente. CambRimasti: {camb}");               
            }
            
        }
        
        if (debug) Console.WriteLine(string.Join("", s));
        
        
        if (debug) Console.WriteLine("\nSe la lunghezza e' dispari e ho ancora un cambiamento cambio la cifra centrale");
        
        if (n%2!=0 && camb >0)
        {
            s[(n/2)] = '9';
            if (debug) Console.WriteLine("Cambiata!");
        }
                
        
        if (debug) Console.WriteLine(string.Join("", s));
        return new string(s);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        string s = Console.ReadLine();

        string result = Result.highestValuePalindrome(s, n, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
