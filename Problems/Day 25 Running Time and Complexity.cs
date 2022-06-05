using System;
using System.Collections.Generic;
using System.IO;
class Solution {
    static void Main(String[] args) {
        /* Enter your code here. Read input from STDIN. Print output to STDOUT. Your class should be named Solution */
        int quanti = Convert.ToInt32(Console.ReadLine());
        
        List<int> lista = new List<int>(); 
        
        for (int x = 0; x<quanti; x++)
        {
            lista.Add(Convert.ToInt32(Console.ReadLine()));
        }
        
        
        foreach (int x in lista)
        {
            bool flag = true;
            
            int k = 2;
            while (k*k <= x)
            {
                if ((x % k) == 0)
                {
                    flag = false;
                    break;
                } 
                else
                {
                    k++;
                }
            }
            
            if (x==1) flag = false;
            
            if (flag) Console.WriteLine("Prime");
            else Console.WriteLine("Not prime");
            
        }
        
        
        
    }
}
