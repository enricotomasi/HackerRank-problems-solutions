 
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
     * Complete the 'cavityMap' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    public static List<string> cavityMap(List<string> grid)
    {
        bool debug=false;
        List<string> ritorno = new List<string>();
        
        int dimX=grid.Count;
        int dimY=grid[0].Length;
        
        if (debug) Console.WriteLine($"X:{dimX} - Y:{dimY}");
        
        
        
        for (int x=0; x< dimX; x++)
        {
            string riga ="";
            if (debug) Console.WriteLine();
            for (int y=0; y<dimY; y++)
            {
                
                int cifra = Convert.ToInt32(grid[x].Substring(y,1));
                try
                {
                    int p1 = Convert.ToInt32(grid[x].Substring(y+1,1));
                    int p2 = Convert.ToInt32(grid[x].Substring(y-1,1));
                    int p3 = Convert.ToInt32(grid[x+1].Substring(y,1));
                    int p4 = Convert.ToInt32(grid[x-1].Substring(y,1));

                    if (debug) Console.Write($"Cifra: {cifra} P: {p1} {p2} {p3} {p4} ");
                    
                    if (cifra > p1 &&
                    cifra > p2 &&
                    cifra > p3 &&
                    cifra > p4)          
                    {
                        if (debug) Console.Write("--- tutti inferiori\n");
                        riga+="X";
                    }
                    else
                    {
                        if (debug) Console.Write("--- qualcuno superiore\n");
                        riga+=grid[x][y];
                    }   
                }
                catch
                {
                    if (debug) Console.WriteLine($"Cifra: {cifra} BORDO ***");
                    riga+=grid[x][y];
                }
                
            }
            ritorno.Add(riga);
 
        }

        return ritorno;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.cavityMap(grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
