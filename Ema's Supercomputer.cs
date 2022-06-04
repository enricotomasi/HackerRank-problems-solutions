 
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
using System.Windows;


class Result
{
        
    ////////////////////////////////////////////////////////////////
    private static bool debug = false;
    ////////////////////////////////////////////////////////////////
    
    private static void stampaCroce(int[,] arr)
    {
        int conta = 0;
        
        Console.WriteLine(new string('-',arr.GetLength(1)));
        for (int x = 0; x<arr.GetLength(0); x++)
        {
            for (int y = 0; y<arr.GetLength(1); y++)
            {
                if (arr[x,y] == 0) Console.Write(" ");
                else
                {
                    Console.Write("*");
                    conta++;
                } 
            }
            Console.WriteLine();
        }
        Console.WriteLine(new string('-',arr.GetLength(1)) + "Pezzi: " + conta);
    }
    
    public static int twoPluses(List<string> grid)
    {
        int max = 0;
        
        int righe=grid.Count();
        int colonne= grid[0].Length;
        
        List<int[,]> croci = new List<int[,]>();
        
        if (debug) Console.WriteLine($"Righe: {righe} Colonne: {colonne}");
        
        for (int x=0; x<righe; x++)
        {
            for (int y=0; y<colonne; y++)
            {   
                // if (debug) Console.WriteLine($"{x},{y}");
                if (grid[x][y] == 'B') continue;
                else
                {
                    int[,] croce = new int[righe,colonne];
                    
                    croce[x,y] = 1;
                    croci.Add(croce);
                                       
                    int aggiungi = 1;
                    
                    while ( x+aggiungi < righe &&
                            x-aggiungi >= 0 &&
                            y+aggiungi < colonne &&
                            y-aggiungi >= 0 &&
                            grid[x+aggiungi][y] == 'G' &&
                            grid[x-aggiungi][y] == 'G' &&
                            grid[x][y+aggiungi] == 'G' &&
                            grid[x][y-aggiungi] == 'G')
                    {
                                               
                        croce[x+aggiungi,y] = 1; 
                        croce[x-aggiungi,y] = 1; 
                        croce[x,y+aggiungi] = 1; 
                        croce[x,y-aggiungi] = 1; 
                       
                        int[,] clone = (int[,]) croce.Clone();
                        
                        croci.Add(clone);

                        aggiungi++;
                    }
                }
                
            }
        }
        
        if (debug) Console.WriteLine($"Croci: {croci.Count}\n");
        
        for (int i=0; i<croci.Count; i++)
        {
            for (int j=0; j<croci.Count; j++)
            {
                // if (debug) Console.WriteLine($"i: {i} - j: {j}");
                
                if (i==j) continue;
                
                bool debug2= false;
                if ((i==27 && j==91) || (i==91 && j==27)) debug2=true;
                
                int[,] croce1 = croci[i];
                int[,] croce2 = croci[j];
            
                int contaCr1 = 0;
                int contaCr2 = 0;
                
                bool interseca=false;
                for (int x = 0; x<righe; x++)
                {
                    for (int y = 0; y<colonne; y++)
                    {
                        if (croce1[x,y] == 1 && croce2[x,y] == 1) interseca = true;
                        if (interseca)
                        {
                            break; 
                        }
                         
                        
                        if (croce1[x,y] == 1) contaCr1++;
                        if (croce2[x,y] == 1) contaCr2++;
                        
                        int area = contaCr1 * contaCr2;
                        
                        if (area > max) max = area;
                    }
                    if (interseca) break;
                }
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

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<string> grid = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        int result = Result.twoPluses(grid);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
