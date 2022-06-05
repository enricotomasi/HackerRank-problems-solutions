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
     * Complete the 'hourglassSum' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY arr as parameter.
     */

    public static int hourglassSum(List<List<int>> arr)
    {
      
        int max = int.MinValue;
        
        for (int x = 0; x < 4; x++)
        {
            for (int y = 0; y <4; y++)
            {
                //Console.WriteLine($"{x},{y}"); 
                
                int oraVetro = 0;
                
                oraVetro += arr[x][y] + arr[x][y+1] + arr [x][y+2];
                oraVetro += arr[x+1][y+1];
                oraVetro += arr[x+2][y] + arr[x+2][y+1] + arr [x+2][y+2];
                
                if (oraVetro>max) max = oraVetro;
                
            }
            
            
        }



        return max;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> arr = new List<List<int>>();

        for (int i = 0; i < 6; i++)
        {
            arr.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList());
        }

        int result = Result.hourglassSum(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
