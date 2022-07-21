// --- Function type

    //All functions are objects. They are the instances of the Function type

    function add(x, y) {
        return x + y;
    }

    console.log(add.length); // 2
    console.log(add.prototype); // Object{}

// --- Function methods: apply, call, and bind

let cat = { type: 'Cat', sound: 'Meow' };
let dog = { type: 'Dog', sound: 'Woof' };

const say = function (message) {
    console.log(message);
    console.log(this.type + ' says ' + this.sound);
};

say.apply(cat, ['What does a cat say?']); // What does a cat sound?  Cat says Meow
say.call(cat, 'What does a cat say?');

//The bind() method creates a new function instance whose this value is bound to the object that you provide. 

    let car = {
        speed: 5,
        start: function () {
            console.log('Start with ' + this.speed + ' km/h');
        }
    };

    let aircraft = {
        speed: 10,
        fly: function () {
            console.log('Flying');
        }
    };

    let taxiing = car.start.bind(aircraft);

    taxiing(); // Start with 10 km/h

    //bind() method creates a new function that you can execute later while the call() method executes the function immediately

//---Closure

    //In JavaScript, a closure is a function that references variables in the outer scope from its inner scope.

    function greeting() {
        let message = 'Hi';

        function sayHi() {
            console.log(message);
        }

        return sayHi;
    }
    let hi = greeting();
    hi(); // still can access


// --- Immediately Invoked Function Expression

    (function () {
        var counter = 0;

        function add(a, b) {
            return a + b;
        }

        console.log(add(10, 20)); // 30
    }());

    //By placing functions and variables inside an immediately invoked function expression, you can avoid polluting them to the global object:

//---Arrow Functions

    let add = (x, y) => x + y;

    console.log(add(10, 20)); // 30;

    function Car() {
        this.speed = 0;

        this.speedUp = function (speed) {
            let self = this;
            this.speed = speed;
            setTimeout(function () {
                console.log(this.speed); // undefined , 
                //The reason is that the this of the anonymous function shadows the this of the speedUp() method. use self
            }, 1000);

        };
    }

    let car = new Car();
    car.speedUp(50);

    // fix using arrow functions

    //Unlike an anonymous function, an arrow function captures the this value of the enclosing context instead of creating its own this context.

    function Car() {
        this.speed = 0;

        this.speedUp = function (speed) {
            this.speed = speed;
            setTimeout(
                () => console.log(this.speed),
                1000);

        };
    }

    //It is a good practice to use arrow functions for callbacks and closures because the syntax of arrow functions is cleaner

// --- Rest parameters

    function fn(a, b, ...args) {
        //...
    }