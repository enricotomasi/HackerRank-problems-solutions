using System;
using System.Collections.Generic;
using System.IO;


class Solution
{

    static void Main(String[] args)
    {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
    
    string nstringa = Console.ReadLine();
    
    int n = Convert.ToInt32(nstringa);
    
    var rubrica = new Dictionary<string, string>();
    
    
    for (int x = 0; x < n; x++)      
    {
        string lettura = Console.ReadLine();
        string[] divisa = lettura.Split(' ');
        rubrica.Add(divisa[0],divisa[1]);
    }
    
    //
    while(true)
    {
        string inp = Console.ReadLine();
        if (String.IsNullOrEmpty(inp)) break;
        if (rubrica.ContainsKey(inp))
        {
            Console.WriteLine($"{inp}={rubrica[inp]}");
        }
        else
        {
            Console.WriteLine("Not found");
        }
        
    }
    
        
            
        
        
    }
    
}
