 
#include <iostream>
#include <cstdio>
using namespace std;

/*
Add `int max_of_four(int a, int b, int c, int d)` here.
*/

int max_of_four(int a, int b, int c, int d){
   if (b<a && c<a && d<a) return a;
   if (b>a && c<b && d<b) return b;
   if (a<c && b<c && d<c) return c;
   if (a<d && b<d && c<d) return d;
   
   return 69;
   
}

int main() {
    int a, b, c, d;
    scanf("%d %d %d %d", &a, &b, &c, &d);
    int ans = max_of_four(a, b, c, d);
    printf("%d", ans);
    
    return 0;
}
