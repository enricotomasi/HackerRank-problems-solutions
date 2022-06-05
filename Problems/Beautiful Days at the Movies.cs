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
     * Complete the 'beautifulDays' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER i --- Giorno inizio
     *  2. INTEGER j --- Giorno fine
     *  3. INTEGER k --- Divisore
     */

    public static int beautifulDays(int i, int j, int k)
    {
        int giorniBelli = 0;
        
        for (;i<=j;i++)
        {

            // string iStringa = i.ToString();
            
            // string iStringaReverse = "";
            
            // for (int x = iStringa.Length; x > 0; x--)
            // {
            //     iStringaReverse += iStringa[x-1];
            // }
            
            // int iReverse = Convert.ToInt32(iStringaReverse);
            
            int nr=i;
            int rem, reverse = 0;
            
            while(nr!=0)      
            {      
                rem=nr%10;        
                reverse=reverse*10+rem;      
                nr/=10;      
            }      
            
            
            int differenza = Math.Abs(i-reverse);
            if (differenza % k == 0) giorniBelli++; 
     
            
        }
        
        return giorniBelli;

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int i = Convert.ToInt32(firstMultipleInput[0]);

        int j = Convert.ToInt32(firstMultipleInput[1]);

        int k = Convert.ToInt32(firstMultipleInput[2]);

        int result = Result.beautifulDays(i, j, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
