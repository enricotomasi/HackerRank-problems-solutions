 
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
     * Complete the 'decentNumber' function below.
     *
     * The function accepts INTEGER n as parameter.
     */

    // private static readonly bool debug = false;
 
 
    // // Funziona ma e troppo lenta
    // // Continuo a non capire perche' la e accentata
    // // non sia considerata ascii......
    // //  Il codice ASCII 232 secondo voi cos'e'????????
    
    // public static void decentNumber(int n)
    // {
    //     // if(debug) Console.Error.WriteLine($"\n Numero {n}");
        
    //     string result = "-1";
    //     for (int i = 0; i <= n; i++)
    //     {

    //         int tre=i;
    //         int cinque=n-i;
            
    //         // if (debug) Console.Error.WriteLine($"5: {cinque} - 3: {tre}");
            
    //         if ( (tre%5==0) && (cinque%3==0) )
    //         {
    //             result = "";
                
    //             for (int j=0; j<cinque; j++)
    //             {
    //                 result+="5";
    //             }
                
    //             for (int j=0; j<tre; j++)
    //             {
    //                 result+="3";
    //             }
                
    //             break;
                
    //         }

    //     }
        
    //     Console.WriteLine(result);

    

    public static void decentNumber(int n)
    {
        StringBuilder ritorno = new StringBuilder();
        
        if (n%3==0)
        {
            for (int i = 0; i<n; i++)
            {
                ritorno.Append("5");
            }
        }
        else if (n %3 ==1 && n>= 10)
        {
            for (int i = 0; i<n; i++)
            {
                if (i >= (n-10)) ritorno.Append("3");
                else ritorno.Append("5");
            }
        }
        else if (n%3==2 && n>=5)
        {
            for (int i = 0; i<n; i++)
            {
                if (i >= (n-5)) ritorno.Append("3");
                else ritorno.Append("5");
            }
        }
        else
        {
            ritorno.Append("-1");
        }
        
            
        Console.WriteLine(ritorno);        
    }
        
        
}



class Solution
{
    public static void Main(string[] args)
    {
        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            Result.decentNumber(n);
        }
    }
}
