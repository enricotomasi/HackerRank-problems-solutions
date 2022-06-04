 
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
     * Complete the 'jimOrders' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts 2D_INTEGER_ARRAY orders as parameter.
     */

    public static List<int> jimOrders(List<List<int>> orders)
    {
        List<int> ritorno = new List<int>();
        
        int[,] arr = new int[orders.Count, 2];
        
        
        //ARRAY   TOTALE, NUMERO
        int conta = 0;
        for (int i=0; i<orders.Count; i++)
        {
            conta++;
            arr[i,0] = orders[i][0] + orders[i][1];
            arr[i,1] = i;
        }
        
 
        for (int i=0; i<orders.Count; i++)
        {
            int numero= int.MaxValue;
            int posizione = 0;
            
            for (int j=0; j<orders.Count; j++)
            {
                if (arr[j,0] < numero)
                {
                    numero = arr[j,0];
                    posizione = j;
                }
            }
            
            ritorno.Add(posizione+1);
            arr[posizione,0] = int.MaxValue;

        }
        

        return ritorno;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        List<List<int>> orders = new List<List<int>>();

        for (int i = 0; i < n; i++)
        {
            orders.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(ordersTemp => Convert.ToInt32(ordersTemp)).ToList());
        }

        List<int> result = Result.jimOrders(orders);

        textWriter.WriteLine(String.Join(" ", result));

        textWriter.Flush();
        textWriter.Close();
    }
}
