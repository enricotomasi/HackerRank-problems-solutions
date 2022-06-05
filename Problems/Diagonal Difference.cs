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
     * Complete the 'diagonalDifference' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int diagonalDifference(List<List<int>> arr)
    {
        
        int diag1 = 0;
        int diag2 = 0;
        
        int conta1 = 0;
        int conta2 = arr.Count + 1;
        
        int contaInterno = 0;
        
        int contaRiga = 0;
        
        Console.WriteLine($"Lunghezza {conta2}");        
                
          foreach (var sublist in arr)
        {
            conta1++;
            conta2--;
            
            contaRiga++; //DEBUG
            
            contaInterno = 0;
            
            Console.WriteLine($"---RIGA: {contaRiga}--- Conta1 = {conta1} - Conta2 = {conta2}");
            
            foreach (var value in sublist)
            {
                
                // 
                
                contaInterno++;
                Console.Write(value);
                Console.Write(' ');
                
                if (contaInterno == conta1) diag1 +=value;
                if (contaInterno == conta2) diag2 +=value;

                Console.WriteLine($"diag1= {diag1} - diag2 = {diag2}");
                
            }
            Console.WriteLine();
        }        
        
        int risultato = Math.Abs(diag1-diag2);
        
        Console.WriteLine($"diag1= {diag1} - diag2 = {diag2} --- Risultato: {risultato}");        
        
        return risultato;
        
               
    }
    
    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.diagonalDifference(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
