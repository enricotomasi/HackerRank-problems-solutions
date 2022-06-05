using System;
using System.Collections.Generic;
using System.IO;
using System.Globalization;


class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        
        //CultureInfo provider = CultureInfo.InvariantCulture;
        int fine = 0;
        
        string[] restituito = Console.ReadLine().Split(' ');
        string[] preso = Console.ReadLine().Split(' ');
        
        int dr = Convert.ToInt32(restituito[0]);
        int mr = Convert.ToInt32(restituito[1]);
        int ar = Convert.ToInt32(restituito[2]);
        
        int dp = Convert.ToInt32(preso[0]);
        int mp = Convert.ToInt32(preso[1]);
        int ap = Convert.ToInt32(preso[2]);
        
        // Console.WriteLine($"{dr} {mr} {ar} - {dp} {mp} {ap}");
        
        
        string resStringa = $"{mr.ToString("00")}/{dr.ToString("00")}/{ar.ToString("00")}";       
        string preStringa = $"{mp.ToString("00")}/{dp.ToString("00")}/{ap.ToString("00")}";       
        // Console.WriteLine(resStringa);
        
        DateTime dataRest = DateTime.Parse(resStringa);
        DateTime dataPreso = DateTime.Parse(preStringa);
        
        // Console.WriteLine(dataRest.ToString());
        // Console.WriteLine(dataPreso.ToString());
        
        if (dataRest > dataPreso)
        {
            TimeSpan giorniRitardo = dataRest.Subtract(dataPreso);
            
            double giorniDouble = giorniRitardo.TotalDays;
            int giorni = Convert.ToInt32(giorniDouble);
            
            int mesi = mr-mp;
                        
            // Console.WriteLine(giorni.ToString());
            
            if (mr == mp && ar == ap) //in ritardo pero nello stesso anno/mese
            {
                // Console.WriteLine("Stesso anno/mese");
                fine = giorni*15;
            }
            else if (mr != mp && ar == ap) // stesso anno
            {
                // Console.WriteLine("Stesso anno");
                fine = mesi*500;
            }
            else // dopo la fine dell'anno
            {
                // Console.WriteLine("Dopo la fine dell'anno");
                fine = 10000;
            }
            
            
            
        }
        
        Console.WriteLine(fine);
    }
}
