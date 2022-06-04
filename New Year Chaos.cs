 
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
     * Complete the 'minimumBribes' function below.
     *
     * The function accepts INTEGER_ARRAY q as parameter.
     */
     
    public static void minimumBribes(List<int> q)
    {
        // // Funziona ma e' troppo lento   
        // int[] arr = q.ToArray();
        // int[] corruzioni = new int[arr.Length+1];
        
        // int passaggi = 0;
        
        // for (int i=0; i<arr.Length-1; i++)
        // {
        //     for (int a=0; a<arr.Length-1; a++)
        //     {
        //         if (arr[a] > arr[a+1])
        //         {
        //             int temp = arr[a];
        //             arr[a] = arr[a+1];
        //             arr[a+1] = temp;
        //             corruzioni[arr[a+1]]++;
        //             passaggi++;
        //             if (corruzioni[arr[a+1]]>2)
        //             {
        //                 Console.WriteLine($"Too chaotic");
        //                 return;
        //             }
        //         }
        //     }
        // }

        // Console.WriteLine(passaggi);
        // return;
        
        int conta=0;
        
        for (int i=q.Count-1; i>=0; i--)
        {
            if (q[i] - (i+1) >2)
            {
                Console.WriteLine("Too chaotic");
                return;
            }
            for (int j=Math.Max(0,q[i]-2); j<i; j++)
            {
                if (q[j]>q[i]) conta++;
            }
            
        }
        
        Console.WriteLine(conta);
        return;
        
        

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<int> q = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(qTemp => Convert.ToInt32(qTemp)).ToList();

            Result.minimumBribes(q);
        }
    }
}
