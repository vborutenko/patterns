//An object is a collection of key / value pairs or properties.When the value is a function, the property becomes a method.Typically,
//    you use methods to describe the object behaviors.


let person = {
    firstName: 'John',
    lastName: 'Doe',
    greet: function () {
        console.log('Hello, World!');
    },
    great2() { // ES6 provides you with the concise method syntax 
        console.log('Hello, World2');
    }
};

// The this value

//Inside a method, the this value references the object that invokes the method. 
//Therefore, you can access a property using the this value as follows:
let person = {
    firstName: 'John',
    lastName: 'Doe',
    getFullName: function () {
        return this.firstName + ' ' + this.lastName;
    }
};

//---Constructor functions---

    let person = {
        firstName: 'John',
        lastName: 'Doe'
    };

    /*In practice, you often need to create many similar objects like the person object.

    To do that, you can use a constructor function to define a custom type and the new operator to create multiple objects from this type.

    Technically speaking, a constructor function is a regular function with the following convention:

    --The name of a constructor function starts with a capital letter like Person, Document, etc.
    --A constructor function should be called only with the new operator. */

    function Person(firstName, lastName) {
        this.firstName = firstName;
        this.lastName = lastName;
    }

    let person = new Person('John', 'Doe');

    //== >

    function Person(firstName, lastName) {
        // this = {};

        // add properties to this
        this.firstName = firstName;
        this.lastName = lastName;

        // return this;
    }


//---Adding methods to JavaScript constructor functions---


function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;

    this.getFullName = function () {
        return this.firstName + " " + this.lastName;
    };
}

/*The problem with the constructor function is that when you create multiple instances of the Person, 
 * the this.getFullName() is duplicated in every instance, which is not memory efficient. */


//---Calling a constructor function without the new keyword---

    //To prevent a constructor function to be invoked without the new keyword, ES6 introduced the new.target property.
    function Person(firstName, lastName) {
        if (!new.target) {
            throw Error("Cannot be called without the new keyword");
        }

        this.firstName = firstName;
        this.lastName = lastName;
    }

    //or

    function Person(firstName, lastName) {
        if (!new.target) {
            return new Person(firstName, lastName);
        }

        this.firstName = firstName;
        this.lastName = lastName;
    }

    let person = Person("John", "Doe");

    console.log(person.firstName);


//---Object Property types---

    //1.Data properties


         /* [[Configurarable]] – determines whether a property can be redefined or removed via delete operator.
            [[Enumerable]] – indicates if a property can be returned in the for...in loop.
            [[Writable]] – specifies that the value of a property can be changed.
            [[Value]] – contains the actual value of a property. */

        let person = {
            firstName: 'John',
            lastName: 'Doe'
        };

        //The following example creates a person object with two properties firstName and lastName with the configurable, enumerable,
        //    and writable attributes set to true.And their values are set to 'John' and 'Doe' respectively.

        //To change any attribute of a property, you use the Object.defineProperty() method.

        Object.defineProperty(person, 'ssn', {
            configurable: false,
            enumerable: false,
            value: '012-38-9119'
        });


    //2 Accessor properties


    /* [[Configurarable]] – determines whether a property can be redefined or removed via delete operator.
       [[Enumerable]] – indicates if a property can be returned in the for...in loop.
       [[Get]] 
       [[Set]]  */

    Object.defineProperty(person, 'fullName', {
        get: function () {
            return this.firstName + ' ' + this.lastName;
        },
        set: function (value) {
            let parts = value.split(' ');
            if (parts.length == 2) {
                this.firstName = parts[0];
                this.lastName = parts[1];
            } else {
                throw 'Invalid name format';
            }
        }
    });

    Object.defineProperties(person, { many properties })

//--Object property descriptor--

    let descriptor = Object.getOwnPropertyDescriptor(person, 'firstName');

    {
        value: 'John',
        writable: true,
        enumerable: true,
        configurable: true
    }

// --for..in --

var person = {
    firstName: 'John',
    lastName: 'Doe',
    ssn: '299-24-2351'
};

for (var prop in person) { // iterate prototype properties as well . if you don't need use person.hasOwnProperty(prop)
    console.log(prop + ':' + person[prop]); 
}

Object.values() // return an array of own enumerable property’s values of an object
Object.entries() //returns own enumerable string-keyed property [key, value] pairs of the object

const ssn = Symbol('ssn');
const person = {
    firstName: 'John',
    lastName: 'Doe',
    age: 25,
    [ssn]: '123-345-789'
};

const kv = Object.entries(person);

console.log(kv);

[
    ['firstName', 'John'],
    ['lastName', 'Doe'],
    ['age', 25]
]

Object.assign(target, ...sources) // copies all enumerable and own properties from the source objects to the target object. It returns the target object.

let box = {
    height: 10,
    width: 20
};

let style = {
    color: 'Red',
    borderStyle: 'solid'
};

let styleBox = Object.assign({}, box, style);

console.log(styleBox);

{
    height: 10,
    width: 20,
    color: 'Red',
    borderStyle: 'solid'
}

// ---Object.is---

    let amount = +0,
        volume = -0;
    console.log(Object.is(amount, volume)); // false

    let quantity = NaN;
    console.log(Object.is(quantity, quantity)); // true

    //The others is the same as ===


//--- Destructiog object ---

    let person = {
        firstName: 'John',
        lastName: 'Doe',
        middleName: 'C.',
        currentAge: 28
    };

    let { firstName, lastName, middleName = '', currentAge: age = 18 } = person;

    console.log(middleName); // 'C.'
    console.log(age); // 28

//--- Optional Chaining Operator --- (ES 2020)
    let user = getUser(2);
    let profile = user?.profile ?? defaultProfile;

    let compressedData = file.compress?.(); //return undefined instead of throwing an error


//--- Object property initializer shorthand --- 
    let name = 'Computer',
        status = 'On';

    let machine = {
        name,
        status
    };

//---Computed property name---
    let prefix = 'machine';
    let machine = {
        [prefix + ' name']: 'server',
        [prefix + ' hours']: 10000
    };

    console.log(machine['machine name']); // server
    console.log(machine['machine hours']); // 10000