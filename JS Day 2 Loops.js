

/*
 * Complete the vowelsAndConsonants function.
 * Print your output using 'console.log()'.
 */
function vowelsAndConsonants(s) {
    

    for (let x = 0; x<s.length; x++)
    {
        let carattere = s[x];
        if (carattere === "a" ||
        carattere === "e" ||
        carattere === "i" ||
        carattere === "o" ||
        carattere === "u") {
            console.log(carattere);
        }
        
    }

    
       for (let x = 0; x<s.length; x++)
    {
        let carattere = s[x];
        if (carattere !== "a" &&
        carattere !== "e" &&
        carattere !== "i" &&
        carattere !== "o" &&
        carattere !== "u") {
            console.log(carattere);
        }
        
    }
    
    
}

