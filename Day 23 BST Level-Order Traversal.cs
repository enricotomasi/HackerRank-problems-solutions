
    
	static void levelOrder(Node root)
    {
        
        if(root == null) return;

        Queue<Node> q =new Queue<Node>();
        q.Enqueue(root);
         
        while(true)
        {
            int nodeCount = q.Count;
            if(nodeCount == 0)
                break;

            while(nodeCount > 0)
            {
                Node node = q.Peek();
                Console.Write(node.data + " ");
                q.Dequeue();
                if(node.left != null)
                    q.Enqueue(node.left);
                if(node.right != null)
                    q.Enqueue(node.right);
                nodeCount--;
            }
        }

        
        

    }
    
    
