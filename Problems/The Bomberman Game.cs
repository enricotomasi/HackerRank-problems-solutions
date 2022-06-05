 
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
     * Complete the 'bomberMan' function below.
     *
     * The function is expected to return a STRING_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER n - Numero di secondi
     *  2. STRING_ARRAY grid - Griglia
     *  
     *  Quando una bomba esplode viene distrutta e distrugge le caselle vicine (le eventuali bombe NON esplodono)
     *  Le bombe esplodono ogni 3 secondi
     * 
     *  - Prima di tutto le bombe sono messo in uno stato iniziale arbitrario
     *  - Dopo un secondo si riposa
     *  --- Dopo un secondo piante le bombe in tutte le caselle vuote (qui non esplode niente)
     *  --- Dopo un secondo esplodono le bombe piantate 3 secondi prima
     *  - Ripetere gli ultimi due stati infinito
     *
     *  Restituire la griglia nello stato finale
     */

    private static readonly bool debug = false; //debug normale
    private static readonly bool debug2 = false; //debug esplosione
    private static readonly bool debug3 = false; //stato griglie prima dell'esplosione
    private static readonly bool debug4 = true; // debug scelta pattern da ritornare
    
    public static List<string> bomberMan(int n, List<string> grid)
    {
        if (n==1) return grid;
        
        List<string> ritorno = new List<string>();
        
        List<string> grigliaOra = new List<string>(); //attuale
        List<string> griglia1 = new List<string>(); // 1 sec fa
        List<string> griglia2 = new List<string>(); // 2 sec fa
        List<string> griglia3 = new List<string>(); // 3 sec fa
        
        List<string> r1 = new List<string>(); 
        List<string> r2 = new List<string>(); 
        List<string> r3 = new List<string>(); 
        List<string> r4 = new List<string>(); 
        
        
        int righe = grid.Count;
        int colonne = grid[0].Length;
        
        char vuoto='.';
        char bomba='O';
        
        grigliaOra = grid.ToList();
        griglia1 = grid.ToList();
        griglia2 = grid.ToList();
        griglia3 = grid.ToList();
        
        if (debug)
        {
            Console.WriteLine($"Secondi da simulare: {n}: righe: {righe} - Colonne: {colonne}");
            foreach (string s in grigliaOra)
            {
                Console.WriteLine(s);
            }
        }
        
        
        int secondo = 3;
        bool pianta = true;

        for (int i=1; i<=4; i++)
        {
            if (debug) Console.WriteLine($"\n --- secondo {secondo} ---  --- tot: {i} --- {pianta ? "Pianta" : "Esplode"}");
            griglia3 = griglia2.ToList();
            griglia2 = griglia1.ToList();
            griglia1 = grigliaOra.ToList();
            
    
            if (pianta) //pianta
            {
                grigliaOra.Clear();
                
                for (int j=0; j<righe; j++)
                {
                    grigliaOra.Add(new string(bomba,colonne));
                }
    
            }
            else //esplode
            {
                char[,] arrayOra = new char[righe,colonne];
                
                for (int x=0; x<righe; x++)
                {
                    for (int y=0; y<colonne; y++)
                    {
                        arrayOra[x,y] = bomba;
                    }
                }
                
                // if (debug3)
                // {
                //     Console.WriteLine("--------------------------------------");
                //     Console.WriteLine("GrigliaOra");
                //     foreach (string s in grigliaOra)
                //     {
                //         Console.WriteLine(s);
                //     }
                //     Console.WriteLine("--------------------------------------");
                //     Console.WriteLine("Griglia1");
                //     foreach (string s in griglia1)
                //     {
                //         Console.WriteLine(s);
                //     }
                //     Console.WriteLine("--------------------------------------");
                //     Console.WriteLine("Griglia2");
                //     foreach (string s in griglia2)
                //     {
                //         Console.WriteLine(s);
                //     }
                //     Console.WriteLine("--------------------------------------");
                //     Console.WriteLine("Griglia3");
                //     foreach (string s in griglia3)
                //     {
                //         Console.WriteLine(s);
                //     }
                //     Console.WriteLine("--------------------------------------");
                // }

                for (int x=0; x<righe; x++)
                {
                    for (int y=0; y<colonne; y++)
                    {
                        // if (debug2) Console.WriteLine($"\nEsamino casella: {x},{y} --- {griglia1.Count} {griglia1[0].Length} --- ");
                        
                        if (griglia2[x][y] == vuoto)
                        {
                           // do nothing 
                        }
                        else
                        {
                            arrayOra[x,y]=vuoto;
                            // if(debug2) Console.WriteLine("Punto centrale");
                            
                            if(x!=0) arrayOra[x-1,y]=vuoto;
                            // if(debug2) Console.WriteLine("x-1");
                            
                            if(x!=righe-1) arrayOra[x+1,y]=vuoto;
                            // if(debug2) Console.WriteLine("x+1");
                            
                            if(y!=0) arrayOra[x,y-1]=vuoto;
                            // if(debug2) Console.WriteLine("y-1");
                            
                            if(y!=colonne-1) arrayOra[x,y+1]=vuoto;
                            // if(debug2) Console.WriteLine("y+1");
                        }
                    }
                }

                grigliaOra.Clear();
                for (int x=0; x<righe; x++)
                {
                    string riga = "";
                    for (int y=0; y<colonne; y++)
                    {
                        riga += arrayOra[x,y];
                    }
                    grigliaOra.Add(riga);
                }
                
            }   
            
            pianta = !pianta;
            
            if (i==1) r1=grigliaOra.ToList();
            if (i==2) r2=grigliaOra.ToList();
            if (i==3) r3=grigliaOra.ToList();
            if (i==4) r4=grigliaOra.ToList();
                                    
            
            if (secondo==3) secondo=1; else secondo++; //fa scorrere il tempo
          
                 
        }

        //r1 pieno
        //r2 p1
        //r3 pieno
        //r4 p2

        if (n%2 == 0) return r1;
        
        int conta = 0;
        for (int i=0; i<n; i++)
        {
            if (conta == 3) conta = 0; else conta++;
        }
        
        if (debug4) 
        {
            
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("r1");
            foreach (string s in r1)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("r2");
            foreach (string s in r2)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("r3");
            foreach (string s in r3)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("r4");
            foreach (string s in r4)
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("--------------------------------------");
                                    
            Console.WriteLine($"conta: {conta}");
            
            
        }
        
        if (conta==1) return r4;
        if (conta==3) return r2;

        return r1;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int r = Convert.ToInt32(firstMultipleInput[0]);

        int c = Convert.ToInt32(firstMultipleInput[1]);

        int n = Convert.ToInt32(firstMultipleInput[2]);

        List<string> grid = new List<string>();

        for (int i = 0; i < r; i++)
        {
            string gridItem = Console.ReadLine();
            grid.Add(gridItem);
        }

        List<string> result = Result.bomberMan(n, grid);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
