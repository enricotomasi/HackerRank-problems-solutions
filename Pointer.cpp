 
#include <stdio.h>
#include <cmath> 

void update(int *a,int *b) {
    // Complete this function    
    int p1 = (*a) + (*b);
    int p2 = abs((*a)-(*b));
    
    (*a) = p1;
    (*b) = p2;
}

int main() {
    int a, b;
    int *pa = &a, *pb = &b;
    
    scanf("%d %d", &a, &b);
    update(pa, pb);
    printf("%d\n%d", a, b);

    return 0;
}
