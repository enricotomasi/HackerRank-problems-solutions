 
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
   
    public static int hackerlandRadioTransmitters(List<int> ab, int potenza)
    {
        int trasmettitori=0;
        var stato = new int[100002];
        int j = 0;
        
        for (int i=0; i<ab.Count; i++)        
        {
            stato[ab[i]]=1;
        }
       
        for (int i=0; i<100001; i++)
        {
            if (stato[i]!=0)
            {
                j=i+potenza;
                if (j>100001)
                {
                    trasmettitori++;
                    break;  
                } 
                while (stato[j] == 0 && j>=i)
                {
                    j--;
                }
                trasmettitori++;
                i=j+potenza;
            }
            
            
        }
       
        return trasmettitori;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> x = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(xTemp => Convert.ToInt32(xTemp)).ToList();

        int result = Result.hackerlandRadioTransmitters(x, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
