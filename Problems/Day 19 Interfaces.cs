

public class Calculator : AdvancedArithmetic
{
    public int divisorSum(int n)
    {
        int somma = 0;
        
        for (int x = n; x > 0; x--)
        {
            if (n % x == 0)
            {
                // Console.WriteLine($"x={x} - aggiunto");
                somma+=x;
            } 
            // else
            // {
                // Console.WriteLine($"x={x} - ");
            // }
            // Console.WriteLine();
        }
        
        return somma;
    }
}

