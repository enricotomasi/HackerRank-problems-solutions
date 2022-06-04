 
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
     * Complete the 'steadyGene' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING gene as parameter.
     */
     
   

    // public static int steadyGene(string gene)
    // {
    //     logga (gene);
        
    //     int minSub = int.MaxValue;
        
    //     int lunghezza = gene.Length;
    //     int freqAttesa = lunghezza/4;
        
    //     //Conta le occorrenze:
    //     int freqA = Regex.Matches(gene, "A").Count;
    //     int freqC = Regex.Matches(gene, "C").Count;
    //     int freqT = Regex.Matches(gene, "T").Count;
    //     int freqG = Regex.Matches(gene, "G").Count;
        
    //     //Trova la differenza con il numero che lo rende stabile
    //     int dcA = Math.Abs(lunghezza/4-freqA);
    //     int dcC = Math.Abs(lunghezza/4-freqC);
    //     int dcT = Math.Abs(lunghezza/4-freqT);
    //     int dcG = Math.Abs(lunghezza/4-freqG);
        
    //     int dcTot = (dcA + dcC + dcT + dcG)/2;
        
    //     logga($"Lunghezza: {lunghezza} --- A:{freqA} C:{freqC} T:{freqT} G:{freqG}");        
    //     logga($"dcA: {dcA} dcC: {dcC} dcA: {dcT} dcA: {dcG} --- Totale: {dcTot}\n--------------------------------------------------------------\n");
        
    //     for (int i=0; i<lunghezza-dcTot; i++)
    //     {
    //         int sub = 0;
    //         for (int j=i; j<lunghezza;j++)
    //         {
    //             bool ciRiesco = false;
    //             int subStringaLunghezza = 0;
                
    //             for (int k=1; k<lunghezza-j+1; k++)
    //             {
    //                 logga($"{i},{j},{k}",false);
    //                 string substringa = gene.Substring(j,k);
    //                 subStringaLunghezza = substringa.Length;

    //                 logga($"{substringa} ({j},{k})");
                    
    //                 logga($"i:{i} j:{j} --- lunghezza: {lunghezza} - j {j} - 1 = {lunghezza-j-1} --- {substringa}");
                    
    //                 // logga($"--- {substringa}");
                    
    //                 int SubFreqA = Regex.Matches(substringa, "A").Count;
    //                 int SubFreqC = Regex.Matches(substringa, "C").Count;
    //                 int SubFreqT = Regex.Matches(substringa, "T").Count;
    //                 int SubFreqG = Regex.Matches(substringa, "G").Count;
                    
    //                 logga($"SubFreqA:{SubFreqA} SubFreqC:{SubFreqC} SubFreqT:{SubFreqT} SubFreqG:{SubFreqG}   ---   Frequenza sottostringa");
                    
    //                 int subA = freqA-SubFreqA;
    //                 int subC = freqC-SubFreqC;
    //                 int subT = freqT-SubFreqT;
    //                 int subG = freqG-SubFreqG;
                    
    //                 logga($"subA:{subA} subC:{subC} subT:{subT} subG:{subG}   --- Frequenza valori esclusi dalla sottostringa");
                    
    //                 int quantiA = freqAttesa-subA;
    //                 int quantiC = freqAttesa-subC;
    //                 int quantiT = freqAttesa-subT;
    //                 int quantiG = freqAttesa-subG;

    //                 logga($"quantiA:{quantiA} quantiC:{quantiC} quantiT:{quantiT} quantiG:{quantiG} --- freqAttesa = {freqAttesa}");

    //                 if (quantiA <0 || quantiC <0 || quantiT <0 || quantiG <0)
    //                 {
    //                     logga("C'e' un valore sottozero");                        
    //                     logga("--------------------------------------------------------------\n");
    //                     continue;
    //                 }
                    
    //                 if ((quantiA+quantiC+quantiG+quantiT) <= subStringaLunghezza) //bingo
    //                 {
    //                     if (minSub>subStringaLunghezza) minSub = subStringaLunghezza;
    //                     logga($"Si!!!! Sottostringa lungh:{subStringaLunghezza}");
    //                 }
    //                 else // no good
    //                 {
    //                     logga($"No :(");
    //                 }
    //                 logga("--------------------------------------------------------------\n");
    //             }
                
    //             if (ciRiesco && minSub > subStringaLunghezza) minSub = subStringaLunghezza;
                                
    //         }
    //     }        
               
    //     return minSub;
    // }
    
    
    // Funziona pure questo ma e' sempre troppo lento
    
    // public static int steadyGene(string gene)
    // {
    //     // logga (gene);
        
    //     int minSub = int.MaxValue;
        
    //     int lunghezza = gene.Length;
    //     int freqAttesa = lunghezza/4;
        
    //     //Conta le occorrenze:
    //     int freqA = Regex.Matches(gene, "A").Count;
    //     int freqC = Regex.Matches(gene, "C").Count;
    //     int freqT = Regex.Matches(gene, "T").Count;
    //     int freqG = Regex.Matches(gene, "G").Count;
        
    //     if (freqA == freqAttesa && freqC == freqAttesa && freqG == freqAttesa && freqT == freqAttesa) return 0;
        
    //     int minCamb = (Convert.ToInt32(Math.Abs((freqAttesa - freqA))) + 
    //                    Convert.ToInt32(Math.Abs((freqAttesa - freqC))) + 
    //                    Convert.ToInt32(Math.Abs((freqAttesa - freqT))) + 
    //                    Convert.ToInt32(Math.Abs((freqAttesa - freqG)))) / 2;
        
    //     // logga($"Lunghezza: {lunghezza} --- A: {freqA} - C: {freqC} - T: {freqT} - G: {freqG} --- Frequenza attesa: {freqAttesa} minCamb: {minCamb}\n");   
        
    //     // {
    //     //     logga("Gia' stabile - esco!");
    //     //     return 0;
    //     // }
        
    //     //     0 1 2 3 4 5 6 7
    //     //     G A A A T A A A   
    //     //       ^         ^                      
    //     //  Lunghezza: 8 --- A:6 C:0 T:1 G:1 --- Frequenza attesa: 2
    //     //  Eccedenza:       A:4 C:0 T:0 G:0  --- Devono essere all'interno
    //     //  Mancanti:        A:0 C:2 T:1 G:1 --- Tot: 4
    //     //
       
    //     // int eccA = freqA - freqAttesa >=0 ? freqA - freqAttesa : 0;
    //     // int eccC = freqC - freqAttesa >=0 ? freqC - freqAttesa : 0;
    //     // int eccT = freqT - freqAttesa >=0 ? freqT - freqAttesa : 0;
    //     // int eccG = freqG - freqAttesa >=0 ? freqG - freqAttesa : 0;
        
    //     // // logga($"ecc   --- eccA:   {eccA} - eccC:   {eccC} - eccT:   {eccT} - eccG:   {eccG}");   
     
    //     // int mancaA = (freqA - freqAttesa <0 ? Convert.ToInt32(Math.Abs(freqA-freqAttesa)) : 0); 
    //     // int mancaC = (freqC - freqAttesa <0 ? Convert.ToInt32(Math.Abs(freqC-freqAttesa)) : 0); 
    //     // int mancaT = (freqT - freqAttesa <0 ? Convert.ToInt32(Math.Abs(freqT-freqAttesa)) : 0); 
    //     // int mancaG = (freqG - freqAttesa <0 ? Convert.ToInt32(Math.Abs(freqG-freqAttesa)) : 0); 
                
    //     // logga($"manca --- mancaA: {mancaA} - mancaC: {mancaC} - mancaT: {mancaT} - mancaG: {mancaG}");

    //     //elenchiamo tutte le sottostringhe:
    //     for (int inizio=0; inizio<gene.Length; inizio++)
    //     {
    //         for (int fine = gene.Length-1; fine>=inizio; fine--)
    //         {
    //             string esclusi = "";
    //             if (inizio>0) esclusi+=gene.Substring(0,inizio);
    //             if (fine < gene.Length) esclusi += gene.Substring(fine,gene.Length-fine);
    //             // int esclusiLung = esclusi.Length;
    //             int vuotiLung = lunghezza-esclusi.Length;
                
    //             if (vuotiLung < minCamb)
    //             {
    //                 // logga("Troppo corta la stringa non puo' essere valida, continuo");
    //                 continue;
    //             }
                
    //             // logga($"Inizio: {inizio} - Fine: {fine} - L. Inclusi: {vuotiLung} --- Esclusi: {esclusi} ");
                
    //             int sottoFreqA = Regex.Matches(esclusi, "A").Count;
    //             int sottoFreqC = Regex.Matches(esclusi, "C").Count;
    //             int sottoFreqT = Regex.Matches(esclusi, "T").Count;
    //             int sottoFreqG = Regex.Matches(esclusi, "G").Count;
                
    //             // logga($"sotttoFreqA: {sottoFreqA} - sotttoFreqC: {sottoFreqC} - sotttoFreqT: {sottoFreqT} - sotttoFreqG: {sottoFreqG}"); 
                
    //             if (sottoFreqA>freqAttesa || sottoFreqC>freqAttesa || sottoFreqT>freqAttesa || sottoFreqG >freqAttesa) continue;
    //             // {
    //                 // logga("Una delle frequenze maggiori di frequenza attesa, continuo...");
    //             // }
                
    //             //cerchiamo di capire se riusciamo a sistemare la stringa
    //             // for (int i=0; i<vuotiLung; i++)
    //             // {
    //             //     if (sottoFreqA < freqAttesa) sottoFreqA++;
    //             //     else if (sottoFreqC < freqAttesa) sottoFreqC++;
    //             //     else if (sottoFreqT < freqAttesa) sottoFreqT++;
    //             //     else if (sottoFreqG < freqAttesa) sottoFreqG++;
    //             // }
                
    //             // if (sottoFreqA == freqAttesa && sottoFreqC == freqAttesa && sottoFreqT == freqAttesa && sottoFreqG == freqAttesa && vuotiLung < minSub)
    //             // {
    //             //     minSub = vuotiLung;
    //             // }
                
    //             if (vuotiLung < minSub)
    //             {
    //                 // logga ("OK!");
    //                 minSub = vuotiLung;
    //             }
                
    //         }
            
    //     }
        
        
    //     return minSub;
    // }
    
    
    
    // Non funziona proprio.... :(
        
    // public static int steadyGene(string gene)
    // {
    //     int minSub = int.MaxValue;
        
    //     int inizio = 0;
    //     int fine = gene.Length-1;
        
    //     int drA = gene.Length/4;
    //     int drC = drA;
    //     int drT = drA;
    //     int drG = drA;
        
    //     while (true)
    //     {
    //         int lung = fine-inizio+1;
    //         int drTot = drA + drC + drT + drG;
            
    //         logga ($"\nCiclo... Lungh: {lung} drTot: {drTot}");

    //         if (drT <= lung)
    //         {
    //             logga("Possibile");
    //             if (minSub > lung) minSub=lung;
    //         }
    //         else
    //         {
    //             logga("Non ce la faccio, esco");
    //             break;
    //         }
            
    //         //proviamo a trimmare a destra
    //         bool mosso = false;
    //         if (inizio<gene.Length-2)
    //         {
    //             if (gene[inizio+1] == 'A' && drA > 0) 
    //             {
    //                 drA--;
    //                 mosso = true;
    //             }
    //             else if (gene[inizio+1] == 'C' && drC > 0)
    //             {
    //                 drC--;
    //                 mosso=true;
    //             }
    //             else if (gene[inizio+1] == 'T' && drT > 0)
    //             {
    //                 drT--;
    //                 mosso = true;
    //             }
    //             else if (gene[inizio+1] == 'G' && drG > 0)
    //             {
    //                 drG--;
    //                 mosso = true;
    //             }
    //             if (mosso) inizio++;
    //         }
            
    //         if (!mosso && fine > inizio)
    //         {
    //             if (gene[fine-1] == 'A' && drA > 0) 
    //             {
    //                 drA--;
    //                 mosso = true;
    //             }
    //             else if (gene[fine-1] == 'C' && drC > 0)
    //             {
    //                 drC--;
    //                 mosso=true;
    //             }
    //             else if (gene[fine-1] == 'T' && drT > 0)
    //             {
    //                 drT--;
    //                 mosso = true;
    //             }
    //             else if (gene[fine-1] == 'G' && drG > 0)
    //             {
    //                 drG--;
    //                 mosso = true;
    //             }
    //             if (mosso) fine--;
    //         }
            
    //         if (!mosso) break;
            


            
    //     }
        
        
    //     return minSub;        
    // }
    
    
    
    
    // //--------------------------------           ---------------------- DEBUG
    // private static readonly bool debug = true;
    // private static void logga<T>(T msg, bool aCapo = true)
    // {
    //     if (debug && aCapo) Console.Error.WriteLine(msg.ToString());
    //     else if (debug) Console.Error.Write(msg.ToString());
    // }
    // //---------------------------------------------------------------- DEBUG
    
     // Una seguenza di geni e' fatta di una stringa formata da gruppi di 4 lettere diverse A C T G
     // Si dice stabile una sequenza dove ogni se le lettere compaiono tutte lo stesso numero di volte
     // ovvero lunghezza / n. di lettere
     // Trova la sottostringa piu' piccola che sostituita da una sequenza stabile
     // Ritorna la lunghezza della sottostringa
    
    private static bool bilanciato (int EV, Dictionary<char, int> mappa)
    {
        if (mappa['A'] <= EV &&
            mappa['C'] <= EV && 
            mappa['T'] <= EV &&
            mappa['G'] <= EV) return true;
        else return false;
    }
    
    public static int steadyGene(string gene)
    {
        int minSub = int.MaxValue;
        int EV = gene.Length/4;
        
        Dictionary<char, int> mappa = new Dictionary<char, int>();
        mappa.Add('A', 0);
        mappa.Add('C', 0);
        mappa.Add('T', 0);
        mappa.Add('G', 0);
        
        for (int i=0; i< gene.Length; i++)
        {
            mappa[gene[i]]++;
        }
        
        int a = 0;
        int b = 0;
        
        while (a<gene.Length && b<gene.Length)
        {
            if (!bilanciato(EV,mappa))
            {
                mappa[gene[b]]--;
                b++;
            }
            else
            {
                minSub = Math.Min(minSub, b-a);
                mappa[gene[a]]++;
                a++;
            }
            
        }
        
        return minSub;
    }
    
    
    
    

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string gene = Console.ReadLine();

        int result = Result.steadyGene(gene);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
