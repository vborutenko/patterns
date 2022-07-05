
//Every function in JavaScript implicitly returns undefined unless you explicitly specify a return value.

//Inside a function, you can access an object called arguments that represents the named arguments of the function.

function add() {
    let sum = 0;
    for (let i = 0; i < arguments.length; i++) {
        sum += arguments[i];
    }
    return sum;
}

console.log(add(1, 2)); // 3
console.log(add(1, 2, 3, 4, 5)); // 15

/* 
 Function hoisting

In JavaScript, you can use a function before declaring it. For example:

 */

showMe(); // a hoisting example

function showMe() {
    console.log('an hoisting example');
}

//Storing functions in variables

function add(a, b) {
    return a + b;
}

let sum = add;
let result = add(10, 20);
let result = sum(10, 20);

//Passing a function to another function
function average(a, b, fn) {
    return fn(a, b) / 2;
}

let result = average(10, 20, sum);

//Returning functions from functions
function compareBy(propertyName) {
    return function (a, b) {
        let x = a[propertyName],
            y = b[propertyName];

        if (x > y) {
            return 1;
        } else if (x < y) {
            return -1;
        } else {
            return 0;
        }
    };
}

let products = [
    { name: 'iPhone', price: 900 },
    { name: 'Samsung Galaxy', price: 850 },
    { name: 'Sony Xperia', price: 700 },
];

// sort products by name
console.log('Products sorted by name:');
products.sort(compareBy('name'));

/* 
 Anonymous Functions

An anonymous function is not accessible after its initial creation. Therefore, you often need to assign it to a variable.

*/

let show = function () {
    console.log('Anonymous function');
};

show();

//In practice, you often pass anonymous functions as arguments to other functions. For example:

setTimeout(function () {
    console.log('Execute later after 1 second')
}, 1000);

//Immediately invoked function execution

(function () {
    console.log('IIFE');
})();

//and sometimes, you may want to pass arguments into it, like this:

let person = {
    firstName: 'John',
    lastName: 'Doe'
};

(function () {
    console.log(person.firstName + ' ' + person.lastName);
})(person);

/* 
Arrow functions


*/

let show = () => console.log('Anonymous function');
let add = (a, b) => a + b;


/*
Understanding JavaScript Pass - By - Value

In JavaScript, all function arguments are always passed by value. 
It means that JavaScript copies the values of the variables into the function arguments.

It’s not obvious to see that reference values are also passed by values. For example:

*/

let person = {
    name: 'John',
    age: 25,
};

function increaseAge(obj) {
    obj.age += 1;
}

increaseAge(person);

console.log(person); // age would be 26

let person = {
    name: 'John',
    age: 25,
};

function increaseAge(obj) {
    obj.age += 1;

    // reference another object
    obj = { name: 'Jane', age: 22 };
}

increaseAge(person);

console.log(person); // age would be 26

//Resucrsive function

function sum(n) {
    if (n <= 1) {
        return n;
    }

    return n + sum(n - 1);
}

//Default Parameters

function say(message = 'Hi') {
    console.log(message);
}

say(); // 'Hi'
say('Hello') // 'Hello'

//from function

function date(d = today()) {
    console.log(d);
}
function today() {
    return (new Date()).toLocaleDateString("en-US");
}

//Using other parameters in default values

function add(x = 1, y = x, z = x + y) {
    return x + y + z;
}

console.log(add()); // 4