 
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
     * Complete the 'acmTeam' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts STRING_ARRAY topic as parameter.
     */
     
     // Colonna = materia
     // Riga = partecipante
     
     // ritorno1: Massimo numero di materie conosciute
     // ritorno2: Quante coppie di team le conoscono

    private static readonly bool debug = false;
    public static List<int> acmTeam(List<string> topic)
    {
        List<int> ritorno = new List<int>();
        int nMat = 0;
        int nTeams = 0;
        
        
        // - n. materie
        List<int> numeroMaterie = new List<int>();
        
        int righe = topic.Count();
        int colonne = topic[0].Length;
        if (debug) Console.WriteLine($"Righe: {righe} - Colonne {colonne}");
        
        for (int i=0; i< righe; i++)
        {
            for (int j=i+1; j<righe; j++)
            {
                int materie = 0;
                for (int k=0; k<colonne; k++)
                {
                    if (topic[i][k] == '1' || topic[j][k] == '1') materie++;
                }
                numeroMaterie.Add(materie);
                if (debug) Console.WriteLine($"  i: {i} j: {j} materie: {materie}");
            }
        }
        
        
        foreach (int i in numeroMaterie)
        {
            if (i>nMat) nMat = i;
        }
        
        foreach (int i in numeroMaterie)
        {
            if (i == nMat) nTeams++;
        }
        
        
        ritorno.Add(nMat);
        ritorno.Add(nTeams);
        return ritorno;
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

        List<string> topic = new List<string>();

        for (int i = 0; i < n; i++)
        {
            string topicItem = Console.ReadLine();
            topic.Add(topicItem);
        }

        List<int> result = Result.acmTeam(topic);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
