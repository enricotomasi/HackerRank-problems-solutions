 
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
     * Complete the 'gridChallenge' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING_ARRAY grid as parameter.
     */

    private static string ordinaAlfabetico(string stringa)
    {
        return String.Concat(stringa.OrderBy(carattere => carattere));
    }

    public static string gridChallenge(List<string> grid)
    {
        int righe=grid.Count();
        int colonne=grid[0].Count();
        
        for (int riga=0; riga<righe; riga++)
        {
            grid[riga] = ordinaAlfabetico(grid[riga]);
        }
        
        bool disordiato = false;
        for (int colonna=0; colonna<colonne; colonna++)
        {
            char ultimoCarattere=grid[0][colonna];
            for (int riga=1; riga<righe; riga++)
            {
                char carattere = grid[riga][colonna];
                if (carattere<ultimoCarattere)
                {
                    disordiato=true;
                    break;
                }
                if (disordiato) break;
            }
            if (disordiato) break;
        }
        
        if (disordiato) return "NO";
        else return "YES";
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
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<string> grid = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string gridItem = Console.ReadLine();
                grid.Add(gridItem);
            }

            string result = Result.gridChallenge(grid);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
