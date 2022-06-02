

class Solution {
    //Write your code here
    
    string stac = "";
    string coda = "";
    
    void pushCharacter (char ch)
    {
        stac+=ch;
        // Console.WriteLine($"-stack-push-> Ch:{ch} stack: {stac}");
    }
    
    char popCharacter()
    {
        char ritorno = stac[stac.Length -1];
        stac = stac.Remove(stac.Length -1);
        // Console.WriteLine($"-stack-pop-> Ch:{ritorno} stack: {stac}");
        return ritorno;
    }
    
    
    void enqueueCharacter (char ch)
    {
        coda+=ch;
        // Console.WriteLine($"-coda-incoda-> Ch:{ch} coda: {coda}");
    }
    
    
    char dequeueCharacter()
    {
        char ritorno = coda[0];
        coda = coda.Substring(1);
        // Console.WriteLine($"-coda-decoda-> Ch:{ritorno} coda: {coda}");
        return ritorno;
    }
    

