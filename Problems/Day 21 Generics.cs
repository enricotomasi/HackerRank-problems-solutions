

	/**
	*    Name: PrintArray
	*    Print each element of the generic array on a new line. Do not return anything.
	*    @param A generic array
	**/
    // Write your code here



static void PrintArray<T>(T[] lista)
{
    foreach (T item in lista)
    {
        Console.WriteLine(item.ToString());
    }
    
}


