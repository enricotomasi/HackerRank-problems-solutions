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

class Solution {

    // Complete the catAndMouse function below.
    static string catAndMouse(int x, int y, int z)
    {
        int GattoA = x;
        int GattoB = y;
        int TopoC = z;
        
        int passiGattoA = 0;
        int passiGattoB = 0;
        
        if (GattoA < TopoC)
        {
            passiGattoA = TopoC - GattoA;
        }
        else
        {
            passiGattoA = GattoA - TopoC;
        }
        
           if (GattoB < TopoC)
        {
            passiGattoB = TopoC - GattoB;
        }
        else
        {
            passiGattoB = GattoB - TopoC;
        }
        
        Console.WriteLine($"Gatto A = {passiGattoA} - Gatto B = {passiGattoB}");
        
        if (passiGattoA < passiGattoB) return "Cat A";
        if (passiGattoB < passiGattoA) return "Cat B";
        if (passiGattoB == passiGattoA) return "Mouse C";
        
        return ("C'e qualcosa che non va!");
        
   
        
    }

    static void Main(string[] args) {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int q = Convert.ToInt32(Console.ReadLine());

        for (int qItr = 0; qItr < q; qItr++) {
            string[] xyz = Console.ReadLine().Split(' ');

            int x = Convert.ToInt32(xyz[0]);

            int y = Convert.ToInt32(xyz[1]);

            int z = Convert.ToInt32(xyz[2]);

            string result = catAndMouse(x, y, z);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
