 
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
     * Complete the 'gridSearch' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING_ARRAY G
     *  2. STRING_ARRAY P
     */

    public static string gridSearch(List<string> G, List<string> P)
    {
        //---------------------
        bool debug = false;
        //---------------------
    
        if (debug) Console.WriteLine("-----------------------------------------------------------");
    
        int righe=G.Count;
        int colonne=G[0].Length;
        
        int righeP=P.Count;
        int colonneP= P[0].Length;
        
        if (debug) Console.WriteLine($"Righe: {righe} Colonne: {colonne} -- RigheP: {righeP} ColonneP: {colonneP}");
        
        for (int x=0; x<righe-righeP+1;x++) // righe
        {
            for (int y=0; y<colonne-colonneP+1; y++) // colonne
            {
                // if (debug) Console.WriteLine($"X: {x} Y:{y} --- {G[x][y]} == {P[0][0]}");
                if (debug) Console.Write ($"{G[x][y]} ");
                if (G[x][y] == P[0][0])
                {
                    bool trovato = true;
                    for (int x1=0; x1<righeP; x1++)    
                    {
                        for (int y1=0; y1<colonneP; y1++)
                        {
                            // if (debug) Console.WriteLine($"X: {x} Y:{y} - x1: {x1} y1: {y1} --- {G[x+x1][y+y1]} != {P[x1][y1]} {trovato}");
                            // if (debug) Console.WriteLine(G[x+x1][y+y1]);
                            // if (debug) Console.WriteLine(P[x1][y1]);
                            if (G[x+x1][y+y1] != P[x1][y1])
                            {
                                trovato=false;
                                break;
                            }
                            if (!trovato) break;
                            
                        }
                        if (!trovato) break;
                        if (debug) Console.WriteLine();
                    }
                    if (trovato) return "YES";
                }
            }
        }
        return "NO";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int R = Convert.ToInt32(firstMultipleInput[0]);

            int C = Convert.ToInt32(firstMultipleInput[1]);

            List<string> G = new List<string>();

            for (int i = 0; i < R; i++)
            {
                string GItem = Console.ReadLine();
                G.Add(GItem);
            }

            string[] secondMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int r = Convert.ToInt32(secondMultipleInput[0]);

            int c = Convert.ToInt32(secondMultipleInput[1]);

            List<string> P = new List<string>();

            for (int i = 0; i < r; i++)
            {
                string PItem = Console.ReadLine();
                P.Add(PItem);
            }

            string result = Result.gridSearch(G, P);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
