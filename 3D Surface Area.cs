 
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
    
    //--------------------------------           ---------------------- DEBUG
    private static readonly bool debug = false;
    private static void logga<T>(T msg, bool aCapo = true)
    {
        if (debug && aCapo) Console.Error.WriteLine(msg.ToString());
        else if (debug) Console.Error.Write(msg.ToString());
    }
    //---------------------------------------------------------------- DEBUG

    /*
     * Complete the 'surfaceArea' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY A as parameter.
     */

    public static int surfaceArea(List<List<int>> A)
    {
        int area=0;
        
        int h = A.Count;
        int w = A[0].Count;
        
        if (debug)
        {
            logga("-----------------------");
            
            foreach (List<int> l in A)
            {
                foreach(int i in l)
                {
                    logga($"{i} ",false);
                }
                logga("");
            }
            logga("-----------------------\n");
       
            
        }
        
        for (int x=0; x<h; x++) //righe X
        {
            for (int y=0; y<w; y++) //colonne Y
            {
                //calcola lati scoperti
                int areaP = 2; // Il lato alto e basso son sempre scoperti
                int altezza = A[x][y];
                
                logga($"({x},{y}): {altezza}",false);
                
                if (x<=0) areaP += altezza;
                else
                {
                    int temp = altezza-A[x-1][y];
                    if (temp > 0) areaP+=temp;
                } 
                
                if (y<=0) areaP+=altezza;
                else
                {
                    int temp = altezza-A[x][y-1];
                    if (temp > 0) areaP+=temp;
                }
                
                if (x>=h-1) areaP+=altezza;
                else
                {
                    int temp = altezza-A[x+1][y];
                    if (temp > 0) areaP+=temp;
                }
                
                if (y>=w-1) areaP+=altezza;
                else
                {
                    int temp = altezza-A[x][y+1];
                    if (temp > 0) areaP+=temp;
                }
                
                
                area+=areaP;
                logga ($" --- Area Parziale: {areaP} --- area Totale: {area}");           
            }
            logga("");
        }
        


        return area;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int H = Convert.ToInt32(firstMultipleInput[0]);

        int W = Convert.ToInt32(firstMultipleInput[1]);

        List<List<int>> A = new List<List<int>>();

        for (int i = 0; i < H; i++)
        {
            A.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ATemp => Convert.ToInt32(ATemp)).ToList());
        }

        int result = Result.surfaceArea(A);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
