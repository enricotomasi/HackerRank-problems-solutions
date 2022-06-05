 
using System; 
using System.Collections.Generic; 
using System.IO; 
using System.Linq;

class Solution 
{
    
    //static bool debug = true; 
    
   
   static int[] quickSort(int[] ar) {

    if (ar.Length <= 1) return ar;
    if (ar.Length == 2)  {
        if (ar[0] < ar[1]) {
            Console.WriteLine(ar[0] + " " + ar[1]);
            return ar;
        } else {
            Console.WriteLine(ar[1] + " " + ar[0]);
            return new [] { ar[1], ar[0] };
        }
    }

    var pivot = ar[0];
    //Console.WriteLine("pivot num: " + pivot); 
    var less = ar.Where(s => s < pivot).ToArray();
    var more = ar.Where(s => s > pivot).ToArray();

    //Console.WriteLine("sorting left:" + string.Join(" ", less)); 
    less = quickSort(less);

    //Console.WriteLine("sorting right:" + string.Join(" ", more)); 
    //Console.WriteLine(string.Join(" ", arr)); 
    more = quickSort(more);

    var arr = new List<int>(less); 
    arr.Add(pivot);
    arr = arr.Concat(more).ToList();

    //Console.WriteLine("merging: less " + string.Join(" ", less) + ", pivot " + pivot + ", more " + string.Join(" ", more)); 
    Console.WriteLine(string.Join(" ", arr)); 

    return arr.ToArray();
}
   

/* Tail starts here */
    static void Main(String[] args)
    {
           
           int _ar_size;
           _ar_size = Convert.ToInt32(Console.ReadLine());
           int [] _ar =new int [_ar_size];
           String elements = Console.ReadLine();
           String[] split_elements = elements.Split(' ');
           for(int _ar_i=0; _ar_i < _ar_size; _ar_i++) {
                  _ar[_ar_i] = Convert.ToInt32(split_elements[_ar_i]); 
           }

           quickSort(_ar);
    }
}
