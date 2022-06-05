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
     * Complete the 'sockMerchant' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER_ARRAY ar
     */

    public static int sockMerchant(int n, List<int> ar)
    {

        List<int> calziniUnici = new List<int>();
        
        //Trova numeri unici nei calzini
        foreach (int x in ar)
        {
            if (!calziniUnici.Contains(x))
            {
              calziniUnici.Add(x); 
              Console.WriteLine($"Calzino unico: {x}");  
            }
                
        }   
        
        int coppie = 0;
        
        Console.WriteLine();
               
        foreach (int x in calziniUnici)
        {
            int contaTemp = 0;
            foreach (int y in ar)
            {
                if (y == x) 
                {
                    contaTemp++;
                    Console.WriteLine($"Calzino {y} - conta {contaTemp}");   
                }
            }
           
            if (contaTemp %2 != 0)
            {
                Console.WriteLine($"Contatemp dispari: {contaTemp}");
                contaTemp--;
                Console.WriteLine($"Nuovo contatemp: {contaTemp}");
            }
            
            Console.WriteLine("-");
            
            
            if (contaTemp >= 2)
            {
                Console.WriteLine($"Vecchio coppie {coppie}");
                coppie+= contaTemp/2;
                Console.WriteLine($"Nuovo coppie {coppie}");
            } 
        
        Console.WriteLine("-");
                                    
        }
        
        return coppie;
        
    }
    
    
    
    
    
    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ar = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arTemp => Convert.ToInt32(arTemp)).ToList();

        int result = Result.sockMerchant(n, ar);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
