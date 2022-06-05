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
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void miniMaxSum(List<int> arr)
    {
            long min = 0;
            long max = 0;
            
            foreach (int x in arr)
            {
                if (min == 0) min = x;
                
                if (min > x) min = x;
                if (max < x) max = x;
            }
            
            // Console.WriteLine ($"min: {min} - max: {max}");
            
            long sumMin = 0;
            long sumMax = 0;
            
            foreach (int x in arr)
            {
                if (x == min) sumMax +=x;
                else if (x == max) sumMin +=x;
                else 
                    {
                        sumMax +=x;
                        sumMin +=x;
                    }
            }
            
            if (min == max)
            {
                sumMin = min*4;
                sumMax = min*4;
            }


 Console.WriteLine ($"{sumMax} {sumMin}");
            



    }

}

class Solution
{
    public static void Main(string[] args)
    {

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        Result.miniMaxSum(arr);
    }
}
