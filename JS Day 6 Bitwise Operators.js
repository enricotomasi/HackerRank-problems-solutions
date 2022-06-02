

function getMaxLessThanK(n, k) {
    let max = 0;
    
    // console.log("---------------");
    
    for (let x = 1; x<=n; x++){
        
        for (let y = 1; y<=n; y++) {
            
            let result = (x&y);
            // console.log(`x = ${x} - y = ${y} -- max = ${max} - k = ${k} - result = ${result}`);
            
            if (x==y)
            {
                // console.log("x=y, esco!");
                break;
            }
            
            if (result < k && result > max) {
                 max = result;
                //  console.log(`Nuovo massimo trovato, max = ${max}`);
                 
                 }
                 
                
        }
    }
    
    
    
    return max;
    
}


