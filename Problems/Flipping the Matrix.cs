 
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
     * Complete the 'flippingMatrix' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
     */

    public static int flippingMatrix(List<List<int>> matrix)
    {
        int totale=0;
        int lato = matrix.Count;
        int n =  matrix.Count/2;
        int inizioPrimoQuadrante = 0;
        int finePrimoQuadrante = n;

        for (int riga=inizioPrimoQuadrante; riga<finePrimoQuadrante; riga++)
        {
            for (int colonna=inizioPrimoQuadrante; colonna<finePrimoQuadrante;colonna++)
            {
                var valoriTemp = new List<int>();
                valoriTemp.Add(matrix[riga][colonna]);
                valoriTemp.Add(matrix[riga][(2*n-1)-colonna]);
                valoriTemp.Add(matrix[(2*n-1)-riga][colonna]);
                valoriTemp.Add(matrix[(2*n-1)-riga][(2*n-1)-colonna]);
                totale += valoriTemp.Max();            
            }
        }
        
        return totale;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < 2 * n; i++)
            {
                matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            }

            int result = Result.flippingMatrix(matrix);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
