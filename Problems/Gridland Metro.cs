 
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
using System.Numerics;
using System;

class Result
{
    public static BigInteger gridlandMetro(int righe, int colonne, int binari, List<List<int>> ferrovie)
    {
        BigInteger r = new BigInteger(righe);
        BigInteger c = new BigInteger(colonne);
        BigInteger stazioni = new BigInteger();
        stazioni = r*c;
        // Console.WriteLine($"righe: {righe} colonne: {colonne} - Stazioni: {stazioni}");
        var ferrovieRaggruppatePerRiga = ferrovie.GroupBy(x => x[0]).ToList();
        
        foreach (var ferroviaPerRiga in ferrovieRaggruppatePerRiga)
        {
            long righePiene = 0;
            
            if (ferroviaPerRiga.Count() == 1)
            {
                righePiene = calcolaRighePieneMonoRiga(ferroviaPerRiga.ToList()[0]);
            }
            else
            {
                righePiene = calcolaRighePieneMultiRiga(ferroviaPerRiga.ToList());
            }
            stazioni -= righePiene;
            // Console.WriteLine($"righePiene:{righePiene} *** Stazioni: {stazioni}");
        }
        return stazioni;
    }
    
    private static long calcolaRighePieneMonoRiga(List<int> ferroviaRiga)
    {
        int inizio = ferroviaRiga[1];
        int fine = ferroviaRiga[2];
        int righePieneTemp = fine-inizio+1;
        return righePieneTemp;
    }
    
    private static long calcolaRighePieneMultiRiga(List<List<int>> ferrovieRiga)
    {
        var segmenti = new List<List<int>>();
        int[] segmentiUsati = new int[ferrovieRiga.Count];
        
        for (int i=0; i<ferrovieRiga.Count; i++)
        {
            if (segmentiUsati[i] == 1) continue;
            segmentiUsati[i] = 1;
            
            int inizio = ferrovieRiga[i][1];
            int fine = ferrovieRiga[i][2];
            
            for (int j=0; j<ferrovieRiga.Count; j++)
            {
                if (segmentiUsati[j] == 1) continue;
                var segmentoCicloEsterno = new Tuple<int,int>(inizio,fine);
                int inizioTemp = ferrovieRiga[j][1];
                int fineTemp = ferrovieRiga[j][2];
                var segmentoCicloInterno = new Tuple<int,int>(inizioTemp, fineTemp);
                
                if (calcolaSeInterseca(segmentoCicloEsterno, segmentoCicloInterno))
                {
                    var nuovoInizioFine = calcolaInizioFine(segmentoCicloEsterno, segmentoCicloInterno);
                    inizio = nuovoInizioFine.Item1;
                    fine = nuovoInizioFine.Item2;
                    segmentiUsati[j] = 1;
                }
            }
            segmenti.Add(new List<int>(){inizio,fine});            
        }

        long casellePiene = 0;        
        foreach (List<int> segmento in segmenti)
        {
            long casellePieneTemp = calcolaRighePieneMonoRiga(new List<int>(){0, segmento[0], segmento[1]});
            casellePiene += casellePieneTemp;
        }
        
        return casellePiene;
    }
    
    private static bool calcolaSeInterseca(Tuple<int,int> segmentoOriginale, Tuple<int,int> segmentoTemp)
    {
        int iO = segmentoOriginale.Item1;
        int fO = segmentoOriginale.Item2;
        int i = segmentoTemp.Item1;
        int f = segmentoTemp.Item2;
        
        bool response = i<=fO && f>=iO;
        
        return response;
    }
    
    private static Tuple<int,int> calcolaInizioFine(Tuple<int,int> segmentoOriginale, Tuple<int,int> segmentoTemp)
    {
        int iO = segmentoOriginale.Item1;
        int fO = segmentoOriginale.Item2;
        int i = segmentoTemp.Item1;
        int f = segmentoTemp.Item2;
        
        int nuovoInizio=Math.Min(i, iO);
        int nuovaFine=Math.Max(f, fO);
   
        return new Tuple<int,int>(nuovoInizio,nuovaFine);
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
        int k = Convert.ToInt32(firstMultipleInput[2]);

        List<List<int>> track = new List<List<int>>();

        for (int i = 0; i < k; i++)
        {
            track.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(trackTemp => Convert.ToInt32(trackTemp)).ToList());
        }

        BigInteger result = new BigInteger();
        result = Result.gridlandMetro(n, m, k, track);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
