 
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
     * Complete the 'beautifulPairs' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY A
     *  2. INTEGER_ARRAY B
     */
     
     
    public static int beautifulPairs(List<int> A, List<int> B)
    {
        
        int ritorno = 0;
        for (int i=0; i<A.Count; i++)
        {
            int pos=B.IndexOf(A[i]);
            if (pos >=0)
            {
                B.RemoveAt(pos);
                ritorno++;
            }
        }
        
        if (ritorno<A.Count) return ritorno+1;
        else return ritorno-1;
    }
 

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> A = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList();

        List<int> B = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(BTemp => Convert.ToInt32(BTemp)).ToList();

        int result = Result.beautifulPairs(A, B);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
