

	static int getHeight(Node root){
      //Write your code here
      
      int l = 0;
      int r = 0;
      
      if (root.left != null)
      {
          l = getHeight(root.left) + 1;
      }
        
        if (root.right != null)
        {
            r = getHeight(root.right) +1;
        }
    
    
        if (l > r) return l; else return r;
      
    }

