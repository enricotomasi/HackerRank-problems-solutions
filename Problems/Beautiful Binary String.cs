 
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
     * Complete the 'beautifulBinaryString' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING b as parameter.
     */

    public static bool debug = false;

    public static int beautifulBinaryString(string b)
    {
        int ritorno = 0;
        
        for (int i =0; i< b.Length-2; i++)
        {
            int uno = Convert.ToInt32(b[i]);  
            int due = Convert.ToInt32(b[i+1]);
            int tre = Convert.ToInt32(b[i+2]);
            
            if (debug) Console.WriteLine($"Ciclo: {i} --- {b}");
            if (debug) Console.WriteLine($"{uno}-{due}-{tre}");
        
            if (uno == 48 && due == 49 && tre == 48)
            {
                b=b.Substring(0,i+1) + "0" + b.Substring(i+2);
                ritorno++;
                if (debug) Console.WriteLine($"Ritorno: {ritorno}");
                i+=2;
                
            }
            
            
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

        string b = Console.ReadLine();

        int result = Result.beautifulBinaryString(b);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
