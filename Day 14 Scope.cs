

	// Add your code here
    
    public Difference(int[] __elements)
    {
        this.elements = __elements;
        
    }
  
    public void computeDifference()
    {
        int max = 0;
        int lunghezza = elements.Length;
        
        for (int x = 0; x<lunghezza; x++)
        {
            for (int y = 0; y<lunghezza; y++)
            {
                int differenza = elements[x] - elements[y];
                if (differenza > max) max = differenza;
            }
        }
        
        this.maximumDifference = max;
    }
    



