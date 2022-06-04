 
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
    private static readonly bool debug = true;
    public static int lilysHomework(List<int> arr)
    {
        var pos = 0;
        var dict = arr.ToDictionary(x => x, y =>
            {
                var res = pos;
                pos++;
                return res;
            });
        var pos2 = 0;
        var dict2 = arr.ToDictionary(x=> x, y=>
            {
                var res = pos2;
                pos2++;
                return res;
            });
        var list = new List<int>();
        foreach (var n in arr)
        {
            list.Add(n);
        }
        var list2 = new List<int>();
        foreach (var n in arr)
        {
            list2.Add(n);
        }
        arr.Sort();
        var diff = 0;
        for (var i = 0; i < arr.Count; i++)
        {
            if (i != dict[arr[i]])
            {
                var temp = list[i];
                var tempi = dict[arr[i]];
                list[i] = arr[i];
                dict[arr[i]] = i;
                dict[temp] = tempi;
                list[tempi] = temp;
                diff++;

            }
        }
        arr.Sort((x, y) => y - x);
        var diff2 = 0;
        for (var i = 0; i < arr.Count; i++)
        {
            if (i != dict2[arr[i]])
            {
                var temp = list2[i];
                var tempi = dict2[arr[i]];
                list2[i] = arr[i];
                dict2[arr[i]] = i;
                dict2[temp] = tempi;
                list2[tempi] = temp;
                diff2++;

            }
        }
        return Math.Min(diff, diff2);
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.lilysHomework(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
