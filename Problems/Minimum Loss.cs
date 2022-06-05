 
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
using System.Diagnostics;
using System;


class Result
{

    /*
     * Complete the 'minimumLoss' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts LONG_INTEGER_ARRAY price as parameter.
     */

    public static int minimumLoss(List<long> price)
    {
        double loss = int.MaxValue;
        
        var prezzi= new Dictionary<long, int>();
        
        for (int i=0; i<price.Count; i++)
        {
            prezzi.Add(price[i], i);
        }

        var prezziOrdinati = prezzi.OrderBy(x => x.Key);
        
        long prezzoIeri=int.MinValue;
        long posIeri = int.MinValue;
    
        long prezzoOggi = int.MinValue;
        long posOggi = int.MinValue;
        
        
        foreach (var i in prezziOrdinati)
        {
            prezzoOggi=i.Key;
            posOggi=i.Value;
            
            if (prezzoIeri > int.MinValue)
            {
                long diffPrezzo = prezzoOggi-prezzoIeri;
                
                if (diffPrezzo < loss && posOggi < posIeri)
                    loss=diffPrezzo;                                        
            }
            
            prezzoIeri = prezzoOggi;            
            posIeri = posOggi;
            
        }
            
            
        return Convert.ToInt32(loss);
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<long> price = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(priceTemp => Convert.ToInt64(priceTemp)).ToList();

        int result = Result.minimumLoss(price);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
