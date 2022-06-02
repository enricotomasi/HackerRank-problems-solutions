

//Write your code here

class Calculator
{
    
    public int power (int x, int y)
    {
       
       if (x >= 0 && y >= 0)
       {
           return Convert.ToInt32( Math.Pow(Convert.ToDouble(x), Convert.ToDouble(y)) );
       }
       else
       {
           throw new Exception("n and p should be non-negative");
       }        
       
        
    }
    
    
}


