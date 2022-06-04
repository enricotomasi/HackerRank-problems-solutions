 
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

    public static int activityNotifications(List<int> spese, int d)
    {
        
        var expenditure = spese.ToArray();
        
        int notifications = 0;
        var arr = new int[d];
        Array.Copy(expenditure, arr, d);
        Array.Sort(arr);
        for (int i = d; i < expenditure.Length; i++)
        {
            if (expenditure[i] >= arr[d / 2] + arr[(d - 1) / 2])
            {
                notifications++;
            }
            int index = Array.BinarySearch(arr, expenditure[i - d]);
            Array.Copy(arr, index + 1, arr, index, d - index - 1);
            index = Array.BinarySearch(arr, 0, d - 1, expenditure[i]);
            index = index >= 0 ? index : ~index;
            Array.Copy(arr, index, arr, index+1, d - index - 1);
            arr[index] = expenditure[i];
        }
        return notifications;
        
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int d = Convert.ToInt32(firstMultipleInput[1]);

        List<int> expenditure = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(expenditureTemp => Convert.ToInt32(expenditureTemp)).ToList();

        int result = Result.activityNotifications(expenditure, d);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
