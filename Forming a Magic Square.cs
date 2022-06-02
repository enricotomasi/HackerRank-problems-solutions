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
     * Complete the 'formingMagicSquare' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts 2D_INTEGER_ARRAY s as parameter.
     */

    // costo cambio a -> b = abs(a-b)


    public static int CalcolaCosto(List<List<int>> originale, int[,] sol)
    {
    
    int costo = 0;
    
    for (int x = 0; x<3; x++)
    {
        for (int y = 0; y<3; y++)
        {
            costo+= Math.Abs(originale[x][y] - sol[x,y]);
        }
    }

        return costo;
    }


    public static int formingMagicSquare(List<List<int>> s)
    {
    
    int[,] m1 = new int[3,3]
    {
        {8,1,6},
        {3,5,7},
        {4,9,2}
    };
    
    int[,] m2 = new int[3,3]
    {
        {6,1,8},
        {7,5,3},
        {2,9,4}
    };
    
    int[,] m3 = new int[3,3]
    {
        {4,9,2},
        {3,5,7},
        {8,1,6}
    };
    
    int[,] m4 = new int[3,3]
    {
        {2,9,4},
        {7,5,3},
        {6,1,8}
    };
    
    int[,] m5 = new int[3,3]
    {
        {8,3,4},
        {1,5,9},
        {6,7,2}
    };
    
    int[,] m6 = new int[3,3]
    {
        {4,3,8},
        {9,5,1},
        {2,7,6}
    };
    
    int[,] m7 = new int[3,3]
    {
        {6,7,2},
        {1,5,9},
        {8,3,4}
    };
    
    int[,] m8 = new int[3,3]
    {
        {2,7,6},
        {9,5,1},
        {4,3,8}
    };
    
    
    int passaggiMin = CalcolaCosto(s, m1);
    
    int costom2 = CalcolaCosto(s, m2);
    if ( costom2 < passaggiMin) passaggiMin = costom2;
    
    int costom3 = CalcolaCosto(s, m3);
    if ( costom3 < passaggiMin) passaggiMin = costom3;
    
    int costom4 = CalcolaCosto(s, m4);
    if ( costom4 < passaggiMin) passaggiMin = costom4;
    
    int costom5 = CalcolaCosto(s, m5);
    if ( costom5 < passaggiMin) passaggiMin = costom5;
    
    int costom6 = CalcolaCosto(s, m6);
    if ( costom6 < passaggiMin) passaggiMin = costom6;
    
    int costom7 = CalcolaCosto(s, m7);
    if ( costom7 < passaggiMin) passaggiMin = costom7;
    
    int costom8 = CalcolaCosto(s, m8);
    if ( costom8 < passaggiMin) passaggiMin = costom8;
    
     
    return passaggiMin;   
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        List<List<int>> s = new List<List<int>>();

        for (int i = 0; i < 3; i++)
        {
            s.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(sTemp => Convert.ToInt32(sTemp)).ToList());
        }

        int result = Result.formingMagicSquare(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
