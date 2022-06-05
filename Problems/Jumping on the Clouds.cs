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
     * Complete the 'jumpingOnClouds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY c as parameter.
     */

    public static int jumpingOnClouds(List<int> c)
    {
        int salti = 0;
        int lunghezza = c.Count;
        int tuoni = 0;
        
        for (int x = 0; x < lunghezza; x++)
        {
            //Console.WriteLine($"\n{x}");
            
            // Console.WriteLine($"x: {x} - Lunghezza-2: {lunghezza-2}");
            
            if (x == lunghezza-2)
            {
                salti++;
                x++;
            }
            else if (x == lunghezza-1)
            {
                //non fare un cazzo
            }
            else if (c[x+2] != 1)
            {
                //Console.Write("Salto Doppio");
                x++;
            }
      
            salti++;
            
            //Console.WriteLine($"Salti: {salti}");
            
        }
        
        //Console.WriteLine($"\n\n --- Salti: {salti}");
        
        return salti-1;
        
        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt32(cTemp)).ToList();

        int result = Result.jumpingOnClouds(c);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
  
