 
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
     * Complete the 'climbingLeaderboard' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts following parameters:
     *  1. INTEGER_ARRAY ranked
     *  2. INTEGER_ARRAY player
     */

    public static List<int> climbingLeaderboard(List<int> ranked, List<int> player)
    {
        //------------------------------------
        bool debug = false;
        //------------------------------------
        
        List<int> ritorno = new List<int>();

        List<int> posizioni = new List<int>();
        

        if (debug)
        {
            Console.WriteLine("---------------------------------------------------");
            Console.WriteLine($"Player length: {player.Count} - Ranked lenght: {ranked.Count}");
            Console.WriteLine("Player: "+string.Join(" ", player) + "\n");
            Console.WriteLine("Ranked: "+string.Join(" ", ranked));
        }
        
        //calcola le posizioni in classifica
        int vecchio=ranked[0];
        int pos = 1;
        
        for (int i=0; i<ranked.Count; i++)
        {
            if (ranked[i] != vecchio) pos++;
            posizioni.Add(pos);
            vecchio = ranked[i];
        }
                
        if (debug) Console.WriteLine("Classifica: "+string.Join(" ", posizioni)+"\n");
        
        if (debug) Console.WriteLine($"Posizioni.lenght: {posizioni.Count}");
        
        //trova la posizione in classifica di player
        
        int conta=0;
        int old=0;
        
        
        for (int i=ranked.Count-1; i>=0; i--)        
        {
            // if (debug) Console.WriteLine($"\ni: {i}");
            
            // if (debug) Console.WriteLine($"player[conta] < ranked[i]");
            if (debug && i <10) Console.Write($"i: {i} - {player[conta]} < {ranked[i]} -- Conta: {conta}  ");
            
                                    
            if (player[conta] < ranked[i])
            {
                ritorno.Add(posizioni[i]+1);
                conta++;
                if (conta>=player.Count) break;
            }
            
            if (debug && i <10) Console.Write($" - ranked[i]: {ranked[i]} i: {i} - ");
            if (debug && i <10) Console.Write($" - player[conta]: {player[conta]} conta: {conta} ---");
            
            
            if (player[conta] == ranked[i])
            {
                ritorno.Add(posizioni[i]);
                conta++;
                if (conta>=player.Count) break;
            }
            
            if (debug && i <10) Console.Write($"2");
            
            if (conta>0 && player[conta-1]==old)
            {
                i++;
            }
            
            if (debug && i <10) Console.Write($"3");
            
            old = player[conta];
            
            if (debug && i <10) Console.WriteLine();
              
        }

        if (debug) Console.WriteLine($"Sono arrivato fin qui!");

        if (conta < player.Count)
        {
            int diff=player.Count - conta;
            for (int i=0; i<diff; i++)
            {
                ritorno.Add(1);
            }
        }
        
        return ritorno;
    }
    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int rankedCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> ranked = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(rankedTemp => Convert.ToInt32(rankedTemp)).ToList();

        int playerCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> player = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(playerTemp => Convert.ToInt32(playerTemp)).ToList();

        List<int> result = Result.climbingLeaderboard(ranked, player);

        textWriter.WriteLine(String.Join("\n", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
