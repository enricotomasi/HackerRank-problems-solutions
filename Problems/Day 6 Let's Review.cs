using System;
using System.Collections.Generic;
using System.IO;

class Solution {
    static void Main(String[] args)
    {
        string nstringa =  Console.ReadLine();
        int n = Convert.ToInt32(nstringa);
        
        List<string> risposta = new List<string>();
        
        for (int x = 0; x<n; x++)
        {
            string w = Console.ReadLine();
            risposta.Add(perverti(w));
        }
        
    
        foreach (string pippo in risposta)
        {
            Console.WriteLine(pippo);
        }
        
         
    }
    
    
    //Metodo
        static string perverti(string word)
        {
            string p1 = "";
            string p2 = "";

            for (int x = 0; x < word.Length; x++)
            {
                if (x%2 == 0 || x == 0) //pari o zero
                {
                    p1 += word[x];
                }
                else //dispari
                {
                    p2 += word[x];
                }
            }
            return (p1 + " " + p2);
        }
    
    
    
    
    
    
}
