

// The days of the week are: "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"
function getDayName(dateString) {
    let dayName;
    // Write your code here
    
    return dayName;
}

function getDayName(data){
    let dataVera = new Date (data);
    let giorno = dataVera.getDay();
    let ritorno = "";
    switch (giorno) {
        
        case 0:
        ritorno = "Sunday";
        break; 
        
        case 1:
        ritorno = "Monday";
        break; 
        
        case 2:
        ritorno = "Tuesday";
        break; 
        
        case 3:
        ritorno = "Wednesday";
        break; 
        
        case 4:
        ritorno = "Thursday";
        break; 
                
        case 5:
        ritorno = "Friday";
        break; 
                
        case 6:
        ritorno = "Saturday";
        break; 
   
        
    }
    
    
    return ritorno;
}


