

/**
*   Return the second largest number in the array.
*   @param {Number[]} nums - An array of numbers.
*   @return {Number} The second largest number in the array.
**/
function getSecondLargest(nums) {
    // Complete the function
    let secondo = 0;
    let max = 0;
    
    
    nums.sort();
    
    nums.forEach(element => {
        
        if (element>=max) {
            max = element;
        }
        
    }
    )
    
    
    while(nums.indexOf(max) != -1){
        let indice = nums.indexOf(max);
        nums.splice(indice,1);
    }
    
    
     nums.forEach(element => {
        
        if (element>=secondo) {
            secondo = element;
        }
        
    }
    )
    
   
   
    
    return secondo;    
}

