 
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
     * Complete the 'minimumNumber' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. STRING password
     */

    public static int minimumNumber(int n, string password)
    {
        // Return the minimum number of characters to make the password strong
        
        int ritorno=0;
        
        string numbers = "0123456789";
        string lower_case = "abcdefghijklmnopqrstuvwxyz";
        string upper_case = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string special_characters = "!@#$%^&*()-+";
        
        if (!(password.IndexOfAny(numbers.ToCharArray()) >= 0)) ritorno++;
        if (!(password.IndexOfAny(lower_case.ToCharArray()) >= 0)) ritorno++;
        if (!(password.IndexOfAny(upper_case.ToCharArray()) >= 0)) ritorno++;
        if (!(password.IndexOfAny(special_characters.ToCharArray()) >= 0)) ritorno++;
        
        if (password.Length < 6 && (6-password.Length > ritorno)) ritorno = 6-password.Length;
    
        return ritorno;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int n = Convert.ToInt32(Console.ReadLine().Trim());

        string password = Console.ReadLine();

        int answer = Result.minimumNumber(n, password);

        textWriter.WriteLine(answer);

        textWriter.Flush();
        textWriter.Close();
    }
}
