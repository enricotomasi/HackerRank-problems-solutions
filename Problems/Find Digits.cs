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
     * Complete the 'findDigits' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */

    public static int findDigits(int n)
    {
        int numero = n;
        
        int conta = 0;
        
        List<int> lista = new List<int>();
        int rem = 0;
        
        while(n!=0)      
        {      
        rem=n%10;        
        lista.Add(rem); 
        //Console.WriteLine(rem);
        n/=10;      
        }      
        
        Console.WriteLine("-----------------");
        
        foreach (int x in lista)
        {
            //Console.WriteLine(x);
            if (x != 0)
            {
                if (numero % x == 0) conta++;
            }
            
            
        }
        
        
        return conta;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.findDigits(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
