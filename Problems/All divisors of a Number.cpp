//{ Driver Code Starts
// Initial Template for C++
#include <bits/stdc++.h>
using namespace std;

// } Driver Code Ends
class Solution 
{
  public:
    void print_divisors(int n) 
    {
        // Code here.
        
        /*
            1. Start by inputting a number n
            2. Let an int variable limit be sqrt(n)
            3. Run a loop from i=1 to i=limit
            3.1 if n is divisible by i
            3.1.1 Print i
            3.1.2 if i and n/i are unequal, print n/i also.
            4. End.
        */
        
        vector<int> div;

        for (int i=1; i*i<=n; i++)
        {
            if (n % i == 0)
            {
                div.push_back(i);
                if (i != n/i) div.push_back(n/i);
            }
        }
        
        sort(div.begin(), div.end());
        for (auto it : div) cout << it << " ";
    }
};

//{ Driver Code Starts.
int main() {
    int T;
    cin >> T;
    while (T--) {
        int n;
        cin >> n;
        Solution ob;
        ob.print_divisors(n);
        cout << endl;
    }
    return 0;
}
// } Driver Code Ends