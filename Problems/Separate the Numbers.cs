 
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
using System.Numerics;
using System;

class Result
{
    
    /*
     * Complete the 'separateNumbers' function below.
     *
     * The function accepts STRING s as parameter.
     */
     
     
     // 1 a[i] - a[i-1] = 1
     // 1 ogni gruppo successivo deve essere maggiore del precedente
     // 2 una cifra non puo' iniziare per zero
     // 3 non si puo modificare la stringa del cazzo
     
     // ritorna NO se non possibile
     // ritorna YES {x} dove x e il primo gruppo
     //                 se ci sono piu possibilita usa la piu' piccola
     
    private static readonly bool debug = true;

    
        public static void separateNumbers(string s)
        {
            bool isValid = false;
            String subString = "";
            for (int i = 1; i <= s.Length / 2; i++)
            {
                subString = s.Substring(0, i);
                String valid = subString;
                long num = long.Parse(subString);
                while (valid.Length < s.Length)
                {
                    valid += (++num).ToString();
                }
                if (s==valid)
                {
                    isValid = true;
                    break;
                }
            }
            String x = isValid ? "YES " + subString : "NO";
            Console.WriteLine(x);
        }

    

}

class Solution
{
    public static void Main(string[] args)
    {
        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            Result.separateNumbers(s);
        }
    }
}
 
