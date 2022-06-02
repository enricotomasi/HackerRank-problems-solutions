

//Write MyBook class
class MyBook : Book
{
    protected int prezzo;

    public MyBook(string t, string a, int Prezzo) : base(t,a)
    {
        this.prezzo = Prezzo;
    }
    
    
    public override void display()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Price: {prezzo}");
    }
    
}



