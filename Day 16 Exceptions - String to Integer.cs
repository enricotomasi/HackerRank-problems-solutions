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



class Solution
{
    public static void Main(string[] args)
    {
        string S = Console.ReadLine();
        string output = "";
        
        try
        {
            int conv = Int32.Parse(S);
            output = S;
        }
        catch (Exception e)
        {
            output = "Bad String";
        }
        finally
        {
            Console.WriteLine(output);
        }
        
        
    }
}
