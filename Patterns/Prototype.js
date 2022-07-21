//https://www.javascripttutorial.net/javascript-prototype/

function Person(name) {
    this.name = name;
}

//Behind the scenes, JavaScript creates a new function Person() and an anonymous object:
//Like the Object() function, the Person() function has a property called prototype that references an anonymous object.
//And the anonymous object has the constructor property that references the Person() function.


//In addition, JavaScript links the Person.prototype object to the Object.prototype object via the [[Prototype]],
//which is known as a prototype linkage. (see image)

//The following defines a new method called greet() in the Person.prototype object:
Person.prototype.greet = function () {
    return "Hi, I'm " + this.name + "!";
}

let p1 = new Person('John');
//Internally, the JavaScript engine creates a new object named p1 and links the
//p1 object to the Person.prototype object via the prototype linkage:

//The link between p1, Person.prototype, and Object.protoype is called a prototype chain.

let greeting = p1.greet();

//Because p1 doesn’t have the greet() method, JavaScript follows the prototype linkage and finds it on the Person.prototype object.


p1.__proto__ // access to prototype (not use)

Object.getPrototypeOf(p1) == p1.__proto__ === p1.constructor.prototype


//--Shadowing--

p1.greet = function () {
    console.log('Hello');
}

//Because the p1 object has the greet() method, JavaScript just executes it immediately without looking it up in the prototype chain.


//Summary

//The Object() function has a property called prototype that references a Object.prototype object.

//The Object.prototype object has all properties and methods which are available in all objects such as toString() and valueOf().

//The Object.prototype object has the constructor property that references the Object function.

//Every function has a prototype object. This prototype object references the Object.prototype object via [[prototype]] linkage or __proto__ property.



//The combination of the constructor and prototype patterns is the most common way to define custom types in ES5

function Person(firstName, lastName) {
    this.firstName = firstName;
    this.lastName = lastName;
}

Person.prototype.getFullName = function () {
    return this.firstName + ' ' + this.lastName;
};

let p1 = new Person("John", "Doe");
let p2 = new Person("Jane", "Doe");

//Javascript creates two objects p1 and p2. These objects link to the Person.prototype object via the [[Prototype]] linkage:

//Each object has its own properties firstName and lastName. However, they share the same getFullName() method.

//ES6 introduces the class keyword that makes the constructor/prototype pattern easier to use

class Person {
	constructor(firstName, lastName) {
		this.firstName = firstName;
		this.lastName = lastName;
	}
	getFullName() {
		return this.firstName + " " + this.lastName;
	}
}

let p1 = new Person('John', 'Doe');
let p2 = new Person('Jane', 'Doe');


//--Prototypal inheritance--

Object.create(proto, [propertiesObject]) // The Object.create() method creates a new object and uses an existing object as a prototype of the new object:


// ---Example

function Shape(x, y) {
    this.x = x;
    this.y = y;
}

// 1. Explicitly call base (Shape) constructor from subclass (Circle) constructor passing this as the explicit receiver
function Circle(x, y, r) {
    Shape.call(this, x, y);
    this.r = r;
}

// 2. Use Object.create to construct the subclass prototype object to avoid calling the base constructor
Circle.prototype = Object.create(Shape.prototype);