

/*
 * Modify and return the array so that all even elements are doubled and all odd elements are tripled.
 * 
 * Parameter(s):
 * nums: An array of numbers.
 */
function modifyArray(nums) {
    let ritorno = [];
    
    nums.map( (s) => {
        
        if (s%2 == 0) { ritorno.push(s*2); }
        else { ritorno.push(s*3); }
    });
       
       return ritorno;
    
}

