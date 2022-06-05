 
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
     * Complete the 'fairRations' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts INTEGER_ARRAY B as parameter.
     */
     
     // Alla fine tutti devono avere un numero di pagnotte pari

     // Se dai una pagnotta ad un tizio devi darla anche a quello prima o quello dopo
     // n -- n+1 || n-1
     
    public static bool isEven(int numero)
    {
        if (numero % 2 == 0) return true;
        else return false;
    }

    public static string fairRations(List<int> coda)
    {
        ///////////////////////////////
        bool debug=false; /////////////
        //////////////////////////////
        
        int lung=coda.Count();
        int ritInt=0;
        int conta=0;

        bool vadoAvanti=true;
        while(vadoAvanti)
        {
            conta++;

            int quantiDispari=0;
            for (int i=0; i<lung; i++)
            {
                if (debug) Console.Write($"{coda[i]} ");
                if (coda[i] % 2 != 0) quantiDispari++;
            }
           
            if (debug) Console.WriteLine();
           
            if (quantiDispari <=0)
            {
                if (debug) Console.WriteLine($"Tutti pari! Esco --{ritInt}--");
                break;
            }
                        
            
            //-----------------------------------------------------------------------------------
            
            
            if ( (lung <=2 && isEven(coda[0]) && !isEven(coda[1]) ) || (lung <=2 && !isEven(coda[0]) && isEven(coda[1]) ) ) return "NO";
            
             if ( ((conta>lung*5) && isEven(coda[lung-1]) && !isEven(coda[lung-2]))  ||  ((conta>lung*5) && !isEven(coda[lung-1]) && isEven(coda[lung-2])) ) return "NO";
          
            
            for (int i=0;i<lung;i++)
            {
                
                if (isEven(coda[i])) continue; //Se e pari salta il ciclo
                
                ritInt +=2;
                coda[i]++;
                
                
                if (i == lung -1) // ultimo
                {
                    coda[i-1]++;
                    continue;
                }
                
                
                if (i == 0) // primo
                {
                    coda[i+1]++;
                    continue;
                }
                
                coda[i+1]++;
 
            }
   
        }
        
       

       return ritInt.ToString();
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int N = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

        string result = Result.fairRations(B);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
