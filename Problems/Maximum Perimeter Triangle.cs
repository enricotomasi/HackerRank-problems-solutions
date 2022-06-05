 
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
     * Complete the 'maximumPerimeterTriangle' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts INTEGER_ARRAY sticks as parameter.
     */
     
    private static bool debug = false;

    public static List<int> maximumPerimeterTriangle(List<int> sticks)
    {
        long max=0;
        int lato1Max=0;
        int lato2Max=0;
        int lato3Max=0;
        
        for (int i=0; i<sticks.Count; i++)
        {
            for (int j=i+1; j<sticks.Count; j++)
            {
                for (int k=j+1; k<sticks.Count; k++)
                {
                    if (debug) Console.WriteLine($"{i}, {j}, {k}");
                    int[] lati = new int[3];
                    lati[0] = sticks[i];
                    lati[1] = sticks[j];
                    lati[2] = sticks[k];
                    
                    Array.Sort(lati);
                    
                    int lato1 = lati[0];
                    int lato2 = lati[1];
                    int lato3 = lati[2];
                    
                    if (debug) Console.WriteLine($"{lato1}x{lato2}x{lato3} - {lato1+lato2 > lato3 && lato1+lato3 > lato2 && lato2+lato3 > lato1}");
                    if ((lato1+lato2 > lato3 &&
                        lato1+lato3 > lato2 &&
                        lato2+lato3 > lato1)) //Verifica che il triangolo non sia degenerato
                    {
                        long perimetro = lato1+lato2+lato3;
                        if (debug) Console.WriteLine($"Perimetro: {perimetro} - Max: {max} --- {perimetro>=max}"); 
                        if (perimetro>=max || perimetro < 0)
                        {
                          if (debug) Console.WriteLine($"Trovato perimetro piu meglio: {perimetro} - {lato1}x{lato2}x{lato3}");
                          max = perimetro;
                          lato1Max=lato1;
                          lato2Max=lato2;
                          lato3Max=lato3;
                        }
                    }
                    
                }
            }
        }
    
        List<int> ritorno= new List<int>();
        
        if (max==0)
        {
            ritorno.Add(-1);
        }
        else
        {
            ritorno.Add(lato1Max);
            ritorno.Add(lato2Max);
            ritorno.Add(lato3Max);
        }
        
        return ritorno;
            
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> sticks = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sticksTemp => Convert.ToInt32(sticksTemp)).ToList();

        List<int> result = Result.maximumPerimeterTriangle(sticks);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
