/*In JavaScript, you can call a function in the following ways:

-Function invocation
-Method invocation
-Constructor invocation
-Indirect invocation

*/

//1. Simple function invocation

    function show() {
        console.log(this);  // this - global object here (window) in the not strict mode , undefined - in the strict
    }

    show();


//2. Method invocation

    let car = {
        brand: 'Honda',
        getBrand: function () {
            return this.brand; // this is to object that owns the method
        }
    }

    let brand = car.getBrand;

    brand() // You get undefined instead of "Honda" because when you call a method without specifying its object,
    //JavaScript sets this to the global object in non - strict mode and undefined in the strict mode.

    let brand = car.getBrand.bind(car); /fix

    let bike = {
        brand: 'Harley Davidson'
    }

    let brand = car.getBrand.bind(bike);
    console.log(brand()); //Harley Davidson

//3. Constructor invocation

    function Car(brand) {
        this.brand = brand;
    }

    Car.prototype.getBrand = function () {
        return this.brand;
    }

    let car = new Car('Honda');
    console.log(car.getBrand());

    var bmw = Car('BMW');
    console.log(bmw.brand); // Cannot read property 'brand' of undefined
    //Since the this value in the Car() sets to the global object, the bmw.brand returns undefined.

//4) Indirect Invocation

function getBrand(prefix) {
    console.log(prefix + this.brand);
}

let honda = {
    brand: 'Honda'
};
let audi = {
    brand: 'Audi'
};

getBrand.call(honda, "It's a ");
getBrand.call(audi, "It's an ");

getBrand.apply(honda, ["It's a "]); 
getBrand.apply(audi, ["It's an "]);

//--Arrow functions--

/* It means the arrow function does not create its own execution context but inherits 
 * the this from the outer function where the arrow function is defined
 */

function Car() {
    this.speed = 120;
}

Car.prototype.getSpeed = () => {
    return this.speed;
}

var car = new Car();
car.getSpeed(); // TypeError
