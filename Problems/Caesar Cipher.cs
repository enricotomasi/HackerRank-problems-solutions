 
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
     * Complete the 'caesarCipher' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts following parameters:
     *  1. STRING s
     *  2. INTEGER k
     */

    public static string caesarCipher(string s, int k)
    {
        string ritorno = "";
        string alfabeto = "abcdefghijklmnopqrstuvwxyz";
        string alfaShift = "";
        string sLow = s.ToLower();
        // Console.WriteLine("----------------------");
        // Console.WriteLine($"Alfabeto: {alfabeto} --- Lunghezza = {alfabeto.Length}");
        
        int shift = k % alfabeto.Length;
        // Console.WriteLine($"Shift: {shift}");
        
        for (int i=0; i<alfabeto.Length;i++)
        {
            
            int pos;
            
            if (i+shift >= alfabeto.Length)
            {
                pos = (i+shift) - alfabeto.Length;
            }
            else
            {
                pos = i+shift;
            }
            
            // Console.WriteLine($"Ciclo {i} Pos: {pos} shift: {shift} i+shift: {i+shift} > alfabeto.lennght {alfabeto.Length} {i+shift > alfabeto.Length} ");
            alfaShift += alfabeto[pos];
        }
        
        // Console.WriteLine($"{alfaShift} ---\nLunghezza stringa: {s.Length}");
        
        for (int j=0; j<s.Length; j++)
        {
            char orig = s[j];
            bool maiuscolo = char.IsUpper(orig);
            string origMin = orig.ToString().ToLower();
            orig = origMin[0];
            
            // Console.WriteLine($"Carattere: {orig} - Maiuscolo: {orig}");
            try
            {
                int posOrig = alfabeto.IndexOf(orig);
                if (maiuscolo)
                {
                    string mai = alfaShift[posOrig].ToString().ToUpper();
                    ritorno +=mai;
                }
                else
                {
                    ritorno+=alfaShift[posOrig];
                }
                
            }
            catch
            {
                ritorno += orig;
            }
            
            // Console.WriteLine($"Ciclo {j}");
        
        }
        
        // Console.WriteLine($"Ritorno: {ritorno}");
        
        
        return ritorno;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string s = Console.ReadLine();

        int k = Convert.ToInt32(Console.ReadLine().Trim());

        string result = Result.caesarCipher(s, k);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
