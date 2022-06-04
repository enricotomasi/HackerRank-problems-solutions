 
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
     * Complete the 'alternate' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */
     
    private static readonly bool debug = false;

    public static int alternate(string s)
    {
        if (debug) Console.WriteLine($"Stringa: {s}");
        
        int ritorno = 0;
        
        char[] cArr = s.ToCharArray();
        int lunghezza = cArr.Count();
        
        char[] cArrUnici = cArr.Distinct().ToArray();
        int contaCarUnici = cArrUnici.Count();
        
        if (debug) Console.WriteLine($"Caratteri unici: {contaCarUnici}: " + string.Join(" ", cArrUnici));
        
        List<string> stringhe = new List<string>();
        
        for (int i = 0; i< contaCarUnici; i++)
        {
            for (int j=i+1; j<contaCarUnici; j++)
            {
                string stringaTemp = "";
                for (int k=0; k<lunghezza; k++)
                {
                    if ( (cArr[k] == cArrUnici[i]) || (cArr[k] == cArrUnici[j]) )
                    {
                        stringaTemp += cArr[k];
                    }
                }
                stringhe.Add(stringaTemp);
            }
        }
        
        if (debug) Console.WriteLine($"Numero stringhe: {stringhe.Count}");
        
        foreach (string str in stringhe)
        {
            
            char[] cA = str.ToCharArray();
            
            char[] cAUnici = cA.Distinct().ToArray();
            
            char first = cAUnici[0];
            char second = cAUnici[1];
            
            bool primo = false;
            int conta = 0;
            
            foreach (char c in cA)
            {
                if (primo)
                {
                    if (c != first)
                    {
                        conta = -1;
                        break;
                    }
                }
                else
                {
                    if (c != second)
                    {
                        conta = -1;
                        break;
                    }
                }
                primo = !primo;
            }
            
            if (conta >= 0 && str.Length > ritorno)
            {
                if (debug) Console.WriteLine($"***Nuova stringa:{str} - Lunghezza: {str.Length}");
                ritorno = str.Length;
            }
 
            // if (debug) Console.WriteLine($"Stringa: {str} - 1: {first} 2:{second} --- {conta} >= 0 && {str.Length}> {ritorno} --- {conta >= 0} {str.Length > ritorno} = {conta >= 0 && str.Length > ritorno}");
            
            primo=false;
            conta = 0;
            
            foreach (char c in cA)
            {
                if (!primo)
                {
                    if (c != first)
                    {
                        conta = -1;
                        break;
                    }
                }
                else
                {
                    if (c != second)
                    {
                        conta = -1;
                        break;
                    }
                }
                primo = !primo;
            }
            
            
            if (conta >= 0 && str.Length > ritorno)
            {
                if (debug) Console.WriteLine($"***Nuova stringa:{str} - Lunghezza: {str.Length}");
                ritorno = str.Length;
            }
     
            // if (debug) Console.WriteLine($"Stringa: {str} - 1: {first} 2:{second} --- {conta} >= 0 && {str.Length}> {ritorno} --- {conta >= 0} {str.Length > ritorno} = {conta >= 0 && str.Length > ritorno}");
            
                
            
        }
   
        
        return ritorno;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int l = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int result = Result.alternate(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
