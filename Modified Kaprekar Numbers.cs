 
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
     * Complete the 'kaprekarNumbers' function below.
     *
     * The function accepts following parameters:
     *  1. INTEGER p lower
     *  2. INTEGER q max
     */

    public static void kaprekarNumbers(int p, int q)
    {
        bool capraCavoliGlobale=false;
        for (;p<=q; p++)        
        {
            bool capraCavoli=false;
            double quadrato = Math.Pow(p, 2);
            if (quadrato <10)
            {
                if (quadrato==1)
                {
                    capraCavoliGlobale=true;
                    capraCavoli=true;
                } 
            }
            else
            {
                string stringa=quadrato.ToString();
                string sinistra="";
                string destra="";
                
                double sommaDestra=0;
                double sommaSinistra=0;
                
                for (int y=0; y<stringa.Length;y++)
                {
                    if (y < stringa.Length /2)
                    {
                        sinistra += stringa[y];
                    }
                    else
                    {
                        destra += stringa[y];
                    }
                }
                
                sommaSinistra = Convert.ToDouble(sinistra);
                sommaDestra = Convert.ToDouble(destra);
                
                if (sommaDestra+sommaSinistra == p )
                {
                    capraCavoliGlobale=true;
                    capraCavoli=true;
                }
            }
            
            if (capraCavoli) Console.Write(p + " ");

        }

        if (!capraCavoliGlobale) Console.WriteLine("INVALID RANGE");

        
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        int p = Convert.ToInt32(Console.ReadLine().Trim());

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        Result.kaprekarNumbers(p, q);
    }
}
