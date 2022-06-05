

  public static Node removeDuplicates(Node head)
  {
    //Write your code here
    //Console.WriteLine(head.data);
    //Console.WriteLine(head.next.data);
    
    Node start=head;
    while(start.next!=null)
    {
        // Console.WriteLine("----------------------");
        // Console.WriteLine($"Confronto fra {start.data} e {start.next.data}");
        
        if (start.data == start.next.data)
        {
            // Console.WriteLine("Uguale!");
            start.next = start.next.next;
            
        }
        else
        {
            start = start.next;
        }
        

    }

    
    return head;
    
  }

