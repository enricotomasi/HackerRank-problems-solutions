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
     * Complete the 'bonAppetit' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY bill --- costi del cibo
     *  2. INTEGER k --- quello che non ha mangiato Anna (conta a partire da 0)
     *  3. INTEGER b --- quanti soldi ha dato Anna
     */

    public static void bonAppetit(List<int> bill, int k, int b)
    {
        int contoTot = 0;
        int conta = 0;
        foreach (int x in bill)
        {
            if (conta != k)
            {
                contoTot += bill[conta];
            }
            conta++;
        }
        
        if ((contoTot/2) == b) Console.WriteLine("Bon Appetit");
        else Console.WriteLine(b - (contoTot/2));
        
        
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> bill = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(billTemp => Convert.ToInt32(billTemp)).ToList();

        int b = Convert.ToInt32(Console.ReadLine().Trim());

        Result.bonAppetit(bill, k, b);
    }
}
