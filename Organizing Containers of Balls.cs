 
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
     * Complete the 'organizingContainers' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts 2D_INTEGER_ARRAY container as parameter.
     */

    // Le palline di un numero devo stare tutto nello stesso contenitore
    // Puoi eseguire solo opereazioni di swap fra un contenitore e l'altro
    
    // container: righe = contenitori - colonne = palline (numero)

    // ritorno = Possibile - Impossible

    private static readonly bool debug = true;

    public static string organizingContainers(List<List<int>> container)
    {
        if (debug)
        {
            Console.WriteLine($"\n---------------------------------------------");
            foreach (List<int> l in container)
            {
                Console.WriteLine(string.Join(" ", l));
            }
            
        }
        int[] palline = new int[container[0].Count];
        int[] capacita = new int[container.Count];
        
        for (int i=0; i<container.Count; i++)
        {
            int tot = 0;
            for (int j=0; j<container[0].Count; j++)
            {
                tot+= container[i][j];
                palline[j]+=container[i][j];
            }
            
            capacita[i] = tot;
            
        }

        Array.Sort(palline);
        Array.Sort(capacita);
        
        if (palline.SequenceEqual(capacita)) return "Possible";
        else return "Impossible";

        return "Qualcosa non ha funzionato :-(";
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            List<List<int>> container = new List<List<int>>();

            for (int i = 0; i < n; i++)
            {
                container.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(containerTemp => Convert.ToInt32(containerTemp)).ToList());
            }

            string result = Result.organizingContainers(container);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
