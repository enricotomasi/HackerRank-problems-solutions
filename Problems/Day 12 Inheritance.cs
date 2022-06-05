

class Student : Person{
    private int[] testScores;  
  
    /*	
    *   Class Constructor
    *   
    *   Parameters: 
    *   firstName - A string denoting the Person's first name.
    *   lastName - A string denoting the Person's last name.
    *   id - An integer denoting the Person's ID number.
    *   scores - An array of integers denoting the Person's test scores.
    */
    // Write your constructor here
    
    public int[] cazzodipunteggi;
    
    public Student(){}
    
    public Student(string nome, string cognome, int cazzodiid, int[] punteggi)
    {
        this.firstName = nome;
        this.lastName = cognome;
        this.id = cazzodiid;
        
        this.cazzodipunteggi = punteggi;
    }
    
    /*	
    *   Method Name: Calculate
    *   Return: A character denoting the grade.
    */
    // Write your method here
    
    public char Calculate()
    {
        
        int totale = 0;
        foreach (int x in cazzodipunteggi)
        {
            totale +=x;
        }
        
        int media = (totale/cazzodipunteggi.Length);
        //Console.WriteLine(media);
        
        if (media >= 90) return 'O';
        if (media >= 80) return 'E';
        if (media >= 70) return 'A';
        if (media >= 55) return 'P';
        if (media >= 40) return 'D';
        if (media <= 40) return 'T';
        
        return '@';
        
        
    }
    
    
}


