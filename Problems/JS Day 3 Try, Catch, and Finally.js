

/*
 * Complete the reverseString function
 * Use console.log() to print to stdout.
 */
function reverseString(s) {
    

    let lunghezza = s.length-1;
    // console.warn(lunghezza);
    
     try{
         let arrei = s.split("");
         let arreiReverse = arrei.reverse();
         console.log(arreiReverse.join(""));
        
         
    }
         
         
     catch (e){
         console.log(e.message);
         console.log(s);
     }
     finally {
         
     }
    
    

}

