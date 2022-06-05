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

    // Complete the jumpingOnClouds function below.
    static int jumpingOnClouds(int[] nuvole, int salto) {
    int energia = 100;
    int posizione = 0;
    int lunghezza = nuvole.Length-1;
    
    do
    {
        
        Console.WriteLine("-----------------------------------------------------------");
        Console.WriteLine($"Salto: {salto} - Lunghezza: {lunghezza} - Energia: {energia} - Posizione: {posizione}");
        energia--;
        Console.WriteLine($"Salto: {salto} - Lunghezza: {lunghezza} - Energia: {energia} - Posizione: {posizione}");
        posizione += salto;
        Console.WriteLine($"Salto: {salto} - Lunghezza: {lunghezza} - Energia: {energia} - Posizione: {posizione}");
        if (posizione > lunghezza)
        {
            posizione -= lunghezza;
            posizione--;
        }
         
        Console.WriteLine($"Salto: {salto} - Lunghezza: {lunghezza} - Energia: {energia} - Posizione: {posizione}");
        if (nuvole[posizione] == 1) energia-=2;;
        Console.WriteLine($"Salto: {salto} - Lunghezza: {lunghezza} - Energia: {energia} - Posizione: {posizione}");
    } while (posizione != 0);
    
        
    return energia;
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] nk = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nk[0]);

        int k = Convert.ToInt32(nk[1]);

        int[] c = Array.ConvertAll(Console.ReadLine().Split(' '), cTemp => Convert.ToInt32(cTemp))
        ;
        int result = jumpingOnClouds(c, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
