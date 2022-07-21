//---Classes base---

    class Person {
        constructor(name) {
            this.name = name;
        }
        getName() {
            return this.name;
        }
    }

    // In the Person class, the constructor() is where you can initialize the properties of an instance.

    let john = new Person("John Doe");

    console.log(typeof Person); // function

    console.log(john instanceof Person); // true
    console.log(john instanceof Object); // true


//---Class vs. Custom type---

    //1. First, class declarations are not hoisted like function declarations.
    //2. All the code inside a class automatically executes in the strict mode
    //3. Class methods are non-enumerable
    //4. Calling the class constructor without the new operator will result in an error

//--- Getters and Setters ---

    class Person {
        constructor(name) {
            this.name = name;
        }
        get name() {
            return this._name;
        }
        set name(newName) {
            newName = newName.trim();
            if (newName === '') {
                throw 'The name cannot be empty';
            }
            this._name = newName;
        }
    }

    let name = person.name;
    person.name = 'Jane Smith';

    //If a class has only a getter but not a setter and you attempt to use the setter, the change won’t take any effect

//--- Singleton with class expressions ---

    let app = new class {
        constructor(name) {
            this.name = name;
        }
        start() {
            console.log(`Starting the ${this.name}...`);
        }
    }('Awesome App');

    app.start(); // Starting the Awesome App...


// ---Computed Property in classes

let name = 'fullName';

class Person {
    constructor(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }
    get [name]() {
        return `${this.firstName} ${this.lastName}`;
    }
}

let person = new Person('John', 'Doe');
console.log(person.fullName);

// --- Inheritance ---


    //ES5
    function Animal(legs) {
        this.legs = legs;
    }

    Animal.prototype.walk = function () {
        console.log('walking on ' + this.legs + ' legs');
    }

    function Bird(legs) {
        Animal.call(this, legs);
    }

    Bird.prototype = Object.create(Animal.prototype);
    Bird.prototype.constructor = Animal;


    Bird.prototype.fly = function () {
        console.log('flying');
    }

    var pigeon = new Bird(2);
    pigeon.walk(); // walking on 2 legs
    pigeon.fly();  // flying

    //ES6

    class Animal {
        constructor(legs) {
            this.legs = legs;
        }
        walk() {
            console.log('walking on ' + this.legs + ' legs');
        }
    }

    class Bird extends Animal {
        constructor(legs) {
            super(legs);
        }
        fly() {
            console.log('flying');
        }
    }


    let bird = new Bird(2);

    bird.walk();
    bird.fly();

// --- Shadowing ---

    //ES6 allows the child class and parent class to have methods with the same name
    class Dog extends Animal {
        constructor() {
            super(4);
        }
        walk() {
            super.walk(); // call the method of the parent class
            console.log(`go walking`);
        }
    }

    let bingo = new Dog();
    bingo.walk(); // go walking

//---Inheriting from built-in types

    class Queue extends Array {
        enqueue(e) {
            super.push(e);
        }
        dequeue() {
            return super.shift();
        }
        peek() {
            return !this.empty() ? this[0] : undefined;
        }
        empty() {
            return this.length === 0;
        }
    }

    var customers = new Queue();
    customers.enqueue('A');
    customers.enqueue('B');
    customers.enqueue('C');

    while (!customers.empty()) {
        console.log(customers.dequeue());
}

// ---Static methods---

    class Person {
        constructor(name) {
            this.name = name;
        }
        getName() {
            return this.name;
        }
        static createAnonymous(gender) {
            let name = gender == "male" ? "John Doe" : "Jane Doe";
            return new Person(name);
        }
    }

    let anonymous = person.createAnonymous("male"); //TypeError: person.createAnonymous is not a function

//  ---Static properties---
    class Item {
        constructor(name, quantity) {
            this.name = name;
            this.quantity = quantity;
            this.constructor.count++;
        }
        static count = 0;
        static getCount() {
            return Item.count++;
        }
    }

// --- Private Fields and Methods (ES2022)

    class Circle {
        #radius; // private field
        constructor(value) {
            this.#radius = value;
        }

        #privateMethod() { // private methods
            //...
        }
        get area() {
            return Math.PI * Math.pow(this.#radius, 2);
        }
    }

    // Getter and setter can be added to privire fields
    //Private fields are only accessible inside the class where they’re defined
    // private fied can be static