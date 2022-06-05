 
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
     * Complete the 'workbook' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n --- numero di capitoli
     *  2. INTEGER k --- numero massimo di problemi per pagina
     *  3. INTEGER_ARRAY arr --- numero di problemi per ogni capitolo
     */

    public static int workbook(int n, int k, List<int> arr)
    {
        int ritorno=0; 
        
        // Console.WriteLine($"Numero di capitoli: {n} - Max problemi x pagina: {k}");
        
        int numeroPagina=1;
        int problemiPagina=0;
        for (int i=0; i<n; i++) //ciclo numero di capitoli
        {
            int numeroProblemi= arr[i];
            int capitolo = i +1;
            // Console.WriteLine($"\nCapitolo: {capitolo} - N. Problemi: {numeroProblemi} - PAGINA: {numeroPagina}");
            
            for (int j=0; j<numeroProblemi; j++)
            {
                int problema = j+1;
             
                problemiPagina++;
                
                // Console.WriteLine($"Problema N. {problema} - pagina: {numeroPagina} - capitolo: {capitolo} --- parziale problemi/pagina: {problemiPagina}");
                
                 if (problema == numeroPagina)
                {
                    ritorno++;
                    // Console.WriteLine($"*******BINGO******** Problema N. {problema} - pagina: {numeroPagina} - capitolo: {capitolo} --- parziale problemi/pagina: {problemiPagina}");
                } 
                
                if (problemiPagina >= k)
                {
                    problemiPagina=0;
                    numeroPagina++;
                    // Console.WriteLine("Giro pagina");
                }
                
            }
            
            if (problemiPagina != 0)
            {
                numeroPagina++;
                problemiPagina = 0;
                // Console.WriteLine($"Salto pagina");
            }
            // else
            // {
            //     Console.WriteLine($"Non salto la pagina perche' e' vuota");
            // }
            
        }

        return ritorno;
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

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.workbook(n, k, arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
