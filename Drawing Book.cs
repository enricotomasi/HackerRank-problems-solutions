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
     * Complete the 'pageCount' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n numero totale di pagine
     *  2. INTEGER p numero di pagina da raggiungere
     */

    public static int pageCount(int n, int p)
    {
        //si comincia
        int paginadritta = 0;
        
        Console.WriteLine("-----------");
        Console.WriteLine("Metodo dritto");
        
        
        if (p ==1)
        {
            paginadritta = 0;
            Console.WriteLine("Una sola pagina: dritto = 1"); 
        } 
        else
        {
            Console.WriteLine("Piu' di una pagina");
            decimal tempo = p/2;
            Console.WriteLine($"Tempo = {p} / 2 ovvero {tempo}");
            tempo = Math.Truncate(tempo);
            Console.WriteLine($"Tempo troncato =  {tempo}");
            paginadritta = Convert.ToInt32(tempo);
        }
        
        
        int paginastorta = 0;
        Console.WriteLine("-----------");
        Console.WriteLine("Metodo storto");
        
        if (p == n || (n%2!=0 && p == n-1) )
        {
            paginastorta = 0;
            Console.WriteLine($"Ultima pagina o penultima con numero di pagine pari = {paginastorta}"); 
        }
        else
        {
            Console.WriteLine("Piu' di una pagina");
            decimal tempo = (n-p)/2;
            Console.WriteLine($"Tempo = {n} - {p}/ 2 ovvero {tempo}");
            tempo = Math.Truncate(tempo);
            Console.WriteLine($"Tempo troncato =  {tempo}");
            paginastorta = Convert.ToInt32(tempo);
        }
        
        if (n%2==0 && p == n-1) 
        {
            paginastorta = 1;
        }
        
        
        Console.WriteLine("-----------");
        
        if (paginadritta < paginastorta) return paginadritta;
        else return paginastorta;
        

    }
    
    
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int result = Result.pageCount(n, p);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
