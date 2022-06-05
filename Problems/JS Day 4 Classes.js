/*
 * Implement a Polygon class with the following properties:
 * 1. A constructor that takes an array of integer side lengths.
 * 2. A 'perimeter' method that returns the sum of the Polygon's side lengths.
 */

class Polygon {
    
    constructor (arrei){
        this.arrei = arrei;
    }
  
    
     perimeter() {
        let perimetro = 0;
        //console.warn("Richiamato perimetro");
        for (const e of this.arrei) {
            //console.warn(e);
            perimetro += parseInt(e);
        }
        //console.warn("---------------------");
        return perimetro;
    }
        
}
    

