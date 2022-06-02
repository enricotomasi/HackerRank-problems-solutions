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
     * Complete the 'chocolateFeast' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. INTEGER c
     *  3. INTEGER m
     */

    public static int chocolateFeast(int n, int c, int m)
    {
        int soldi = n;
        int costo = c;
        int involucriRegalo = m;
        
        // Console.WriteLine("-------------------");
        
        // Console.WriteLine($"Soldi: {soldi} - Costo cioccolato: {costo} - involucriRegalo: {involucriRegalo}");
        
        int cioccolate = 0;
        
        decimal divisione = soldi/costo;
        
        // Console.WriteLine($"Divisione = {divisione}");
        
        cioccolate = Convert.ToInt32(Math.Floor(divisione));
        soldi = soldi%cioccolate;
        
        // Console.WriteLine($"Soldi: {soldi} - Ciccolate: {cioccolate} ");
        
        
        int involucri= cioccolate;
        // Console.WriteLine ($"Involucri: {involucri} - InvolucriRegalo: {involucriRegalo}  --- involurcri e maggiore/uguale? {involucri >= involucriRegalo}  ");
        while (involucri >= involucriRegalo)
        {
            Console.WriteLine("-");
            decimal div = involucri / involucriRegalo;
            cioccolate += Convert.ToInt32(Math.Floor(div));
            involucri = (involucri % involucriRegalo) + Convert.ToInt32(Math.Floor(div));
            // Console.WriteLine($"Involucri: {involucri} - Ciccolate: {cioccolate}");
        }
        
        
        // Console.WriteLine($"Ritorno: {cioccolate}");
        return cioccolate;
        

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
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int c = Convert.ToInt32(firstMultipleInput[1]);

            int m = Convert.ToInt32(firstMultipleInput[2]);

            int result = Result.chocolateFeast(n, c, m);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
