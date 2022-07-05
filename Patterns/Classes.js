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
