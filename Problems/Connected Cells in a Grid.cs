 
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
     * Complete the 'connectedCell' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY matrix as parameter.
     */


    //Stampa matrice
    private static void stampaMatrice(List<List<int>> matrice)
    {
        for (int i=0; i<matrice[0].Count; i++) Console.Error.Write("--");
        Console.Error.WriteLine();
        
        for (int x=0; x<matrice.Count; x++)
        {
            for (int y=0; y<matrice[0].Count; y++)
            {
                if (matrice[x][y]>0) Console.Error.Write($"# ");//se e' uno
                                else Console.Error.Write("' "); //se e' zero           
            }
            Console.Error.WriteLine();
        }
        for (int i=0; i<matrice[0].Count; i++) Console.Error.Write("--");
        Console.Error.WriteLine("\n");
    }
    
    private static void stampaArrei(int[,] arrei)
    {
        for (int i=0; i<arrei.GetLength(1); i++) Console.Error.Write("--");
        Console.Error.WriteLine();
        
        for (int x=0; x<arrei.GetLength(0);x++)
        {
            for (int y=0; y<arrei.GetLength(1); y++)
            {
                if (arrei[x,y]>0) Console.Error.Write("# ");//se e' uno
                                else Console.Error.Write("' "); //se e' zero   
            }
            Console.Error.WriteLine();
        }
        for (int i=0; i<arrei.GetLength(1); i++) Console.Error.Write("--");
        Console.Error.WriteLine("\n");
    }

    private static List<Tuple<int,int>> trovaPieni(List<List<int>> matrice, int x, int y)
    {
        logga ($"Chimato metodo trovaPieni matrice.count {matrice.Count} *** x:{x} y:{y} *** Grandezza: {matrice.Count}, {matrice[0].Count}");
        List<Tuple<int,int>> pieni = new List<Tuple<int,int>>();
        
        logga("Alto sinistra");
        if (x>0 && y>0 && matrice[x-1][y-1] == 1) // alto sinistra
        {
            var temp = Tuple.Create(x-1, y-1);
            pieni.Add(temp);
        }
        
        logga("Alto centrale");
        if (x>0 && matrice[x-1][y] == 1) // alto centrale
        {
            var temp = Tuple.Create(x-1, y);
            pieni.Add(temp);
        }
        
        logga("Alto destra");
        if (x>0 && y<matrice[0].Count-1 && matrice[x-1][y+1] == 1) // alto destra
        {
            var temp = Tuple.Create(x-1, y+1);
            pieni.Add(temp);
        }
        
        logga("Sinistra");
        if (y>0 && matrice[x][y-1] == 1) // sinistra
        {
            var temp = Tuple.Create(x, y-1);
            pieni.Add(temp);
        }
        
        logga("Destra");
        if (y<matrice[0].Count-1 && matrice[x][y+1] == 1) // destra
        {
            var temp = Tuple.Create(x, y+1);
            pieni.Add(temp);
        }
        
        logga("Basso sinistra");
        logga($"x:{x} matrice[0].count-1: {matrice[0].Count-1}");
        if (x<matrice.Count-1 && y>0 && matrice[x+1][y-1] == 1) // basso sinistra
        {
            var temp = Tuple.Create(x+1, y-1);
            pieni.Add(temp);
        }
        
        logga("Basso destra");
        if (x<matrice.Count-1 && y<matrice[0].Count-1 && matrice[x+1][y+1] == 1) // basso destra
        {
            var temp = Tuple.Create(x+1, y+1);
            pieni.Add(temp);
        }
        
        logga("Ritorno!");
        return pieni;
        
    }

    // Matrice xXy di 0 e 1: gli 0 son vuoti gli 1 son pieni
    // Un area e' un insieme di caselle uno connesse alle celle adiacenti
    // Trovare l'area piu' grande
    public static int connectedCell(List<List<int>> matrix)
    {
        if (debug)
        {
            Console.Error.WriteLine("-----------------------------");
            foreach(List<int> lista in matrix)
            {
                foreach(int i in lista)
                {
                    Console.Error.Write($"{i} ");
                }
                Console.Error.WriteLine();
            }
            Console.Error.WriteLine("-----------------------------\n");
        }
        
        
        int maxArea=0;
        
        if (debug) stampaMatrice(matrix);
        
        List<int[,]> matrici = new List<int[,]>();
        
        for (int x=0; x<matrix.Count; x++)
        {
            for (int y=0; y<matrix[0].Count; y++)
            {
                if (matrix[x][y] == 1) // se e' pieno
                {
                    int[,] temp = new int[matrix.Count, matrix[0].Count];
                    
                    temp[x,y]=1;
                    
                    List<Tuple<int,int>> pieni = trovaPieni(matrix,x,y);
                    List<Tuple<int,int>> archivio = new List<Tuple<int, int>>();

                    while (pieni.Count>0)
                    {
                        // logga($"0 ---- {pieni.Count} x:{pieni[0].Item1} y:{pieni[0].Item2}");
                        temp[pieni[0].Item1, pieni[0].Item2] = 1;
                        // logga($"Rimuovo punto pieni.Count:{pieni.Count} {pieni[0]}");
                        pieni.RemoveAt(0);
                        if (pieni.Count>0)
                        {
                            // logga($"Richiamo metodo trova pieni x:{pieni[0].Item1} y:{pieni[0].Item2}");
                            if (archivio.Contains(pieni[0])) continue;
                            logga(pieni[0]);
                            List<Tuple<int,int>> pieniTemp = trovaPieni(matrix, pieni[0].Item1, pieni[0].Item2);
                            archivio.Add(pieni[0]);
                            logga($"Unisco le liste pieniTemp.count: {pieniTemp.Count} Pieni.count: {pieni.Count}");
                            if (pieniTemp.Count >0) pieni.AddRange(pieniTemp);
                        }
                    }
                    if (temp.GetLength(0) >0) matrici.Add(temp);
                }
                
            }
        }

        logga ($"Ciclo cerca punti finito, cerco l'area piu grande. Matrici:{matrici.Count}");
        
        int contatore = 0;
        foreach (int[,] matr in matrici)
        {
            if (debug) contatore++;
            int somma = 0;
            foreach (int i in matr)
            {
                somma+=i;
            }
            if (somma>maxArea) maxArea = somma;
            logga($"Ciclo: {contatore} --- Somma: {somma} --- MaxArea: {maxArea}");
            if (debug) stampaArrei(matr);
        }

        //trovare l'area piu grande
        return maxArea;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        int m = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> matrix = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
        }

        int result = Result.connectedCell(matrix);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
