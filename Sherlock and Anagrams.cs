 
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
   
    public static int sherlockAndAnagrams(string s)
    {
        int anagrammi=0;
        var dict = new Dictionary<string, int>();

        for (int lung = 1; lung <= s.Length - 1; lung++)
        for (int i = 0; i <= s.Length - lung; i++)
        {
          var norm = new string(s.Substring(i, lung).OrderBy(c => c).ToArray());
          if (dict.ContainsKey(norm))
          {
            anagrammi += dict[norm];
            dict[norm] += 1;
          }
          else
            dict[norm] = 1;
        }
        
        return anagrammi;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine().Trim());

        for (int qItr = 0; qItr < q; qItr++)
        {
            string s = Console.ReadLine();

            int result = Result.sherlockAndAnagrams(s);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
